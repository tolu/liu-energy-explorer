using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Gav.Data;
using Gav.Graphics;
using Microsoft.DirectX;

using Gav.Components.MapLayers;
using Gav.Components;
using Gav.Components.GavLayers;
using Gav.Management;
using Gav.Components.Internal;

namespace Infovizprojekt
{
    public partial class MainWindow : Form
    {
        
        Panel _mapPanel;
        Panel _pcPanelVariables;
        Panel _pcPanelYears;
        Panel _scatterPanel;
        Panel _tableLensPanel;
        Panel _colorLegendPanel;

        public MapHandler MapHandler { get; set; }
        public DataHandler DataHandler { get; set; }
        public PCHandler PCHandler { get; set; }
        public PlotHandler PlotHandler { get; set; }
        public ColorMapHandler ColorMapHandler { get; set; }

        public ViewManager ViewManager { get; set; }
        public IndexVisibilityManager SharedVisibilityManager { get; set; }
        public SelectionAndPickingManager SaPManager = new SelectionAndPickingManager();

        ToolTip toolTip = new ToolTip();

        public const int PC_VAR_PLOT_INIT_VALUE = 0;
        public const int PC_YEARS_PLOT_INIT_VALUE = 0;
        public const int SCATTER_PLOT_Y_INIT_VALUE = 0;
        public const int SCATTER_PLOT_X_INIT_VALUE = 1;
        public const int ALPHA_INIT_VALUE = 3;
        public const int YEAR_INIT_VALUE = 10;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _mapPanel = topSplitContainer.Panel1;
            _pcPanelVariables = pcVariablePanel;
            _pcPanelYears = pcYearPanel;
            _scatterPanel = tabPage1;
            _tableLensPanel = tabPage2;
            _colorLegendPanel = colorLegendPanel;

            // Load data
            DataHandler = new DataHandler(this);
            
            // Managers
            SharedVisibilityManager = new IndexVisibilityManager(DataHandler.AllDataDataCubeProvider.GetDataCube().GetAxisLength(Axis.X));
            ViewManager = new ViewManager(this);

            // created all component handlers
            ColorMapHandler = new ColorMapHandler(this);
            MapHandler = new MapHandler(this);
            PCHandler = new PCHandler(this);
            PlotHandler = new PlotHandler(this);

            // sap...
            SaPManager.Picked += new EventHandler<Gav.Event.IndexesPickedEventArgs>(sapManager_Picked);

            //manages alpha for pc_plots and scatter plot
            lineGlyphAlpha.ValueChanged += new EventHandler(lineGlyphAlpha_ValueChanged);

            yearSlider.Value = MainWindow.YEAR_INIT_VALUE;
            lineGlyphAlpha.Value = MainWindow.ALPHA_INIT_VALUE;

            ColorMapHandler.UpdateColorLegendLabels();
        }


        void lineGlyphAlpha_ValueChanged(object sender, EventArgs e)
        {
            // alpha: {0:250} in ten steps of 25 each
            int opacity = (int) lineGlyphAlpha.Value * 25;
            PCHandler._pcPlotVariables.LineAlpha = opacity;
            PCHandler._pcPlotYears.LineAlpha = opacity;
            PlotHandler._scatterplot.GlyphTransparency = opacity;
            ViewManager.InvalidateAll();
        }


        void sapManager_Picked(object sender, Gav.Event.IndexesPickedEventArgs e)
        {
            // fullösning, väljer inte länder eller prickar om man använder kmeans
            if (!PCHandler.UsingKMeans)
            {
                //löser problemet med att bara lägga till i scatter plotten efter att man hållt ned ctrl
                SaPManager.State = SelectionAndPickingManager.SelectionState.Replace;
                // translate indexes to map regions
                List<int> mapMappedIndex = new List<int>();
                foreach (var item in e.PickedIndexes)
                {
                    int tmp;
                    MapHandler.indexMapper.TryBackwardMapIndex(item, out tmp);
                    mapMappedIndex.Add(tmp);
                }
                MapHandler._polygonLayer.SetSelectedIndexes(mapMappedIndex);

                this.MapHandler._mainChoroplethMap.Invalidate();
                this.PCHandler._pcPlotVariables.Invalidate();
                this.PCHandler._pcPlotYears.Invalidate();
            }
        }


        public Panel getMapPanel()
        {
            return _mapPanel;
        }

        public Panel getPCPanelVariables()
        {
            return _pcPanelVariables;
        }

        public Panel getPCPanelYears()
        {
            return _pcPanelYears;
        }

        public Panel getScatterPanel()
        {
            return _scatterPanel;
        }

        public Panel getTableLensPanel()
        {
            return _tableLensPanel;
        }

        public Panel getColorLegendPanel()
        {
            return _colorLegendPanel;
        }
       
        private void resetMapButton_Click(object sender, EventArgs e)
        {
            MapHandler.resetMapScaleAndPosition();
        }

        private void playTimeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (DataHandler.EndYear-DataHandler.StartYear); i++)
            {
                yearSlider.Value = i;
                ViewManager.InvalidateAll();
                System.Threading.Thread.Sleep(250);
            }
        }

        // tooltips for reset buttons in map and pc panels
        private void mapReset_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Reset map", this, mapReset.Location, 1500);
        }

        private void varPCReset_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(varPCReset.Location.X, topSplitContainer.Panel1.ClientSize.Height+2*varPCReset.Location.Y); 
            toolTip.Show("Reset filtering", this, location, 1500);
        }

        private void yearPCReset_MouseHover(object sender, EventArgs e)
        {
            int x = yearPCReset.Location.X;
            int y = topSplitContainer.Panel1.ClientSize.Height + 2 * yearPCReset.Location.Y + pcVariablePanel.ClientSize.Height;
            Point location = new Point(x, y);
            toolTip.Show("Reset filtering", this, location, 1500);
        }

        private void colorLegendReset_MouseHover(object sender, EventArgs e)
        {
            int x = colorLegendReset.Location.X;
            int y = colorLegendReset.Location.Y;
            Point location = new Point(x, y);
            toolTip.Show("Reset color legend", this, location, 1500);
        }
    }
}