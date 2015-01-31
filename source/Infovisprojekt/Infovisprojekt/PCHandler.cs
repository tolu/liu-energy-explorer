using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Gav.Components.MapLayers;
using Gav.Components;
using Gav.Components.Internal;
using Gav.Data;
using Gav.Management;
using Gav.Graphics;

namespace Infovizprojekt
{
    public class PCHandler : BaseHandler
    {
        public ParallelCoordinatesPlot _pcPlotVariables = new ParallelCoordinatesPlot();
        public ParallelCoordinatesPlot _pcPlotYears = new ParallelCoordinatesPlot();
        
        GavToolTip _gavToolTip;
        MouseHoverController _hoverControllerVar;
        MouseHoverController _hoverControllerYear;

        bool _filteringChanged = false;

        public List<float> VariablePCAxisMinList { get; set; }
        public List<float> VariablePCAxisMaxList { get; set; }

        List<float> _currentVariablePCAxisMinList;
        List<float> _currentVariablePCAxisMaxList;

        public bool UsingKMeans = false;

        private string _interpolationColMarker = "(i)";

        Color _axisColorZoomed = Color.FromArgb(10, 174, 100);
        Color _axisColorInterpolated = Color.FromArgb(120, 0, 0);
        Color _axisColorNormal = Color.FromArgb(40, 40, 40);

        List<Color> _axisColors;

        public PCHandler(MainWindow mainWindow) : base(mainWindow)
        {
            init();
        }

