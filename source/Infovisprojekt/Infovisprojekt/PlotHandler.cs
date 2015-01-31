using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;

using Gav.Components.MapLayers;
using Gav.Components;
using Gav.Components.Internal;
using Gav.Data;
using Gav.Management;
using Gav.Graphics;


namespace Infovizprojekt
{
    public class PlotHandler : BaseHandler
    {
        public ScatterPlot2D _scatterplot = new ScatterPlot2D();
        public TableLens _tableLens = new TableLens();
        
        GavToolTip _gavToolTip;
        MouseHoverController _hoverController, _hoverControllerTableLens;
        TableLensRowSorter _rowSorter;

        public PlotHandler(MainWindow mainWindow) : base(mainWindow)
        {
            init();
        }

        public void init()
        {
            //add controller for tooltips
            _gavToolTip = new Gav.Management.GavToolTip(_mainWindow);
            _gavToolTip.FadeTime = 150;
            //create mouse hover controllers
            _hoverController = new Gav.Graphics.MouseHoverController(_mainWindow.getScatterPanel(), 2, 50);
            _hoverControllerTableLens = new MouseHoverController(_mainWindow.getTableLensPanel(), 2, 50);
            //listeners FOR HOVER controller
            _hoverController.Hover += new EventHandler(_hoverController_Hover);
            _hoverController.HoverEnd += new EventHandler(_hoverController_HoverEnd);
            _hoverControllerTableLens.Hover += new EventHandler(_hoverControllerTableLens_Hover);
            _hoverControllerTableLens.HoverEnd += new EventHandler(_hoverControllerTableLens_HoverEnd);
            // dont know why I´m doing this but it makes the tooltip show at correct location the first time its called
            _gavToolTip.Show(new System.Drawing.Point(1, 1));
            _gavToolTip.Hide();

            //Manage the 2D scatter plot
            _scatterplot.Name = "ScatterPLot2D";
            _scatterplot.Input = _mainWindow.DataHandler.MainDataCubeProvider;
            _scatterplot.Enabled = true;
            _scatterplot.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;
            _scatterplot.GlyphMinSize = 0.025f;
            _scatterplot.GlyphSize = 0.025f;

            //init the drop down combo boxes, ie set the possible variables to the list
            _mainWindow.ScatterXaxisValuesSelector.Items.AddRange(_mainWindow.DataHandler.getColumnHeaders().ToArray());
            _mainWindow.ScatterYaxisValuesSelector.Items.AddRange(_mainWindow.DataHandler.getColumnHeaders().ToArray());
            _mainWindow.ScatterSizeSelector.Items.AddRange(_mainWindow.DataHandler.getColumnHeaders().ToArray());

            //init scatterplot labels
            int initX = MainWindow.SCATTER_PLOT_X_INIT_VALUE;
            int initY = MainWindow.SCATTER_PLOT_Y_INIT_VALUE;
            _scatterplot.AxisYText = "."; //fulis för att få den att inte synas
            _scatterplot.AxisIndexY = initY;
            _mainWindow.ScatterXaxisValuesSelector.SelectedIndex = initX;
            _mainWindow.yAxisLabel.Text = _mainWindow.ScatterYaxisValuesSelector.Items[initY].ToString();
            _scatterplot.AxisXText = "."; //fulis för att få den att inte synas
            _scatterplot.AxisIndexX = initX;
            _scatterplot.ShowGrid = true;
            _scatterplot.ShowAxisValues = false;
            _scatterplot.NumberOfGridLines = 8;
            _scatterplot.AxisTextFont = new System.Drawing.Font(_scatterplot.AxisTextFont.Name, 7.0f);
            _scatterplot.PaddingBottom = 60;
            _scatterplot.PaddingTop = 25;
            _mainWindow.ScatterYaxisValuesSelector.SelectedIndex = initY;
            _mainWindow.xAxisLabel.Text = _mainWindow.ScatterYaxisValuesSelector.Items[initX].ToString();


            // init table lens
            _tableLens.Input = _mainWindow.DataHandler.MainDataCubeProvider;
            _tableLens.HeadersList = _mainWindow.DataHandler.getColumnHeaders();
            _tableLens.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;
            _tableLens.Enabled = true;
            _tableLens.HeaderFont = new System.Drawing.Font(_tableLens.HeaderFont.Name, 7.0f);
            

            _rowSorter = new TableLensRowSorter();
            _rowSorter.Input = _mainWindow.DataHandler.MainDataCubeProvider;
            _rowSorter.IndexVisibilityManager = _mainWindow.SharedVisibilityManager;

            // index visibility manager
            _scatterplot.IndexVisibilityManager = _mainWindow.SharedVisibilityManager;
            _tableLens.IndexVisibilityManager = _mainWindow.SharedVisibilityManager;
            
            // selection colors
            _scatterplot.SelectedGlyphColor = _mainWindow.ColorMapHandler.SelectionColor;

            // event listeners
            _mainWindow.SaPManager.AddComponent(_tableLens);
            _mainWindow.SaPManager.AddComponent(_scatterplot);
            _mainWindow.ScatterXaxisValuesSelector.SelectedIndexChanged += new EventHandler(ScatterXaxisValuesSelector_SelectedIndexChanged);
            _mainWindow.ScatterYaxisValuesSelector.SelectedIndexChanged += new EventHandler(ScatterYaxisValuesSelector_SelectedIndexChanged);
            _mainWindow.ScatterSizeSelector.SelectedIndexChanged += new EventHandler(ScatterSizeSelector_SelectedIndexChanged);
            _tableLens.HeaderClicked += new EventHandler(_tableLens_HeaderClicked);

            // add to viewmanager
            _mainWindow.ViewManager.Add(_scatterplot, _mainWindow.getScatterPanel());
            _mainWindow.ViewManager.Add(_tableLens, _mainWindow.getTableLensPanel());
        }


