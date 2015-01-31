using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gav.Transformers;
using Gav.Data;

namespace Infovizprojekt
{
    public class SliceTransformer : DataTransformer
    {
        public int Slice { get; set; }

        protected override void ProcessData()
        {
            float[, ,] inputData = _input.GetDataCube().DataArray;

            if (Slice >= inputData.GetLength(2))
            {   
                return;
            }

            DataCube outputCube = new DataCube();

            float[, ,] outputData = new float[inputData.GetLength(0), inputData.GetLength(1), 1];

            for (int x = 0; x < inputData.GetLength(0); x++)
            {
                for (int y = 0; y < inputData.GetLength(1); y++)
                {
                    outputData[x, y, 0] = inputData[x, y, Slice];
                }
            }

            outputCube.DataArray = outputData;

            _dataCube = outputCube;
        }
    }
}