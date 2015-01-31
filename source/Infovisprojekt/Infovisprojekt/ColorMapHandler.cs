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
    public class ColorMapHandler : BaseHandler
    {
        public EmptyVizComponent ColorLegendContainer = new EmptyVizComponent();
        public InteractiveColorLegend ActuallColorLegend = new InteractiveColorLegend();

        public ColorMap MainColorMap { get; set; }
        public ColorMap DisabledColorMap { get; set; }
        public ColorMap RedColorMap { get; set; }

        public Color EdgeColor6 { get; set; }
        public Color EdgeColor5 { get; set; }
        public Color EdgeColor4 { get; set; }
        public Color EdgeColor3 { get; set; }
        public Color EdgeColor2 { get; set; }
        public Color EdgeColor1 { get; set; }

        public Color SelectionColor { get; set; }

        List<float> _initalEdgeValues;

        public ColorMapHandler(MainWindow mainWindow) : base(mainWindow)
        {
            init();
        }

        public void init()
        {
            // set colors
            EdgeColor1 = Color.FromArgb(255, 50, 0);
            EdgeColor2 = Color.FromArgb(255, 140, 0);
            EdgeColor3 = Color.FromArgb(255, 230, 20);
            EdgeColor4 = Color.FromArgb(170, 200, 255);
            EdgeColor5 = Color.FromArgb(75, 140, 255);
            EdgeColor6 = Color.FromArgb(50, 50, 255);
            SelectionColor = Color.FromArgb(10, 174, 100);

            //Manage the color map
            _initalEdgeValues = new List<float>();
            _initalEdgeValues.Add(0.25f);
            _initalEdgeValues.Add(0.5f);
            _initalEdgeValues.Add(0.75f);

            MainColorMap = new ColorMap();
            MainColorMap.AddColorMapPart(new LinearRgbColorMapPart(EdgeColor6, EdgeColor5));
            MainColorMap.AddColorMapPart(new LinearRgbColorMapPart(EdgeColor5, EdgeColor4));
            MainColorMap.AddColorMapPart(new LinearRgbColorMapPart(EdgeColor3, EdgeColor2));
            MainColorMap.AddColorMapPart(new LinearRgbColorMapPart(EdgeColor2, EdgeColor1));
            MainColorMap.SetEdgeValues(_initalEdgeValues);
            MainColorMap.NaNColor = Color.LightGray;

            DisabledColorMap = new ColorMap();
            DisabledColorMap.AddColorMapPart(new LinearRgbColorMapPart(Color.Gray, Color.Gray));
            DisabledColorMap.NaNColor = Color.Gray;
            DisabledColorMap.Input = _mainWindow.DataHandler.MainDataCubeProvider;

            RedColorMap = new ColorMap();
            RedColorMap.AddColorMapPart(new LinearRgbColorMapPart(Color.OrangeRed, Color.Red));
            RedColorMap.NaNColor = Color.Red;
            RedColorMap.Input = _mainWindow.DataHandler.MainDataCubeProvider;

            MainColorMap.Index = 0;
            MainColorMap.Input = _mainWindow.DataHandler.MainDataCubeProvider;


            // Set up color legend
            ActuallColorLegend.ColorMap = MainColorMap;
            ActuallColorLegend.Enabled = true;
            ActuallColorLegend.SetLegendSize(_mainWindow.getColorLegendPanel().Size.Width, _mainWindow.getColorLegendPanel().Size.Height);
            ActuallColorLegend.EdgeValues = MainColorMap.GetEdgeValues();
            ActuallColorLegend.SetEdgeSliderPosition(InteractiveColorLegend.SliderLinePosition.RightOrBottom);
            ActuallColorLegend.ShowColorEdgeSliderValue = true;
            ActuallColorLegend.ShowColorEdgeSliders = true;
            

            ActuallColorLegend.SetEdgeSliderTextPosition(InteractiveColorLegend.TextPosition.RightOrBottom);
            
            ActuallColorLegend.ColorEdgeValuesChanged += new EventHandler(_actualColorLegend_ColorEdgeValuesChanged);
            _mainWindow.colorLegendReset.Click += new EventHandler(colorLegendReset_Click);
            
            ColorLegendContainer.AddSubComponent(ActuallColorLegend);
            ColorLegendContainer.Enabled = true;

            _mainWindow.ViewManager.Add(ColorLegendContainer, _mainWindow.getColorLegendPanel());
        }

        void colorLegendReset_Click(object sender, EventArgs e)
        {
            MainColorMap.SetEdgeValues(_initalEdgeValues);
            ActuallColorLegend.EdgeValues = MainColorMap.GetEdgeValues();
            _mainWindow.ViewManager.InvalidateAll();
        }

        void _actualColorLegend_ColorEdgeValuesChanged(object sender, EventArgs e)
        {
            _mainWindow.ColorMapHandler.MainColorMap.SetEdgeValues(ActuallColorLegend.EdgeValuesList);
            UpdateColorLegendLabels();
            _mainWindow.ViewManager.InvalidateAll();
        }

        public void UpdateColorLegendLabels()
        {
            float maxValue = _mainWindow.PCHandler.VariablePCAxisMaxList[_mainWindow.PCHandler._pcPlotVariables.HeaderLayer.SelectedHeadersList[0]];
            float minValue = _mainWindow.PCHandler.VariablePCAxisMinList[_mainWindow.PCHandler._pcPlotVariables.HeaderLayer.SelectedHeadersList[0]];
            float relativeValue = maxValue - minValue;

            _mainWindow.colorLegendLabelTop.Text = (ActuallColorLegend.EdgeValues[2] * relativeValue + minValue).ToString();
            _mainWindow.colorLegendLabelCenter.Text = (ActuallColorLegend.EdgeValues[1] * relativeValue + minValue).ToString();
            _mainWindow.colorLegendLabelBottom.Text = (ActuallColorLegend.EdgeValues[0] * relativeValue + minValue).ToString();

        }
    }
}
