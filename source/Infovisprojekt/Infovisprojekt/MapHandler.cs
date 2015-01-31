using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Gav.Components.MapLayers;
using Gav.Components;
using Gav.Management;
using Gav.Components.Internal;
using Gav.Data;
using Gav.Graphics;

using Microsoft.DirectX;


namespace Infovizprojekt
{
    public class MapHandler : BaseHandler
    {
        MapData _mapData = new MapData();
        MapData _worldData = new MapData();
        MapBorderLayer _borderLayer = new MapBorderLayer();
        MapBorderLayer _worldBorderLayer = new MapBorderLayer();
        public MapPolygonLayer _polygonLayer = new MapPolygonLayer();
        MapPolygonLayer _worldPolygonLayer = new MapPolygonLayer();
        public ChoroplethMap _mainChoroplethMap = new ChoroplethMap();
        GavToolTip _gavToolTip;
        MouseHoverController _hoverController;
        Vector2 mapInitPos = new Vector2(0.4956f, 0.283877f);
        float mapInitZoom = -0.5181f;

        public StringIndexMapper indexMapper;

        Point _mousePosition;
        Vector2 _mapPosition;
        List<int> _regionIndex = new List<int>();
        List<int> _mappedRegionIndex = new List<int>();
        int _region, _mappedRegion;

        public MapHandler(MainWindow mainWindow) : base(mainWindow)
        {
            init();
        }

        private void init()
        {
            //Read map data into map data object
            _mapData = MapReader.Read(@"..\..\..\data\world3.map", @"..\..\..\data\world.dbf");

            //Create map layers and add them to choropleth map
            _polygonLayer.MapData = _mapData;
            
            indexMapper = new StringIndexMapper(_mapData.AllDbfFields["GMI_CNTRY"], _mainWindow.DataHandler.RawDataProvider.RowIds);
            _polygonLayer.IndexMapper = indexMapper;
            

            _mainChoroplethMap.AddLayer(_polygonLayer);

            _borderLayer.MapData = _mapData;
            _mainChoroplethMap.AddLayer(_borderLayer);

            _polygonLayer.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;

            _mainChoroplethMap.Position = mapInitPos;
            _mainChoroplethMap.Zoom = mapInitZoom;


            // index visibility manager
            _polygonLayer.IndexVisibilityManager = _mainWindow.SharedVisibilityManager;

            // selection colors
            _polygonLayer.SelectedPolygonColor = _mainWindow.ColorMapHandler.SelectionColor;

            // add tooltip to the map
            _gavToolTip = new GavToolTip(_mainWindow);
            _gavToolTip.FadeTime = 150;
            _hoverController = new MouseHoverController(_mainWindow.getMapPanel(), 1, 5);
            _hoverController.Hover += new EventHandler(_hoverController_Hover);
            _hoverController.HoverEnd += new EventHandler(_hoverController_HoverEnd);

            _mainWindow.SaPManager.AddComponent(_mainChoroplethMap);
            _mainWindow.SaPManager.AddComponent(_polygonLayer);

            _mainChoroplethMap.VizComponentMouseDown += new EventHandler<VizComponentMouseEventArgs>(_mainChoroplethMap_VizComponentMouseDown);
            _mainWindow.mapReset.Click += new EventHandler(mapReset_Click);

            //Add objects to view manager
            _mainWindow.ViewManager.Add(_mainChoroplethMap, _mainWindow.getMapPanel());
                        
        }

        void mapReset_Click(object sender, EventArgs e)
        {
            _mainChoroplethMap.Position = mapInitPos;
            _mainChoroplethMap.Zoom = mapInitZoom;

            _mainChoroplethMap.Invalidate();
        }

        void _mainChoroplethMap_VizComponentMouseDown(object sender, VizComponentMouseEventArgs e)
        {
            _regionIndex = _polygonLayer.GetSelectedIndexes();
            _mousePosition.X = e.MouseEventArgs.Location.X;
            _mousePosition.Y = e.MouseEventArgs.Location.Y;
            _mapPosition = _mainChoroplethMap.ConvertScreenCoordinatesToMapCoordinates(_mousePosition);
            _region = _mapData.GetRegionId(_mapPosition.X, _mapPosition.Y);

            if (_region != -1)
            {
                if (!_regionIndex.Contains(_region))
                {
                    // can only select several if you hold the control key
                    if (MainWindow.ModifierKeys == System.Windows.Forms.Keys.Control)
                    {
                        _regionIndex.Insert(0, _region);
                        //translate to other comps
                        indexMapper.TryMapIndex(_region, out _mappedRegion);
                        _mappedRegionIndex.Insert(0, _mappedRegion);
                    }
                    else
                    {
                        _regionIndex.Clear();
                        _regionIndex.Insert(0, _region);
                        //translate to other comps
                        _mappedRegionIndex.Clear();
                        indexMapper.TryMapIndex(_region, out _mappedRegion);
                        _mappedRegionIndex.Insert(0, _mappedRegion);
                    }
                }
                else
                {
                    _regionIndex.Remove(_region);
                    indexMapper.TryMapIndex(_region, out _mappedRegion);
                    _mappedRegionIndex.Remove(_mappedRegion);
                }
            }
            //om man trycker utanför något land rensas listan
            else
            {
                _regionIndex.Clear();
                _mappedRegionIndex.Clear();
            }
            //add selection to components
            _polygonLayer.SetSelectedIndexes(_regionIndex);
            _mainWindow.PCHandler._pcPlotVariables.SetSelectedIndexes(_mappedRegionIndex);
            _mainWindow.PCHandler._pcPlotYears.SetSelectedIndexes(_mappedRegionIndex);
            _mainWindow.PlotHandler._scatterplot.SetSelectedIndexes(_mappedRegionIndex);
            _mainWindow.PlotHandler._tableLens.SetSelectedIndexes(_mappedRegionIndex);

            //force repaint on all components
            _mainWindow.ViewManager.InvalidateAll();
        }

        public void resetMapScaleAndPosition()
        {
            _mainChoroplethMap.Position = mapInitPos;
            _mainChoroplethMap.Zoom = mapInitZoom;
        }

        void _hoverController_HoverEnd(object sender, EventArgs e)
        {
            // hide tooltip
            _gavToolTip.Hide();
        }

        void _hoverController_Hover(object sender, EventArgs e)
        {
            Vector2 pos = _mainChoroplethMap.ConvertScreenCoordinatesToMapCoordinates(_hoverController.HoverPosition);
            int region = _mapData.GetRegionId(pos.X, pos.Y);

            if (region != -1)
            {
                //_gavToolTip.Text = _mainWindow.DataHandler.RawDataProvider.RowIds[region];
                _gavToolTip.Text = _mapData.RegionFullNames[region];
                
                _gavToolTip.Show(new System.Drawing.Point(_hoverController.HoverScreenPosition.X-5, _hoverController.HoverScreenPosition.Y-5));
            }

        }

    }
}