        public void init()
        {
            //Manage the parallel coordinates plots
            _pcPlotVariables.Input = _mainWindow.DataHandler.MainDataCubeProvider;
            
            // mark the columns that can be interpolated
            IList<string> colHeaders = _mainWindow.DataHandler.getColumnHeaders();
            List<string> markedHeaders = new List<string>();
            for (int i = 0; i < colHeaders.Count; i++)
            {
                if (_mainWindow.DataHandler.InterpolationCols.Contains(i))
                {
                    markedHeaders.Add(String.Concat(colHeaders[i], _interpolationColMarker));
                }
                else
                {
                    markedHeaders.Add(colHeaders[i]);
                }
            }
            _pcPlotVariables.Headers = markedHeaders;

            _resetVarPCAxisColors();
            _pcPlotVariables.HeaderLayer.SelectedHeadersList.Add(MainWindow.PC_VAR_PLOT_INIT_VALUE);
            _pcPlotVariables.MarginRight = 35;

            _pcPlotYears.Input = _mainWindow.DataHandler.YearDataCubeProvider;
            _pcPlotYears.Headers = _mainWindow.DataHandler.getYearsAsList();
            _pcPlotYears.MarginRight = 35;
            _mainWindow.DataHandler.YearDataCubeProvider.VarIndex = MainWindow.PC_YEARS_PLOT_INIT_VALUE;
            SetMinMaxYearPC();
              
            _pcPlotVariables.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;
            _pcPlotYears.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;
            
            _mainWindow.yearSlider.Minimum = 0;
            _mainWindow.yearSlider.Maximum = DataHandler.EndYear - DataHandler.StartYear;
            _mainWindow.yearSlider.TickFrequency = 1;
            _mainWindow.yearSlider.Value = 0;

            UpdateVariablePCAxisList();

            // add to SAP manager
            _mainWindow.SaPManager.AddComponent(_pcPlotVariables);
            _mainWindow.SaPManager.AddComponent(_pcPlotYears);

            // add tooltip to pc plt
            _gavToolTip = new Gav.Management.GavToolTip(_mainWindow);
            _gavToolTip.FadeTime = 150;

            // mouse controllers
            _hoverControllerVar = new MouseHoverController(_mainWindow.getPCPanelVariables(), 1, 50);
            _hoverControllerYear = new MouseHoverController(_mainWindow.getPCPanelYears(), 1, 50);

            // dont know why I´m doing this but it makes the tooltip show at correct location the first time its called
            _gavToolTip.Show(new System.Drawing.Point(1,1));
            _gavToolTip.Hide();

            // index visibility manager
            _pcPlotVariables.IndexVisibilityManager = _mainWindow.SharedVisibilityManager;
            _pcPlotYears.IndexVisibilityManager = _mainWindow.SharedVisibilityManager;

            // selection color
            _pcPlotVariables.LineLayer.SelectedLineColor = _mainWindow.ColorMapHandler.SelectionColor;
            _pcPlotYears.LineLayer.SelectedLineColor = _mainWindow.ColorMapHandler.SelectionColor;
            
           // listeners
            _pcPlotVariables.HeaderClicked += new EventHandler<Gav.Event.IndexClickedEventArgs>(_pcPlotVariables_HeaderClicked);
            _pcPlotVariables.FilterChanged += new EventHandler(_pcPlotVariables_FilterChanged);
            _pcPlotYears.FilterChanged += new EventHandler(_pcPlotYears_FilterChanged);
            _pcPlotVariables.ComponentMouseUp += new EventHandler<System.Windows.Forms.MouseEventArgs>(_pcPlotVariables_ComponentMouseUp);
            _pcPlotYears.ComponentMouseUp += new EventHandler<System.Windows.Forms.MouseEventArgs>(_pcPlotYears_ComponentMouseUp);
            _mainWindow.yearSlider.ValueChanged += new EventHandler(yearSlider_ValueChanged);
            _hoverControllerVar.Hover += new EventHandler(_hoverController_Hover_Var);
            _hoverControllerYear.Hover += new EventHandler(_hoverController_Hover_Year);
            _hoverControllerVar.HoverEnd += new EventHandler(_hoverController_HoverEnd_Var);
            _hoverControllerYear.HoverEnd += new EventHandler(_hoverController_HoverEnd_Year);
            _pcPlotYears.Input.Changed += new EventHandler(_pcPlotYears_Input_Changed);
            _pcPlotVariables.Input.Changed += new EventHandler(_pcPlotVariables_Input_Changed);

            _mainWindow.varPCReset.Click += new EventHandler(varPCReset_Click);
            _mainWindow.yearPCReset.Click += new EventHandler(yearPCReset_Click);

            _mainWindow.ShowClustersCheckbox.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
            _mainWindow.numberofClusters.ValueChanged += new System.EventHandler(numberofClusters_ValueChanged);

            _mainWindow.varPCColZoomIn.Click += new EventHandler(varPCZoomIn_Click);
            _mainWindow.varPCColResetZoom.Click += new EventHandler(varPCZoomOut_Click);


            // add to view manager
            _mainWindow.ViewManager.Add(_pcPlotVariables, _mainWindow.getPCPanelVariables());
            _mainWindow.ViewManager.Add(_pcPlotYears, _mainWindow.getPCPanelYears());
        }

        void _resetVarPCAxisColors()
        {
            _axisColors = new List<Color>(_pcPlotVariables.Headers.Count);

            for (int i = 0; i < _axisColors.Capacity; i++)
            {
                if (_mainWindow.DataHandler.InterpolationCols.Contains(i) && _mainWindow.interpolationCheckBox.Checked)
                {
                    _axisColors.Add(_axisColorInterpolated);
                }
                else
                {
                    _axisColors.Add(_axisColorNormal);
                }
            }

            _pcPlotVariables.AxisLayer.AxisColors = _axisColors;
            _pcPlotVariables.Invalidate();
        }

