using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gav.Transformers;
using Gav.Data;


namespace Infovizprojekt
{
    public class YearVarTransformer : DataTransformer
    {
        public int VarIndex { get; set; }

        protected override void ProcessData()
        {
            float[, ,] inputData = _input.GetDataCube().DataArray;

            if (VarIndex >= inputData.GetLength(1))
            {
                return;
            }

            DataCube outputCube = new DataCube();

            float[, ,] outputData = new float[inputData.GetLength(2), inputData.GetLength(1), 1];

            for (int y = 0; y < inputData.GetLength(1); y++)
            {
                for (int z = 0; z < inputData.GetLength(2); z++)
                {
                    outputData[z, y, 0] = inputData[VarIndex, y, z];
                }
            }

            outputCube.DataArray = outputData;

            _dataCube = outputCube;
        }
    }
}

