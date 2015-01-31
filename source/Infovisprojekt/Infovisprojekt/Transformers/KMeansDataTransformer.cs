using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gav.Data;
using Gav.Transformers;

namespace Infovizprojekt
{
    public class KMeansDataTransformer : DataTransformer
    {
        public int K = 3;
        float[, ,] inputData;
        float[] max, min;
        int sizeX, sizeY, sizeZ;
        bool changed = true;
        float[, ,] outputData;
        float[] tempIndex;
        Random random = new Random();
        float number, currentDistance, tempDistance;
        float[] temp;
        public DataCube centroidCube = new DataCube();
        float[, ,] centroidData;


        protected override void ProcessData()
        {
            // The DataTransformers's input data.
            inputData = _input.GetDataCube().DataArray;

            sizeX = inputData.GetLength(0);
            sizeY = inputData.GetLength(1);
            sizeZ = inputData.GetLength(2);
            
            temp = new float[sizeX];
            tempIndex = new float[sizeY];
            max = new float[sizeX];
            min = new float[sizeX];
            outputData = new float[sizeX + 1, sizeY + K, sizeZ];
            centroidData = new float[sizeX, K, sizeZ];
            
            KMeans(K);
            centroidCube.DataArray = centroidData;
            

            // The output data should be set to _dataCube.DataArray.
            _dataCube.DataArray = outputData;
 
        }
        private void KMeans(int K)
        {
            //Normalize the data
            for (int z = 0; z < sizeZ; z++)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    _input.GetDataCube().GetColumnMaxMin(i, out max[i], out min[i]);
                    for (int j = 0; j < sizeY; j++)
                    {
                        if (float.IsNaN(outputData[i, j, z]) == false)
                        {
                            outputData[i, j, z] = (inputData[i, j, z] - min[i]) / (max[i] - min[i]);
                        }
                    }
                }



                for (int i = sizeY; i < sizeY + K; i++)
                {
                    outputData[sizeX, i, z] = -1;
                }

                //Randomize initial cluster partitioning
                for (int i = 0; i < sizeY; i++)
                {
                    outputData[sizeX, i, z] = random.Next(K);
                    tempIndex[i] = outputData[sizeX, i, z];
                }

                //to ensure every cluster gets at least one data item
                for (int i = 0; i < K; i++)
                {
                    outputData[sizeX, i, z] = i;
                    tempIndex[i] = i;
                }

                //Calculate and store centroids one cluster at a time
                for (int k = 0; k < K; k++)
                {
                    //Reset temporary variables
                    number = 0;
                    for (int x = 0; x < sizeX; x++)
                    {
                        temp[x] = 0;
                    }

                    //Rows
                    for (int y = 0; y < sizeY; y++)
                    {
                        //Check if partition of row is k. If it is add value of each column to centroid, otherwise go to next row.
                        if (outputData[sizeX, y, z] == k)
                        {
                            number = number + 1;
                            //Columns
                            for (int x = 0; x < sizeX; x++)
                            {
                                if (float.IsNaN(outputData[x, y, z]) == false)
                                {
                                    temp[x] = temp[x] + outputData[x, y, z];
                                }
                               
                            }
                        }

                    }

                    //Divide centroid with number of rows that belonged to that centroid to get mean value
                    for (int x = 0; x < sizeX; x++)
                    {
                        outputData[x, sizeY + k, z] = temp[x] / number;
                    }
                }

                //Repartition the dataset and recalculate centroids until finished
                while (changed == true)
                {
                    changed = false;
                    //First repartition
                    for (int y = 0; y < sizeY; y++)
                    {
                        currentDistance = 1000;
                        for (int k = 0; k < K; k++)
                        {
                            tempDistance = 0;
                            //Check distance to centroid K and if smaller than current distance change centroid partition
                            for (int x = 0; x < sizeX; x++)
                            {
                                if ( float.IsNaN(outputData[x, y, z])== false)
                                {
                                    tempDistance += ((outputData[x, y, z] - outputData[x, sizeY + k, z]) * (outputData[x, y, z] - outputData[x, sizeY + k, z]));
                                }
                            }
                            tempDistance = (float)Math.Sqrt(tempDistance);

                            if (tempDistance < currentDistance)
                            {
                                currentDistance = tempDistance;
                                outputData[sizeX, y, z] = k;
                            }
                        }
                    }

                    //Recalculate centroids
                    for (int k = 0; k < K; k++)
                    {
                        //Reset temporary variables
                        number = 0;
                        for (int x = 0; x < sizeX; x++)
                        {
                            temp[x] = 0;
                        }

                        //Rows
                        for (int y = 0; y < sizeY; y++)
                        {
                            //Check if partition of row is k. If it is add value of each column to centroid, otherwise go to next row.
                            if (outputData[sizeX, y, z] == k)
                            {
                                number = number + 1;
                                //Columns
                                for (int x = 0; x < sizeX; x++)
                                {
                                    if (float.IsNaN(outputData[x, y, z]) == false)
                                    {
                                        temp[x] = temp[x] + outputData[x, y, z];
                                    }
                                }
                            }

                        }

                        //Divide centroid with number of rows that belonged to that centroid to get mean value
                        for (int x = 0; x < sizeX; x++)
                        {
                            outputData[x, sizeY + k, z] = temp[x] / number;
                        }
                    }
                    for (int y = 0; y < sizeY; y++)
                    {
                        if (tempIndex[y] != outputData[sizeX, y, z])
                        {
                            tempIndex[y] = outputData[sizeX, y, z];
                            changed = true;
                        }
                    }

                }


                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY + K; j++)
                    {
                        outputData[i, j, z] = (outputData[i, j, z] * (max[i] - min[i])) + min[i];

                    }
                }
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < K; j++)
                    {
                        centroidData[i, j, z] = outputData[i, sizeY + j, z];
                        
                    }
                }

            }
        }
    }
}
