using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gav.Data;

namespace Infovizprojekt
{
    public class DataHandler : BaseHandler
    {
        public ExcelDataProvider RawDataProvider { get; set; }

        public RawDataTransformer AllDataDataCubeProvider { get; set; }

        public SliceTransformer MainDataCubeProvider { get; set; }
        public YearVarTransformer YearDataCubeProvider { get; set; }
        public KMeansDataTransformer KMeansDataCubeProvider { get; set; }
        public KMeansDataTransformer KMeansForYearsProvider { get; set; }

        public const int StartYear = 1990;
        public const int EndYear = 2005;

        public List<int> InterpolationCols { get; set; }

        public DataHandler(MainWindow mainWindow) : base(mainWindow)
        {
            init();
        }

        public void init()
        {
            RawDataProvider = new ExcelDataProvider();

            AllDataDataCubeProvider = new RawDataTransformer();
            MainDataCubeProvider = new SliceTransformer();
            YearDataCubeProvider = new YearVarTransformer();
            KMeansDataCubeProvider = new KMeansDataTransformer();
            KMeansForYearsProvider = new KMeansDataTransformer();

            //read data from excel file
            RawDataProvider.HasIDColumn = true;
            RawDataProvider.Load(@"..\..\..\data\data.xls");

            AllDataDataCubeProvider.Input = RawDataProvider;
            
            InterpolationCols = new List<int>();
            InterpolationCols.Add(5);
            InterpolationCols.Add(11);
            AllDataDataCubeProvider.CollumnsForInterpolation = InterpolationCols;
            AllDataDataCubeProvider.UseInterpolation = true;

            AllDataDataCubeProvider.CommitChanges();

            YearDataCubeProvider.Input = AllDataDataCubeProvider;
            MainDataCubeProvider.Input = AllDataDataCubeProvider;
            KMeansDataCubeProvider.Input = MainDataCubeProvider;
            KMeansForYearsProvider.Input = YearDataCubeProvider;

            // event listeners
            _mainWindow.interpolationCheckBox.CheckedChanged += new EventHandler(interpolationCheckBox_CheckedChanged);
        }

        void interpolationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _mainWindow.PCHandler._pcPlotVariables.Enabled = false;
            _mainWindow.PCHandler._pcPlotYears.Enabled = false;

            AllDataDataCubeProvider.UseInterpolation = _mainWindow.interpolationCheckBox.Checked;
            AllDataDataCubeProvider.CommitChanges();

            _mainWindow.PCHandler._pcPlotVariables.Enabled = true;
            _mainWindow.PCHandler._pcPlotYears.Enabled = true;
            
            _mainWindow.ViewManager.InvalidateAll();
        }

        public List<string> getColumnHeaders()
        {
            return RawDataProvider.GetColumnHeaders();
        }

        public List<string> getYearsAsList()
        {
            List<string> yearList = new List<string>();

            for (int i = StartYear; i <= EndYear; i++)
            {
                yearList.Add(i.ToString());
            }

            return yearList;
        }

        public string getValueFromDataCube(int x, int y, int z)
        {
            String str;

            str = AllDataDataCubeProvider.GetDataCube().DataArray[x, y, z].ToString();

            return str;
        }
    }
}