        void _tableLens_HeaderClicked(object sender, EventArgs e)
        {
            _rowSorter.SortByCol = _tableLens.SelectedHeader;
            _rowSorter.ToggleSortingOrder();

            InvalidateTableLens();
        }

        public void InvalidateTableLens()
        {
            _rowSorter.SortByCol = _tableLens.SelectedHeader;
            _rowSorter.PerformSort();
            _tableLens.RowToItemMappingList = _rowSorter.getRowToItemMapping();

            _tableLens.Invalidate();
        }

        void _hoverController_HoverEnd(object sender, EventArgs e)
        {
            //hide the tooltip
            _gavToolTip.Hide();
        }

        void _hoverController_Hover(object sender, EventArgs e)
        {
            // show the tooltip            
            if (_scatterplot.GetIndexesAtLocation(_hoverController.HoverPosition).Count > 0)
            {   
                int country = _scatterplot.GetIndexesAtLocation(_hoverController.HoverPosition).ElementAt(0);

                String countryInfo = _mainWindow.DataHandler.RawDataProvider.NaNColumns[0][0][country].ToString();
                int z = _mainWindow.yearSlider.Value;

                for (int i = 0; i < _mainWindow.DataHandler.RawDataProvider.ColumnHeaders.Count; i++)
                {
                    countryInfo += "\n" + _mainWindow.DataHandler.RawDataProvider.ColumnHeaders[i];
                    countryInfo += "   " + _mainWindow.DataHandler.getValueFromDataCube(i, country, z);
                }

                //_mainWindow.DataHandler.getValueFromDataCube(1,2,3);
                _gavToolTip.Text = countryInfo;
                _gavToolTip.Show(new System.Drawing.Point(_hoverController.HoverScreenPosition.X - 5, _hoverController.HoverScreenPosition.Y + 150));
                
                
            }
            //throw new NotImplementedException();
        }

        void _hoverControllerTableLens_HoverEnd(object sender, EventArgs e)
        {
            //hide the tooltip
            _gavToolTip.Hide();
        }

        void _hoverControllerTableLens_Hover(object sender, EventArgs e)
        {
            // show the tooltip            
            int country = _tableLens.GetIndexAtLocation(_hoverControllerTableLens.HoverPosition);
            //get screen and mouse position
            int x = _hoverControllerTableLens.HoverScreenPosition.X;
            int y = _hoverControllerTableLens.HoverScreenPosition.Y;
            System.Drawing.Point mousePos = _hoverControllerTableLens.HoverPosition;

            if (_tableLens.GetIndexAtLocation(mousePos) > -1)
            {
                String countryInfo = _mainWindow.DataHandler.RawDataProvider.NaNColumns[0][0][country].ToString();
                int z = _mainWindow.yearSlider.Value;

                for (int i = 0; i < _mainWindow.DataHandler.RawDataProvider.ColumnHeaders.Count; i++)
                {
                    countryInfo += "\n" + _mainWindow.DataHandler.RawDataProvider.ColumnHeaders[i];
                    countryInfo += "   " + _mainWindow.DataHandler.getValueFromDataCube(i, country, z);
                }

                //_mainWindow.DataHandler.getValueFromDataCube(1,2,3);
                _gavToolTip.Text = countryInfo;
                _gavToolTip.Show(new System.Drawing.Point(x - 5, y + 150));
            }
            
            //show tooltip with full header name
            int header = _tableLens.GetHeaderIndexAtLocation(mousePos);
            if (header != -1)
            {
                _gavToolTip.Text = _mainWindow.DataHandler.getColumnHeaders().ElementAt(header);
                _gavToolTip.Show(new System.Drawing.Point(x - 5, y-5));
            }

        }

        void ScatterSizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scatterplot.AxisIndexSize = _mainWindow.ScatterSizeSelector.SelectedIndex;

            _mainWindow.ViewManager.InvalidateAll();
            //throw new NotImplementedException();
        }
        
        void ScatterYaxisValuesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scatterplot.AxisIndexY = _mainWindow.ScatterYaxisValuesSelector.SelectedIndex;
            _mainWindow.yAxisLabel.Text = _mainWindow.ScatterYaxisValuesSelector.Text;

            _mainWindow.ViewManager.InvalidateAll();
        }

        void ScatterXaxisValuesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scatterplot.AxisIndexX = _mainWindow.ScatterXaxisValuesSelector.SelectedIndex;
            _mainWindow.xAxisLabel.Text = _mainWindow.ScatterXaxisValuesSelector.Text;
            
            _mainWindow.ViewManager.InvalidateAll();
            //throw new NotImplementedException();
        }
    }
}