        void varPCZoomIn_Click(object sender, EventArgs e)
        {
            int axisIdx = _pcPlotVariables.HeaderLayer.SelectedHeadersList[0];

            List<float> upperSliderPositions = _pcPlotVariables.FilterLayer.GetUpperSliderPositions();
            List<float> lowerSliderPositions = _pcPlotVariables.FilterLayer.GetLowerSliderPositions();

            float upperPosition = upperSliderPositions[axisIdx];
            float lowerPosition = lowerSliderPositions[axisIdx];

            _currentVariablePCAxisMinList[axisIdx] = (_currentVariablePCAxisMaxList[axisIdx] - _currentVariablePCAxisMinList[axisIdx]) * lowerPosition + _currentVariablePCAxisMinList[axisIdx];
            _currentVariablePCAxisMaxList[axisIdx] = _currentVariablePCAxisMaxList[axisIdx] * upperPosition;

            _axisColors = _pcPlotVariables.AxisLayer.AxisColors;
            _axisColors[axisIdx] = _axisColorZoomed;
            _pcPlotVariables.AxisLayer.AxisColors = _axisColors;

            upperSliderPositions[axisIdx] = 1;
            lowerSliderPositions[axisIdx] = 0;

            _pcPlotVariables.FilterLayer.SetUpperSliderPositions(upperSliderPositions);
            _pcPlotVariables.FilterLayer.SetLowerSliderPositions(lowerSliderPositions);

            SetMinMaxVariablesPC();

            _pcPlotVariables.FilterLayer.Filter();

            _pcPlotVariables.Invalidate();
        }

        void varPCZoomOut_Click(object sender, EventArgs e)
        {
            int axisIdx = _pcPlotVariables.HeaderLayer.SelectedHeadersList[0];

            List<float> upperSliderPositions = _pcPlotVariables.FilterLayer.GetUpperSliderPositions();
            List<float> lowerSliderPositions = _pcPlotVariables.FilterLayer.GetLowerSliderPositions();

            _currentVariablePCAxisMinList[axisIdx] = VariablePCAxisMinList[axisIdx];
            _currentVariablePCAxisMaxList[axisIdx] = VariablePCAxisMaxList[axisIdx];

            _axisColors = _pcPlotVariables.AxisLayer.AxisColors;
            _axisColors[axisIdx] = _axisColorNormal;
            _pcPlotVariables.AxisLayer.AxisColors = _axisColors;

            upperSliderPositions[axisIdx] = 1;
            lowerSliderPositions[axisIdx] = 0;

            _pcPlotVariables.FilterLayer.SetUpperSliderPositions(upperSliderPositions);
            _pcPlotVariables.FilterLayer.SetLowerSliderPositions(lowerSliderPositions);

            SetMinMaxVariablesPC();

            _pcPlotVariables.FilterLayer.Filter();

            _pcPlotVariables.Invalidate();
        }

        void yearPCReset_Click(object sender, EventArgs e)
        {
            _pcPlotYears.ResetFiltering();
            _mainWindow.ViewManager.InvalidateAll();
        }

        void varPCReset_Click(object sender, EventArgs e)
        {
            _resetVarPCAxisColors();
            UpdateVariablePCAxisList();
            SetMinMaxVariablesPC();
            _pcPlotVariables.ResetFiltering();
            _pcPlotVariables.FilterLayer.Filter();
            _mainWindow.ViewManager.InvalidateAll();
        }

        public void UpdateVariablePCAxisList()
        {
            List<float> minList = new List<float>();
            List<float> maxList = new List<float>();

            _mainWindow.DataHandler.MainDataCubeProvider.GetDataCube().GetAllColumnMaxMin(out maxList, out minList);

            VariablePCAxisMinList = minList;
            VariablePCAxisMaxList = maxList;

            minList = new List<float>();
            maxList = new List<float>();

            _mainWindow.DataHandler.MainDataCubeProvider.GetDataCube().GetAllColumnMaxMin(out maxList, out minList);

            _currentVariablePCAxisMinList = minList;
            _currentVariablePCAxisMaxList = maxList;
        }

        public int TryPCVariableAxisMapping(int axisIndex)
        {
            IList<IPCAxis> pcaxis = _pcPlotVariables.Model.GetAxes();
            int idx = _pcPlotVariables.Model.GetOrderIndex(pcaxis[axisIndex]);            
            return idx;
        }
        
