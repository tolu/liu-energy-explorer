namespace Infovizprojekt
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.topSplitContainer = new System.Windows.Forms.SplitContainer();
            this.colorLegendReset = new System.Windows.Forms.Button();
            this.mapReset = new System.Windows.Forms.Button();
            this.colorLegendLabelBottom = new System.Windows.Forms.Label();
            this.colorLegendLabelTop = new System.Windows.Forms.Label();
            this.colorLegendLabelCenter = new System.Windows.Forms.Label();
            this.colorLegendPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.xAxisLabel = new System.Windows.Forms.Label();
            this.yAxisLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.pcPlotSplitContainer = new System.Windows.Forms.SplitContainer();
            this.pcVariablePanel = new System.Windows.Forms.Panel();
            this.varPCColResetZoom = new System.Windows.Forms.Button();
            this.varPCReset = new System.Windows.Forms.Button();
            this.varPCColZoomIn = new System.Windows.Forms.Button();
            this.pcYearPanel = new System.Windows.Forms.Panel();
            this.yearPCReset = new System.Windows.Forms.Button();
            this.alphaLabel1 = new System.Windows.Forms.Label();
            this.YearLowEndLabel = new System.Windows.Forms.Label();
            this.YearHighEndLabel = new System.Windows.Forms.Label();
            this.lineGlyphAlpha = new System.Windows.Forms.NumericUpDown();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.InterpolationTitle = new System.Windows.Forms.Label();
            this.interpolationCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowClustersCheckbox = new System.Windows.Forms.CheckBox();
            this.ClustersLabel = new System.Windows.Forms.Label();
            this.playTimeButton = new System.Windows.Forms.Button();
            this.ScatterYaxisValuesSelector = new System.Windows.Forms.ComboBox();
            this.numberofClusters = new System.Windows.Forms.NumericUpDown();
            this.ScatterXaxisValuesSelector = new System.Windows.Forms.ComboBox();
            this.yAxisSelectorLabel = new System.Windows.Forms.Label();
            this.sizeSelectorLabel = new System.Windows.Forms.Label();
            this.kMeansTitle = new System.Windows.Forms.Label();
            this.ScatterSizeSelector = new System.Windows.Forms.ComboBox();
            this.xAxisSelectorLabel = new System.Windows.Forms.Label();
            this.YearSelectionTitle = new System.Windows.Forms.Label();
            this.yearSlider = new System.Windows.Forms.TrackBar();
            this.SelectedYear = new System.Windows.Forms.Label();
            this.ScatterControlTitle = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.SelectedYearLabel = new System.Windows.Forms.Label();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.topSplitContainer.Panel1.SuspendLayout();
            this.topSplitContainer.Panel2.SuspendLayout();
            this.topSplitContainer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.bottomSplitContainer.Panel1.SuspendLayout();
            this.bottomSplitContainer.Panel2.SuspendLayout();
            this.bottomSplitContainer.SuspendLayout();
            this.pcPlotSplitContainer.Panel1.SuspendLayout();
            this.pcPlotSplitContainer.Panel2.SuspendLayout();
            this.pcPlotSplitContainer.SuspendLayout();
            this.pcVariablePanel.SuspendLayout();
            this.pcYearPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineGlyphAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.CausesValidation = false;
            this.mainSplitContainer.Panel1.Controls.Add(this.topSplitContainer);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.mainSplitContainer.Panel2.Controls.Add(this.bottomSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(1269, 708);
            this.mainSplitContainer.SplitterDistance = 393;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // topSplitContainer
            // 
            this.topSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.topSplitContainer.Name = "topSplitContainer";
            // 
            // topSplitContainer.Panel1
            // 
            this.topSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.topSplitContainer.Panel1.Controls.Add(this.colorLegendReset);
            this.topSplitContainer.Panel1.Controls.Add(this.mapReset);
            this.topSplitContainer.Panel1.Controls.Add(this.colorLegendLabelBottom);
            this.topSplitContainer.Panel1.Controls.Add(this.colorLegendLabelTop);
            this.topSplitContainer.Panel1.Controls.Add(this.colorLegendLabelCenter);
            this.topSplitContainer.Panel1.Controls.Add(this.colorLegendPanel);
            // 
            // topSplitContainer.Panel2
            // 
            this.topSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.topSplitContainer.Panel2.Controls.Add(this.tabControl1);
            this.topSplitContainer.Size = new System.Drawing.Size(1269, 393);
            this.topSplitContainer.SplitterDistance = 827;
            this.topSplitContainer.TabIndex = 0;
            // 
            // colorLegendReset
            // 
            this.colorLegendReset.BackColor = System.Drawing.Color.LightGray;
            this.colorLegendReset.Location = new System.Drawing.Point(7, 330);
            this.colorLegendReset.Margin = new System.Windows.Forms.Padding(2);
            this.colorLegendReset.Name = "colorLegendReset";
            this.colorLegendReset.Size = new System.Drawing.Size(20, 20);
            this.colorLegendReset.TabIndex = 6;
            this.colorLegendReset.Text = "R";
            this.colorLegendReset.UseVisualStyleBackColor = false;
            this.colorLegendReset.MouseHover += new System.EventHandler(this.colorLegendReset_MouseHover);
            // 
            // mapReset
            // 
            this.mapReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapReset.BackColor = System.Drawing.Color.LightGray;
            this.mapReset.Location = new System.Drawing.Point(801, 6);
            this.mapReset.Margin = new System.Windows.Forms.Padding(2);
            this.mapReset.Name = "mapReset";
            this.mapReset.Size = new System.Drawing.Size(20, 20);
            this.mapReset.TabIndex = 5;
            this.mapReset.Text = "R";
            this.mapReset.UseVisualStyleBackColor = false;
            this.mapReset.MouseHover += new System.EventHandler(this.mapReset_MouseHover);
            // 
            // colorLegendLabelBottom
            // 
            this.colorLegendLabelBottom.AutoSize = true;
            this.colorLegendLabelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLegendLabelBottom.Location = new System.Drawing.Point(27, 275);
            this.colorLegendLabelBottom.Name = "colorLegendLabelBottom";
            this.colorLegendLabelBottom.Size = new System.Drawing.Size(37, 15);
            this.colorLegendLabelBottom.TabIndex = 3;
            this.colorLegendLabelBottom.Text = "label1";
            // 
            // colorLegendLabelTop
            // 
            this.colorLegendLabelTop.AutoSize = true;
            this.colorLegendLabelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLegendLabelTop.Location = new System.Drawing.Point(27, 60);
            this.colorLegendLabelTop.Name = "colorLegendLabelTop";
            this.colorLegendLabelTop.Size = new System.Drawing.Size(37, 15);
            this.colorLegendLabelTop.TabIndex = 2;
            this.colorLegendLabelTop.Text = "label1";
            // 
            // colorLegendLabelCenter
            // 
            this.colorLegendLabelCenter.AutoSize = true;
            this.colorLegendLabelCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLegendLabelCenter.Location = new System.Drawing.Point(27, 163);
            this.colorLegendLabelCenter.Name = "colorLegendLabelCenter";
            this.colorLegendLabelCenter.Size = new System.Drawing.Size(37, 15);
            this.colorLegendLabelCenter.TabIndex = 1;
            this.colorLegendLabelCenter.Text = "label1";
            // 
            // colorLegendPanel
            // 
            this.colorLegendPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLegendPanel.Location = new System.Drawing.Point(12, 22);
            this.colorLegendPanel.Name = "colorLegendPanel";
            this.colorLegendPanel.Size = new System.Drawing.Size(9, 303);
            this.colorLegendPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 393);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.xAxisLabel);
            this.tabPage1.Controls.Add(this.yAxisLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scatter Plot";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // xAxisLabel
            // 
            this.xAxisLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xAxisLabel.AutoSize = true;
            this.xAxisLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xAxisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xAxisLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.xAxisLabel.Location = new System.Drawing.Point(162, 325);
            this.xAxisLabel.Name = "xAxisLabel";
            this.xAxisLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xAxisLabel.Size = new System.Drawing.Size(101, 20);
            this.xAxisLabel.TabIndex = 4;
            this.xAxisLabel.Text = "X-axis label";
            // 
            // yAxisLabel
            // 
            this.yAxisLabel.AutoSize = true;
            this.yAxisLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.yAxisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yAxisLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.yAxisLabel.Location = new System.Drawing.Point(6, 3);
            this.yAxisLabel.Name = "yAxisLabel";
            this.yAxisLabel.Size = new System.Drawing.Size(101, 20);
            this.yAxisLabel.TabIndex = 5;
            this.yAxisLabel.Text = "Y-axis label";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Table Lens";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bottomSplitContainer
            // 
            this.bottomSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.bottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.bottomSplitContainer.Name = "bottomSplitContainer";
            // 
            // bottomSplitContainer.Panel1
            // 
            this.bottomSplitContainer.Panel1.Controls.Add(this.pcPlotSplitContainer);
            // 
            // bottomSplitContainer.Panel2
            // 
            this.bottomSplitContainer.Panel2.Controls.Add(this.alphaLabel1);
            this.bottomSplitContainer.Panel2.Controls.Add(this.YearLowEndLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.YearHighEndLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.lineGlyphAlpha);
            this.bottomSplitContainer.Panel2.Controls.Add(this.alphaLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.InterpolationTitle);
            this.bottomSplitContainer.Panel2.Controls.Add(this.interpolationCheckBox);
            this.bottomSplitContainer.Panel2.Controls.Add(this.ShowClustersCheckbox);
            this.bottomSplitContainer.Panel2.Controls.Add(this.ClustersLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.playTimeButton);
            this.bottomSplitContainer.Panel2.Controls.Add(this.ScatterYaxisValuesSelector);
            this.bottomSplitContainer.Panel2.Controls.Add(this.numberofClusters);
            this.bottomSplitContainer.Panel2.Controls.Add(this.ScatterXaxisValuesSelector);
            this.bottomSplitContainer.Panel2.Controls.Add(this.yAxisSelectorLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.sizeSelectorLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.kMeansTitle);
            this.bottomSplitContainer.Panel2.Controls.Add(this.ScatterSizeSelector);
            this.bottomSplitContainer.Panel2.Controls.Add(this.xAxisSelectorLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.YearSelectionTitle);
            this.bottomSplitContainer.Panel2.Controls.Add(this.yearSlider);
            this.bottomSplitContainer.Panel2.Controls.Add(this.SelectedYear);
            this.bottomSplitContainer.Panel2.Controls.Add(this.ScatterControlTitle);
            this.bottomSplitContainer.Panel2.Controls.Add(this.YearLabel);
            this.bottomSplitContainer.Panel2.Controls.Add(this.SelectedYearLabel);
            this.bottomSplitContainer.Size = new System.Drawing.Size(1269, 311);
            this.bottomSplitContainer.SplitterDistance = 896;
            this.bottomSplitContainer.TabIndex = 0;
            // 
            // pcPlotSplitContainer
            // 
            this.pcPlotSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcPlotSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcPlotSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.pcPlotSplitContainer.Name = "pcPlotSplitContainer";
            this.pcPlotSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pcPlotSplitContainer.Panel1
            // 
            this.pcPlotSplitContainer.Panel1.Controls.Add(this.pcVariablePanel);
            // 
            // pcPlotSplitContainer.Panel2
            // 
            this.pcPlotSplitContainer.Panel2.Controls.Add(this.pcYearPanel);
            this.pcPlotSplitContainer.Size = new System.Drawing.Size(896, 311);
            this.pcPlotSplitContainer.SplitterDistance = 150;
            this.pcPlotSplitContainer.TabIndex = 0;
            // 
            // pcVariablePanel
            // 
            this.pcVariablePanel.AutoSize = true;
            this.pcVariablePanel.Controls.Add(this.varPCColResetZoom);
            this.pcVariablePanel.Controls.Add(this.varPCReset);
            this.pcVariablePanel.Controls.Add(this.varPCColZoomIn);
            this.pcVariablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcVariablePanel.Location = new System.Drawing.Point(0, 0);
            this.pcVariablePanel.Name = "pcVariablePanel";
            this.pcVariablePanel.Size = new System.Drawing.Size(894, 148);
            this.pcVariablePanel.TabIndex = 1;
            // 
            // varPCColResetZoom
            // 
            this.varPCColResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.varPCColResetZoom.BackColor = System.Drawing.Color.LightGray;
            this.varPCColResetZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varPCColResetZoom.Location = new System.Drawing.Point(850, 83);
            this.varPCColResetZoom.Margin = new System.Windows.Forms.Padding(2);
            this.varPCColResetZoom.Name = "varPCColResetZoom";
            this.varPCColResetZoom.Size = new System.Drawing.Size(38, 20);
            this.varPCColResetZoom.TabIndex = 4;
            this.varPCColResetZoom.Text = "Reset";
            this.varPCColResetZoom.UseVisualStyleBackColor = false;
            // 
            // varPCReset
            // 
            this.varPCReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.varPCReset.BackColor = System.Drawing.Color.LightGray;
            this.varPCReset.Location = new System.Drawing.Point(868, 7);
            this.varPCReset.Margin = new System.Windows.Forms.Padding(2);
            this.varPCReset.Name = "varPCReset";
            this.varPCReset.Size = new System.Drawing.Size(20, 20);
            this.varPCReset.TabIndex = 2;
            this.varPCReset.Text = "R";
            this.varPCReset.UseVisualStyleBackColor = false;
            this.varPCReset.MouseHover += new System.EventHandler(this.varPCReset_MouseHover);
            // 
            // varPCColZoomIn
            // 
            this.varPCColZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.varPCColZoomIn.BackColor = System.Drawing.Color.LightGray;
            this.varPCColZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varPCColZoomIn.Location = new System.Drawing.Point(850, 59);
            this.varPCColZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.varPCColZoomIn.Name = "varPCColZoomIn";
            this.varPCColZoomIn.Size = new System.Drawing.Size(38, 20);
            this.varPCColZoomIn.TabIndex = 1;
            this.varPCColZoomIn.Text = "Zoom";
            this.varPCColZoomIn.UseVisualStyleBackColor = false;
            // 
            // pcYearPanel
            // 
            this.pcYearPanel.AutoSize = true;
            this.pcYearPanel.Controls.Add(this.yearPCReset);
            this.pcYearPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcYearPanel.Location = new System.Drawing.Point(0, 0);
            this.pcYearPanel.Name = "pcYearPanel";
            this.pcYearPanel.Size = new System.Drawing.Size(894, 155);
            this.pcYearPanel.TabIndex = 0;
            // 
            // yearPCReset
            // 
            this.yearPCReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearPCReset.BackColor = System.Drawing.Color.LightGray;
            this.yearPCReset.Location = new System.Drawing.Point(868, 8);
            this.yearPCReset.Margin = new System.Windows.Forms.Padding(2);
            this.yearPCReset.Name = "yearPCReset";
            this.yearPCReset.Size = new System.Drawing.Size(20, 20);
            this.yearPCReset.TabIndex = 5;
            this.yearPCReset.Text = "R";
            this.yearPCReset.UseVisualStyleBackColor = false;
            this.yearPCReset.MouseHover += new System.EventHandler(this.yearPCReset_MouseHover);
            // 
            // alphaLabel1
            // 
            this.alphaLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaLabel1.AutoSize = true;
            this.alphaLabel1.Location = new System.Drawing.Point(200, 158);
            this.alphaLabel1.Name = "alphaLabel1";
            this.alphaLabel1.Size = new System.Drawing.Size(43, 13);
            this.alphaLabel1.TabIndex = 27;
            this.alphaLabel1.Text = "Opacity";
            // 
            // YearLowEndLabel
            // 
            this.YearLowEndLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YearLowEndLabel.AutoSize = true;
            this.YearLowEndLabel.Location = new System.Drawing.Point(40, 281);
            this.YearLowEndLabel.Name = "YearLowEndLabel";
            this.YearLowEndLabel.Size = new System.Drawing.Size(31, 13);
            this.YearLowEndLabel.TabIndex = 8;
            this.YearLowEndLabel.Text = "1990";
            // 
            // YearHighEndLabel
            // 
            this.YearHighEndLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YearHighEndLabel.AutoSize = true;
            this.YearHighEndLabel.Location = new System.Drawing.Point(309, 281);
            this.YearHighEndLabel.Name = "YearHighEndLabel";
            this.YearHighEndLabel.Size = new System.Drawing.Size(31, 13);
            this.YearHighEndLabel.TabIndex = 9;
            this.YearHighEndLabel.Text = "2005";
            // 
            // lineGlyphAlpha
            // 
            this.lineGlyphAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineGlyphAlpha.Location = new System.Drawing.Point(254, 156);
            this.lineGlyphAlpha.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lineGlyphAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineGlyphAlpha.Name = "lineGlyphAlpha";
            this.lineGlyphAlpha.Size = new System.Drawing.Size(41, 20);
            this.lineGlyphAlpha.TabIndex = 26;
            this.lineGlyphAlpha.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // alphaLabel
            // 
            this.alphaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.alphaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.alphaLabel.Location = new System.Drawing.Point(197, 137);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(159, 17);
            this.alphaLabel.TabIndex = 25;
            this.alphaLabel.Text = "Line and Point Alpha";
            // 
            // InterpolationTitle
            // 
            this.InterpolationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InterpolationTitle.AutoSize = true;
            this.InterpolationTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InterpolationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterpolationTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.InterpolationTitle.Location = new System.Drawing.Point(197, 82);
            this.InterpolationTitle.Name = "InterpolationTitle";
            this.InterpolationTitle.Size = new System.Drawing.Size(147, 17);
            this.InterpolationTitle.TabIndex = 24;
            this.InterpolationTitle.Text = "Interpolated values";
            // 
            // interpolationCheckBox
            // 
            this.interpolationCheckBox.AutoSize = true;
            this.interpolationCheckBox.Checked = true;
            this.interpolationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.interpolationCheckBox.Location = new System.Drawing.Point(200, 107);
            this.interpolationCheckBox.Name = "interpolationCheckBox";
            this.interpolationCheckBox.Size = new System.Drawing.Size(167, 17);
            this.interpolationCheckBox.TabIndex = 22;
            this.interpolationCheckBox.Text = "Use interpolation (marked red)";
            this.interpolationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShowClustersCheckbox
            // 
            this.ShowClustersCheckbox.AutoSize = true;
            this.ShowClustersCheckbox.Location = new System.Drawing.Point(200, 29);
            this.ShowClustersCheckbox.Name = "ShowClustersCheckbox";
            this.ShowClustersCheckbox.Size = new System.Drawing.Size(92, 17);
            this.ShowClustersCheckbox.TabIndex = 23;
            this.ShowClustersCheckbox.Text = "Show clusters";
            this.ShowClustersCheckbox.UseVisualStyleBackColor = true;
            // 
            // ClustersLabel
            // 
            this.ClustersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClustersLabel.AutoSize = true;
            this.ClustersLabel.Location = new System.Drawing.Point(200, 56);
            this.ClustersLabel.Name = "ClustersLabel";
            this.ClustersLabel.Size = new System.Drawing.Size(44, 13);
            this.ClustersLabel.TabIndex = 20;
            this.ClustersLabel.Text = "Clusters";
            // 
            // playTimeButton
            // 
            this.playTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playTimeButton.BackColor = System.Drawing.Color.LightGray;
            this.playTimeButton.Location = new System.Drawing.Point(160, 281);
            this.playTimeButton.Name = "playTimeButton";
            this.playTimeButton.Size = new System.Drawing.Size(76, 23);
            this.playTimeButton.TabIndex = 0;
            this.playTimeButton.Text = "Play Time";
            this.playTimeButton.UseVisualStyleBackColor = false;
            this.playTimeButton.Click += new System.EventHandler(this.playTimeButton_Click);
            // 
            // ScatterYaxisValuesSelector
            // 
            this.ScatterYaxisValuesSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScatterYaxisValuesSelector.FormattingEnabled = true;
            this.ScatterYaxisValuesSelector.Location = new System.Drawing.Point(15, 44);
            this.ScatterYaxisValuesSelector.Name = "ScatterYaxisValuesSelector";
            this.ScatterYaxisValuesSelector.Size = new System.Drawing.Size(148, 21);
            this.ScatterYaxisValuesSelector.TabIndex = 14;
            this.ScatterYaxisValuesSelector.Text = "choose data source";
            // 
            // numberofClusters
            // 
            this.numberofClusters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberofClusters.Location = new System.Drawing.Point(254, 54);
            this.numberofClusters.Name = "numberofClusters";
            this.numberofClusters.Size = new System.Drawing.Size(41, 20);
            this.numberofClusters.TabIndex = 19;
            this.numberofClusters.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ScatterXaxisValuesSelector
            // 
            this.ScatterXaxisValuesSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScatterXaxisValuesSelector.FormattingEnabled = true;
            this.ScatterXaxisValuesSelector.Location = new System.Drawing.Point(15, 100);
            this.ScatterXaxisValuesSelector.Name = "ScatterXaxisValuesSelector";
            this.ScatterXaxisValuesSelector.Size = new System.Drawing.Size(148, 21);
            this.ScatterXaxisValuesSelector.TabIndex = 0;
            this.ScatterXaxisValuesSelector.Text = "choose data source";
            // 
            // yAxisSelectorLabel
            // 
            this.yAxisSelectorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yAxisSelectorLabel.AutoSize = true;
            this.yAxisSelectorLabel.Location = new System.Drawing.Point(12, 28);
            this.yAxisSelectorLabel.Name = "yAxisSelectorLabel";
            this.yAxisSelectorLabel.Size = new System.Drawing.Size(35, 13);
            this.yAxisSelectorLabel.TabIndex = 15;
            this.yAxisSelectorLabel.Text = "Y-axis";
            // 
            // sizeSelectorLabel
            // 
            this.sizeSelectorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeSelectorLabel.AutoSize = true;
            this.sizeSelectorLabel.Location = new System.Drawing.Point(12, 139);
            this.sizeSelectorLabel.Name = "sizeSelectorLabel";
            this.sizeSelectorLabel.Size = new System.Drawing.Size(51, 13);
            this.sizeSelectorLabel.TabIndex = 3;
            this.sizeSelectorLabel.Text = "point size";
            // 
            // kMeansTitle
            // 
            this.kMeansTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kMeansTitle.AutoSize = true;
            this.kMeansTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.kMeansTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kMeansTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.kMeansTitle.Location = new System.Drawing.Point(197, 3);
            this.kMeansTitle.Name = "kMeansTitle";
            this.kMeansTitle.Size = new System.Drawing.Size(115, 17);
            this.kMeansTitle.TabIndex = 11;
            this.kMeansTitle.Text = "Trend Clusters";
            // 
            // ScatterSizeSelector
            // 
            this.ScatterSizeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScatterSizeSelector.FormattingEnabled = true;
            this.ScatterSizeSelector.Location = new System.Drawing.Point(15, 155);
            this.ScatterSizeSelector.Name = "ScatterSizeSelector";
            this.ScatterSizeSelector.Size = new System.Drawing.Size(148, 21);
            this.ScatterSizeSelector.TabIndex = 1;
            this.ScatterSizeSelector.Text = "choose data source";
            // 
            // xAxisSelectorLabel
            // 
            this.xAxisSelectorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xAxisSelectorLabel.AutoSize = true;
            this.xAxisSelectorLabel.Location = new System.Drawing.Point(12, 84);
            this.xAxisSelectorLabel.Name = "xAxisSelectorLabel";
            this.xAxisSelectorLabel.Size = new System.Drawing.Size(35, 13);
            this.xAxisSelectorLabel.TabIndex = 2;
            this.xAxisSelectorLabel.Text = "X-axis";
            // 
            // YearSelectionTitle
            // 
            this.YearSelectionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YearSelectionTitle.AutoSize = true;
            this.YearSelectionTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.YearSelectionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearSelectionTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.YearSelectionTitle.Location = new System.Drawing.Point(103, 206);
            this.YearSelectionTitle.Name = "YearSelectionTitle";
            this.YearSelectionTitle.Size = new System.Drawing.Size(179, 17);
            this.YearSelectionTitle.TabIndex = 10;
            this.YearSelectionTitle.Text = "Year Selection Controls";
            // 
            // yearSlider
            // 
            this.yearSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.yearSlider.Location = new System.Drawing.Point(43, 247);
            this.yearSlider.Name = "yearSlider";
            this.yearSlider.Size = new System.Drawing.Size(297, 42);
            this.yearSlider.TabIndex = 4;
            // 
            // SelectedYear
            // 
            this.SelectedYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedYear.AutoSize = true;
            this.SelectedYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedYear.Location = new System.Drawing.Point(200, 229);
            this.SelectedYear.Name = "SelectedYear";
            this.SelectedYear.Size = new System.Drawing.Size(40, 16);
            this.SelectedYear.TabIndex = 6;
            this.SelectedYear.Text = "1990";
            // 
            // ScatterControlTitle
            // 
            this.ScatterControlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScatterControlTitle.AutoSize = true;
            this.ScatterControlTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ScatterControlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScatterControlTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ScatterControlTitle.Location = new System.Drawing.Point(12, 4);
            this.ScatterControlTitle.Name = "ScatterControlTitle";
            this.ScatterControlTitle.Size = new System.Drawing.Size(158, 17);
            this.ScatterControlTitle.TabIndex = 6;
            this.ScatterControlTitle.Text = "Scatter Plot Controls";
            // 
            // YearLabel
            // 
            this.YearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(40, 231);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(29, 13);
            this.YearLabel.TabIndex = 5;
            this.YearLabel.Text = "Year";
            // 
            // SelectedYearLabel
            // 
            this.SelectedYearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedYearLabel.AutoSize = true;
            this.SelectedYearLabel.Location = new System.Drawing.Point(119, 232);
            this.SelectedYearLabel.Name = "SelectedYearLabel";
            this.SelectedYearLabel.Size = new System.Drawing.Size(75, 13);
            this.SelectedYearLabel.TabIndex = 7;
            this.SelectedYearLabel.Text = "Selected year:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 708);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainWindow";
            this.Text = "EnergyExplorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.topSplitContainer.Panel1.ResumeLayout(false);
            this.topSplitContainer.Panel1.PerformLayout();
            this.topSplitContainer.Panel2.ResumeLayout(false);
            this.topSplitContainer.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.bottomSplitContainer.Panel1.ResumeLayout(false);
            this.bottomSplitContainer.Panel2.ResumeLayout(false);
            this.bottomSplitContainer.Panel2.PerformLayout();
            this.bottomSplitContainer.ResumeLayout(false);
            this.pcPlotSplitContainer.Panel1.ResumeLayout(false);
            this.pcPlotSplitContainer.Panel1.PerformLayout();
            this.pcPlotSplitContainer.Panel2.ResumeLayout(false);
            this.pcPlotSplitContainer.Panel2.PerformLayout();
            this.pcPlotSplitContainer.ResumeLayout(false);
            this.pcVariablePanel.ResumeLayout(false);
            this.pcYearPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineGlyphAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel pcVariablePanel;
        private System.Windows.Forms.Panel pcYearPanel;
        public System.Windows.Forms.TrackBar yearSlider;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label SelectedYearLabel;
        public System.Windows.Forms.Label SelectedYear;
        private System.Windows.Forms.Label YearHighEndLabel;
        private System.Windows.Forms.Label YearLowEndLabel;
        public System.Windows.Forms.ComboBox ScatterXaxisValuesSelector;
        public System.Windows.Forms.ComboBox ScatterSizeSelector;
        private System.Windows.Forms.Label xAxisSelectorLabel;
        private System.Windows.Forms.Label sizeSelectorLabel;
        public System.Windows.Forms.Label yAxisLabel;
        public System.Windows.Forms.Label xAxisLabel;
        private System.Windows.Forms.SplitContainer topSplitContainer;
        public System.Windows.Forms.Label ScatterControlTitle;
        public System.Windows.Forms.Label YearSelectionTitle;
        public System.Windows.Forms.Label kMeansTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button playTimeButton;
        private System.Windows.Forms.SplitContainer bottomSplitContainer;
        private System.Windows.Forms.SplitContainer pcPlotSplitContainer;
        public System.Windows.Forms.ComboBox ScatterYaxisValuesSelector;
        private System.Windows.Forms.Label yAxisSelectorLabel;
        private System.Windows.Forms.Label ClustersLabel;
        public System.Windows.Forms.Label InterpolationTitle;
        private System.Windows.Forms.Panel colorLegendPanel;
        public System.Windows.Forms.CheckBox interpolationCheckBox;
        public System.Windows.Forms.Label alphaLabel;
        public System.Windows.Forms.NumericUpDown lineGlyphAlpha;
        public System.Windows.Forms.Label colorLegendLabelBottom;
        public System.Windows.Forms.Label colorLegendLabelTop;
        public System.Windows.Forms.Label colorLegendLabelCenter;
        public System.Windows.Forms.Button varPCReset;
        public System.Windows.Forms.Button varPCColZoomIn;
        public System.Windows.Forms.Button yearPCReset;
        public System.Windows.Forms.Button varPCColResetZoom;
        public System.Windows.Forms.Button colorLegendReset;
        public System.Windows.Forms.Button mapReset;
        private System.Windows.Forms.Label alphaLabel1;
        public System.Windows.Forms.NumericUpDown numberofClusters;
        public System.Windows.Forms.CheckBox ShowClustersCheckbox;
    }
}

