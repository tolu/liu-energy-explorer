using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gav.Transformers;
using Gav.Data;

namespace Infovizprojekt
{
    public class RawDataTransformer : DataTransformer
    {
        public bool UseInterpolation { get; set; }

        public List<int> CollumnsForInterpolation { get; set; }

        float[, ,] _outputData;
        float[, ,] _untouchedData;
        float[, ,] _interpolatedOutputData;

        public bool ForceRetransformation { get; set; }
        
        bool _firstTime = true;

        protected override void ProcessData()
        {
            if (ForceRetransformation || _firstTime)
            {
                _dataCube = new DataCube();

                float[, ,] inputData = _input.GetDataCube().DataArray;

                _outputData = replaceNaNPlaceholder(inputData);

                if (UseInterpolation)
                {
                    _untouchedData = (float[, ,]) _outputData.Clone();
                    _outputData = interpolateDataVariables(_outputData);
                    _interpolatedOutputData = (float[, ,]) _outputData.Clone();
                }

                _firstTime = false;
            }
            else
            {
                if (UseInterpolation)
                {
                    _outputData = (float[, ,]) _interpolatedOutputData.Clone();
                }
                else
                {
                    _outputData = (float[, ,]) _untouchedData.Clone();
                }
            }

            _dataCube.DataArray = _outputData;
        }

        private float[, ,] replaceNaNPlaceholder(float[, ,] inputData)
        {
            float[, ,] outputData = new float[inputData.GetLength(0), inputData.GetLength(1), inputData.GetLength(2)];

            for (int x = 0; x < inputData.GetLength(0); x++)
            {
                for (int y = 0; y < inputData.GetLength(1); y++)
                {
                    for (int z = 0; z < inputData.GetLength(2); z++)
                    {
                        if (inputData[x, y, z] != -1)
                        {
                            outputData[x, y, z] = inputData[x, y, z];
                        }
                        else
                        {
                            outputData[x, y, z] = float.NaN;
                        }
                    }
                }
            }

            return outputData;
        }

        private float[, ,] interpolateDataVariables(float[, ,] inputData)
        {
            for (int y = 0; y < inputData.GetLength(1); y++)
            {
                foreach (int x in CollumnsForInterpolation)
                {
                    float prevValue = float.NaN;
                    int prevPosition = -1;
                    float nextValue = float.NaN;
                    int nextPosition = -1;

                    for (int z = 0; z < inputData.GetLength(2); z++)
                    {
                        // find first position with a value
                        if (prevPosition == -1 && !float.IsNaN(inputData[x, y, z]))
                        {
                            prevPosition = z;
                            prevValue = inputData[x, y, z];
                        }

                        // find the next position with a value
                        if (nextPosition == -1)
                        {
                            nextPosition = -1;
                            nextValue = float.NaN;

                            for (int z2 = z+1; z2 < inputData.GetLength(2); z2++)
                            {
                                if (!float.IsNaN(inputData[x, y, z2]))
                                {
                                    nextPosition = z2;
                                    nextValue = inputData[x, y, z2];
                                    break;
                                }
                            }
                        }

                        // have we reached the next position?
                        // if so, reset the search
                        if (nextPosition == z)
                        {
                            prevValue = inputData[x, y, z];
                            prevPosition = z;
                            nextValue = float.NaN;
                            nextPosition = -1;
                        }
                        else
                        {
                            if (float.IsNaN(prevValue) || float.IsNaN(nextValue))
                            {
                                inputData[x, y, z] = float.NaN;
                            }
                            else
                            {
                                inputData[x, y, z] = prevValue + ((nextValue - prevValue) / (nextPosition - prevPosition)) * (nextPosition - z);
                            }
                        }
                    }
                }
            }

            return inputData;
        }
    }
}