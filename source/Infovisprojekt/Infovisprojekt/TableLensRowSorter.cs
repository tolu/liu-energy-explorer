using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gav.Transformers;
using Gav.Data;
using Gav.Management;

namespace Infovizprojekt
{
    public class TableLensRowSorter
    {
        public int SortByCol { get; set; }
        public int Direction { get; set; }
        public enum SortDirections { ASC, DESC, NOSORT };

        private int[] _outputToInputMappingList;
        private int _lastSortCol = -1;

        public IDataCubeProvider Input { get; set; }
        public IndexVisibilityManager IndexVisibilityManager { get; set; }

        public TableLensRowSorter()
        {
            SortByCol = -1;
            Direction = (int) TableLensRowSorter.SortDirections.NOSORT;
        }

        public void ToggleSortingOrder()
        {
            if (SortByCol != -1)
            {
                if (_lastSortCol == SortByCol && Direction == (int)TableLensRowSorter.SortDirections.ASC)
                {
                    Direction = (int)TableLensRowSorter.SortDirections.DESC;
                }
                else if (_lastSortCol == SortByCol && Direction == (int) TableLensRowSorter.SortDirections.DESC)
                {
                    Direction = (int)TableLensRowSorter.SortDirections.NOSORT;
                }
                else if (_lastSortCol == SortByCol && Direction == (int) TableLensRowSorter.SortDirections.NOSORT)
                {
                    Direction = (int)TableLensRowSorter.SortDirections.ASC;
                }
                else if (_lastSortCol != SortByCol && Direction == (int)TableLensRowSorter.SortDirections.NOSORT)
                {
                    Direction = (int)TableLensRowSorter.SortDirections.ASC;
                }
            }
        }

        public void PerformSort()
        {
            float[, ,] inputData = Input.GetDataCube().DataArray;

            if (SortByCol == -1 || Direction == (int) TableLensRowSorter.SortDirections.NOSORT)
            {
                _lastSortCol = SortByCol;
                return;
            }

            float[, ,] outputData = new float[inputData.GetLength(0), inputData.GetLength(1), 1];

            float[] values = new float[inputData.GetLength(1)];
            _outputToInputMappingList = new int[inputData.GetLength(1)];
            for (int y = 0; y < inputData.GetLength(1); y++ )
            {
                if (float.IsNaN(inputData[SortByCol, y, 0]) || !IndexVisibilityManager.GetVisibility(y))
                {
                    values[y] = float.NegativeInfinity;
                }
                else
                {
                    values[y] = inputData[SortByCol, y, 0];
                }

                _outputToInputMappingList[y] = y;
            }

            Array.Sort(values, _outputToInputMappingList);

            _lastSortCol = SortByCol;
        }


        public List<int> getRowToItemMapping()
        {
            List<int> list;

            if (Direction == (int) TableLensRowSorter.SortDirections.ASC)
            {
                list = new List<int>(_outputToInputMappingList);
            }
            else if (Direction == (int) TableLensRowSorter.SortDirections.DESC)
            {
                list = new List<int>(_outputToInputMappingList);
                list.Reverse();
            }
            else
            {
                list = new List<int>();
                for (int i = 0; i < Input.GetDataCube().GetAxisLength(Axis.Y); i++)
                {
                    list.Add(i);
                }
            }
            
            return list;
        }
    }
}