        void _pcPlotYears_ComponentMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_filteringChanged)
            {
                _mainWindow.MapHandler._mainChoroplethMap.Invalidate();
                _filteringChanged = true;
            }
        }

        void _pcPlotVariables_ComponentMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _pcPlotYears_ComponentMouseUp(sender, e);
        }

        void _pcPlotYears_FilterChanged(object sender, EventArgs e)
        {
            _mainWindow.PlotHandler._scatterplot.Invalidate();
            _mainWindow.PlotHandler._tableLens.Invalidate();
            _pcPlotVariables.Invalidate();
            _mainWindow.PlotHandler.InvalidateTableLens();
            _filteringChanged = true;
        }

        void _pcPlotVariables_FilterChanged(object sender, EventArgs e)
        {
            _pcPlotYears_FilterChanged(sender, e);
            _pcPlotYears.Invalidate();
        }

        public void SetMinMaxVariablesPC()
        {
            _pcPlotVariables.Enabled = false;
            for (int i = 0; i < _currentVariablePCAxisMinList.Count; i++)
            {
                _pcPlotVariables.SetAxisMaxMin(i, _currentVariablePCAxisMaxList[i], _currentVariablePCAxisMinList[i]);
            }
            _pcPlotVariables.Enabled = true;
        }
        
        void _hoverController_HoverEnd_Var(object sender, EventArgs e)
        {
            _gavToolTip.Hide();
        }
        void _hoverController_HoverEnd_Year(object sender, EventArgs e)
        {
            _gavToolTip.Hide();
        }

        //show tooltip when hovering over line in Variable plot
        void _hoverController_Hover_Var(object sender, EventArgs e)
        {
            if (!UsingKMeans)
            {
                int x = _hoverControllerVar.HoverScreenPosition.X;
                int y = _hoverControllerVar.HoverScreenPosition.Y;
                System.Drawing.Point mousePos = _hoverControllerVar.HoverPosition;

                //get country id
                int[] countryList = _pcPlotVariables.GetLineIndexesAtPosition(mousePos, 2).ToArray();
                //check if country is hidden
                int country = -1;
                if (countryList.Length > 0)
                {
                    for (int i = 0; i < countryList.Length; i++)
                    {
                        if (_pcPlotVariables.IndexVisibilityManager.GetVisibility(countryList[i]))
                        {
                            country = countryList[i];
                            break;
                        }
                    }
                }
                if (country > -1)
                {
                    //init tooltip
                    String tooltip = _mainWindow.DataHandler.RawDataProvider.NaNColumns[0][0][country].ToString();

                    // where to draw tooltip
                    //System.Drawing.Point atThisLocation = new System.Drawing.Point(_hoverControllerVar.HoverScreenPosition.X - 3, _hoverControllerVar.HoverScreenPosition.Y - 3);

                    //get current year
                    int year = _mainWindow.yearSlider.Value;
                    //loop over info to show in tooltip
                    for (int i = 0; i < _mainWindow.DataHandler.RawDataProvider.ColumnHeaders.Count; i++)
                    {
                        tooltip += "\n" + _mainWindow.DataHandler.RawDataProvider.ColumnHeaders[i];
                        tooltip += "   " + _mainWindow.DataHandler.getValueFromDataCube(i, country, year);
                    }
                    _gavToolTip.Text = tooltip;
                    _gavToolTip.Show(new System.Drawing.Point(x-5, y-5));
                }

                //tooltip for header names, funkar inte nu
                /*
                int header = _pcPlotVariables.AxisLayer.AxisAtPosition(new System.Drawing.Point(mousePos.X, mousePos.Y + 40), 5);
                if (header != -1)
                {
                    _gavToolTip.Text = _mainWindow.DataHandler.RawDataProvider.ColumnHeaders[header];
                    _gavToolTip.Show(new System.Drawing.Point(x,y));
                }
                */
            }
            
        }
        //show tooltip when hovering over line in Years plot
        void _hoverController_Hover_Year(object sender, EventArgs e)
        {
            if (!UsingKMeans)
            {
                //get country id
                int[] countryList = _pcPlotYears.GetLineIndexesAtPosition(_hoverControllerYear.HoverPosition, 2).ToArray();
                //check if country is hidden
                int country = -1;
                if (countryList.Length > 0)
                {
                    for (int i = 0; i < countryList.Length; i++)
                    {
                        if (_pcPlotYears.IndexVisibilityManager.GetVisibility(countryList[i]))
                        {
                            country = countryList[i];
                            break;
                        }
                    }
                }
                if (country > -1)
                {
                    //init tooltip
                    String tooltip = _mainWindow.DataHandler.RawDataProvider.NaNColumns[0][0][country].ToString();
                    // if no header has been selected set to zero
                    int selectedHeader;
                    if (_pcPlotVariables.HeaderLayer.SelectedHeadersList.Count > 0)
                    {
                        selectedHeader = _pcPlotVariables.HeaderLayer.SelectedHeadersList[0];
                    }
                    else
                    {
                        selectedHeader = 0;
                    }
                    // add header to tooltip
                    tooltip += ":  " + _mainWindow.DataHandler.RawDataProvider.ColumnHeaders[selectedHeader];
                    //loop over all years for the selected variable
                    for (int year = 0; year < _mainWindow.DataHandler.RawDataProvider.GetDataCube().DataArray.GetLength(2); year++)
                    {   
                        tooltip += "\n" + (year + 1990) + "   " + _mainWindow.DataHandler.getValueFromDataCube(selectedHeader, country, year);
                    }
                    _gavToolTip.Text = tooltip;
                    _gavToolTip.Show(_hoverControllerYear.HoverScreenPosition);
                }
            }
        }

        void _pcPlotVariables_HeaderClicked(object sender, Gav.Event.IndexClickedEventArgs e)
        {
            _pcPlotYears.Enabled = false;
            _mainWindow.DataHandler.YearDataCubeProvider.VarIndex = TryPCVariableAxisMapping(e.IndexClicked);
            _mainWindow.DataHandler.YearDataCubeProvider.CommitChanges();
            SetMinMaxYearPC();
            _pcPlotYears.Enabled = true;

            _mainWindow.ColorMapHandler.MainColorMap.Index = TryPCVariableAxisMapping(e.IndexClicked);
            _mainWindow.ColorMapHandler.MainColorMap.Invalidate();

            _pcPlotVariables.HeaderLayer.SelectedHeadersList.Clear();
            _pcPlotVariables.HeaderLayer.SelectedHeadersList.Add(TryPCVariableAxisMapping(e.IndexClicked));

            _mainWindow.ColorMapHandler.UpdateColorLegendLabels();
            _mainWindow.ViewManager.InvalidateAll();
        }

        void yearSlider_ValueChanged(object sender, EventArgs e)
        {
            _pcPlotVariables.Enabled = false;
            _pcPlotYears.Enabled = false;

            _mainWindow.DataHandler.MainDataCubeProvider.Slice = (int) _mainWindow.yearSlider.Value;
            _mainWindow.DataHandler.MainDataCubeProvider.CommitChanges();

            _pcPlotVariables.Enabled = true;
            _pcPlotYears.Enabled = true;

            _pcPlotYears.HeaderLayer.SelectedHeadersList.Clear();
            _pcPlotYears.HeaderLayer.SelectedHeadersList.Add(_mainWindow.yearSlider.Value);

            _mainWindow.SelectedYear.Text = (_mainWindow.yearSlider.Value + 1990).ToString();

            _mainWindow.ViewManager.InvalidateAll();
        }

        private void numberofClusters_ValueChanged(object sender, EventArgs e)
        {
            if (UsingKMeans)
            {
                _pcPlotVariables.Enabled = false;
                _pcPlotYears.Enabled = false;

                _mainWindow.DataHandler.KMeansDataCubeProvider.K = (int) _mainWindow.numberofClusters.Value;
                _mainWindow.DataHandler.KMeansDataCubeProvider.CommitChanges();

                _mainWindow.DataHandler.KMeansForYearsProvider.K = (int) _mainWindow.numberofClusters.Value;
                _mainWindow.DataHandler.KMeansForYearsProvider.CommitChanges();

                SetMinMaxVariablesPC();
                SetMinMaxYearPC();

                _pcPlotVariables.Enabled = true;
                _pcPlotYears.Enabled = true;

                _mainWindow.ViewManager.InvalidateAll();
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow.ShowClustersCheckbox.Checked)
            {
                UsingKMeans = true;

                _mainWindow.varPCColResetZoom.Hide();
                _mainWindow.varPCColZoomIn.Hide();

                _resetVarPCAxisColors();
                UpdateVariablePCAxisList();
                SetMinMaxVariablesPC();
                _pcPlotVariables.ResetFiltering();
                _pcPlotVariables.FilterLayer.Filter();

                _pcPlotVariables.Enabled = false;
                _pcPlotYears.Enabled = false;

                _mainWindow.DataHandler.KMeansDataCubeProvider.K = (int)_mainWindow.numberofClusters.Value;
                _mainWindow.DataHandler.KMeansDataCubeProvider.CommitChanges();
                
                _pcPlotVariables.Input = _mainWindow.DataHandler.KMeansDataCubeProvider.centroidCube;
                _mainWindow.ColorMapHandler.RedColorMap.Input = _mainWindow.DataHandler.KMeansDataCubeProvider.centroidCube;
                _pcPlotVariables.ColorMap = _mainWindow.ColorMapHandler.RedColorMap;
                
                _mainWindow.DataHandler.KMeansForYearsProvider.K = (int)_mainWindow.numberofClusters.Value;
                _mainWindow.DataHandler.KMeansForYearsProvider.CommitChanges();

                _pcPlotYears.Input = _mainWindow.DataHandler.KMeansForYearsProvider.centroidCube;
                _pcPlotYears.ColorMap = _mainWindow.ColorMapHandler.RedColorMap;
                
                SetMinMaxVariablesPC();
                SetMinMaxYearPC();

                _pcPlotVariables.Enabled = true;
                _pcPlotYears.Enabled = true;

                _mainWindow.ViewManager.InvalidateAll();
            }
            else
            {
                _pcPlotVariables.Enabled = false;
                _pcPlotYears.Enabled = false;

                _mainWindow.varPCColResetZoom.Show();
                _mainWindow.varPCColZoomIn.Show();

                UsingKMeans = false;

                _pcPlotVariables.Input = _mainWindow.DataHandler.MainDataCubeProvider;
                _pcPlotVariables.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;

                _pcPlotYears.Input = _mainWindow.DataHandler.YearDataCubeProvider;
                _pcPlotYears.ColorMap = _mainWindow.ColorMapHandler.MainColorMap;

                SetMinMaxVariablesPC();
                SetMinMaxYearPC();

                _pcPlotVariables.Enabled = true;
                _pcPlotYears.Enabled = true;

                _mainWindow.ViewManager.InvalidateAll();
            }
        }

        public void SetMinMaxYearPC()
        {
            
            List<float> minList = new List<float>();
            List<float> maxList = new List<float>();

            _mainWindow.DataHandler.YearDataCubeProvider.GetDataCube().GetAllColumnMaxMin(out maxList, out minList);

            float min = minList.Min();
            float max = maxList.Max();

            for (int i = 0; i < _mainWindow.DataHandler.YearDataCubeProvider.GetDataCube().GetAxisLength(Axis.X); i++)
            {
                _pcPlotYears.SetAxisMaxMin(i, max, min);
            }
        }

        void _pcPlotYears_Input_Changed(object sender, EventArgs e)
        {
            SetMinMaxYearPC();
        }

        void _pcPlotVariables_Input_Changed(object sender, EventArgs e)
        {
            _resetVarPCAxisColors();
            UpdateVariablePCAxisList();
            SetMinMaxVariablesPC();
            _pcPlotVariables.ResetFiltering();
            _pcPlotVariables.FilterLayer.Filter();
            _mainWindow.ViewManager.InvalidateAll();
        }
    }
}
