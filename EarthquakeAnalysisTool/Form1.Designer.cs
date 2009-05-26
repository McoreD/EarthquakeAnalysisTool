namespace EqAT
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tcExcel = new System.Windows.Forms.TabControl();
            this.tpATHExcel = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBrowseSurfaceATH = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowseBaseATH = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnBrowseRP1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExportATH = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.bwApp = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusApp = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbarApp = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkCalcDisplacements = new System.Windows.Forms.CheckBox();
            this.chkResponseSpectra = new System.Windows.Forms.CheckBox();
            this.chkIgnoreZeroAccel = new System.Windows.Forms.CheckBox();
            this.txtATHSurfaceFile = new System.Windows.Forms.TextBox();
            this.nudATHCount = new System.Windows.Forms.NumericUpDown();
            this.txtATHBaseFile = new System.Windows.Forms.TextBox();
            this.txtShake91PV = new System.Windows.Forms.TextBox();
            this.nudXaxisMaxScale = new System.Windows.Forms.NumericUpDown();
            this.chkNewmarkImplicitIntegration = new System.Windows.Forms.CheckBox();
            this.chkCreateLoadMultFile = new System.Windows.Forms.CheckBox();
            this.nudYieldAccel = new System.Windows.Forms.NumericUpDown();
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.txtShake91ATH = new System.Windows.Forms.TextBox();
            this.nudMaxRecords = new System.Windows.Forms.NumericUpDown();
            this.chkMaxReadings = new System.Windows.Forms.CheckBox();
            this.nudDT = new System.Windows.Forms.NumericUpDown();
            this.nudLP = new System.Windows.Forms.NumericUpDown();
            this.nudHP = new System.Windows.Forms.NumericUpDown();
            this.chkCopyFile = new System.Windows.Forms.CheckBox();
            this.txtShake91 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tcExcel.SuspendLayout();
            this.tpATHExcel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATHCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXaxisMaxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYieldAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHP)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DT (s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "HP (Hz)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "LP (Hz)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudMaxRecords);
            this.groupBox1.Controls.Add(this.chkMaxReadings);
            this.groupBox1.Controls.Add(this.nudDT);
            this.groupBox1.Controls.Add(this.nudLP);
            this.groupBox1.Controls.Add(this.nudHP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 124);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Drag && Drop a raw acceleration time history file...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Shake91 Path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCopyFile);
            this.groupBox2.Controls.Add(this.txtShake91);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(16, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 88);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            this.groupBox2.Visible = false;
            // 
            // tcExcel
            // 
            this.tcExcel.Controls.Add(this.tpATHExcel);
            this.tcExcel.Controls.Add(this.tabPage3);
            this.tcExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcExcel.Location = new System.Drawing.Point(3, 3);
            this.tcExcel.Name = "tcExcel";
            this.tcExcel.SelectedIndex = 0;
            this.tcExcel.Size = new System.Drawing.Size(690, 301);
            this.tcExcel.TabIndex = 13;
            // 
            // tpATHExcel
            // 
            this.tpATHExcel.Controls.Add(this.groupBox4);
            this.tpATHExcel.Controls.Add(this.groupBox3);
            this.tpATHExcel.Controls.Add(this.groupBox6);
            this.tpATHExcel.Location = new System.Drawing.Point(4, 22);
            this.tpATHExcel.Name = "tpATHExcel";
            this.tpATHExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tpATHExcel.Size = new System.Drawing.Size(682, 275);
            this.tpATHExcel.TabIndex = 1;
            this.tpATHExcel.Text = "Earthquake Data";
            this.tpATHExcel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkIgnoreZeroAccel);
            this.groupBox4.Controls.Add(this.btnBrowseSurfaceATH);
            this.groupBox4.Controls.Add(this.txtATHSurfaceFile);
            this.groupBox4.Controls.Add(this.nudATHCount);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(16, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 103);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ATH (Surface: Shake91 Output File 2)";
            // 
            // btnBrowseSurfaceATH
            // 
            this.btnBrowseSurfaceATH.Location = new System.Drawing.Point(496, 24);
            this.btnBrowseSurfaceATH.Name = "btnBrowseSurfaceATH";
            this.btnBrowseSurfaceATH.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSurfaceATH.TabIndex = 15;
            this.btnBrowseSurfaceATH.Text = "&Browse";
            this.btnBrowseSurfaceATH.UseVisualStyleBackColor = true;
            this.btnBrowseSurfaceATH.Click += new System.EventHandler(this.btnBrowseSurfaceATH_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Line Count";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBrowseBaseATH);
            this.groupBox3.Controls.Add(this.txtATHBaseFile);
            this.groupBox3.Location = new System.Drawing.Point(16, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(623, 64);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ATH (Base: from http://peer.berkeley.edu/smcat/search.html)";
            // 
            // btnBrowseBaseATH
            // 
            this.btnBrowseBaseATH.Location = new System.Drawing.Point(496, 24);
            this.btnBrowseBaseATH.Name = "btnBrowseBaseATH";
            this.btnBrowseBaseATH.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBaseATH.TabIndex = 14;
            this.btnBrowseBaseATH.Text = "&Browse";
            this.btnBrowseBaseATH.UseVisualStyleBackColor = true;
            this.btnBrowseBaseATH.Click += new System.EventHandler(this.btnBrowseBaseATH_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBrowseRP1);
            this.groupBox6.Controls.Add(this.txtShake91PV);
            this.groupBox6.Location = new System.Drawing.Point(16, 86);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(623, 65);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Peak Values (Shake91 Output File 1)";
            // 
            // btnBrowseRP1
            // 
            this.btnBrowseRP1.Location = new System.Drawing.Point(496, 24);
            this.btnBrowseRP1.Name = "btnBrowseRP1";
            this.btnBrowseRP1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseRP1.TabIndex = 14;
            this.btnBrowseRP1.Text = "&Browse";
            this.btnBrowseRP1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(682, 275);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.nudXaxisMaxScale);
            this.groupBox8.Location = new System.Drawing.Point(10, 144);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(624, 71);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Response Spectra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "X-axis Maximum Scale";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkNewmarkImplicitIntegration);
            this.groupBox5.Controls.Add(this.chkCreateLoadMultFile);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.nudYieldAccel);
            this.groupBox5.Location = new System.Drawing.Point(10, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(624, 120);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ATH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Yield Acceleration (g)";
            // 
            // btnExportATH
            // 
            this.btnExportATH.Location = new System.Drawing.Point(501, 173);
            this.btnExportATH.Name = "btnExportATH";
            this.btnExportATH.Size = new System.Drawing.Size(75, 23);
            this.btnExportATH.TabIndex = 13;
            this.btnExportATH.Text = "&Export";
            this.btnExportATH.UseVisualStyleBackColor = true;
            this.btnExportATH.Click += new System.EventHandler(this.btnExportATH_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(512, 32);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "&Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // bwApp
            // 
            this.bwApp.WorkerReportsProgress = true;
            this.bwApp.WorkerSupportsCancellation = true;
            this.bwApp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwApp_DoWork);
            this.bwApp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwApp_ProgressChanged);
            this.bwApp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwApp_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusApp,
            this.pbarApp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusApp
            // 
            this.statusApp.Name = "statusApp";
            this.statusApp.Size = new System.Drawing.Size(607, 17);
            this.statusApp.Spring = true;
            this.statusApp.Text = "Ready";
            this.statusApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbarApp
            // 
            this.pbarApp.Name = "pbarApp";
            this.pbarApp.Size = new System.Drawing.Size(100, 16);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtExcelFile);
            this.groupBox7.Controls.Add(this.btnExport);
            this.groupBox7.Location = new System.Drawing.Point(16, 376);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(632, 72);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Export to Excel";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Location = new System.Drawing.Point(8, 8);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(704, 488);
            this.tcMain.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkCalcDisplacements);
            this.tabPage1.Controls.Add(this.chkResponseSpectra);
            this.tabPage1.Controls.Add(this.tcExcel);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(696, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Excel Reporter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtShake91ATH);
            this.tabPage2.Controls.Add(this.btnExportATH);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(696, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ATH Generator";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkCalcDisplacements
            // 
            this.chkCalcDisplacements.AutoSize = true;
            this.chkCalcDisplacements.Checked = global::EqAT.Properties.Settings.Default.CalcDisplacements;
            this.chkCalcDisplacements.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalcDisplacements.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "CalcDisplacements", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCalcDisplacements.Location = new System.Drawing.Point(24, 336);
            this.chkCalcDisplacements.Name = "chkCalcDisplacements";
            this.chkCalcDisplacements.Size = new System.Drawing.Size(143, 17);
            this.chkCalcDisplacements.TabIndex = 22;
            this.chkCalcDisplacements.Text = "&Newmark Displacements";
            this.chkCalcDisplacements.UseVisualStyleBackColor = true;
            // 
            // chkResponseSpectra
            // 
            this.chkResponseSpectra.AutoSize = true;
            this.chkResponseSpectra.Checked = global::EqAT.Properties.Settings.Default.GenResponseSpectrum;
            this.chkResponseSpectra.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "GenResponseSpectrum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkResponseSpectra.Location = new System.Drawing.Point(24, 312);
            this.chkResponseSpectra.Name = "chkResponseSpectra";
            this.chkResponseSpectra.Size = new System.Drawing.Size(122, 17);
            this.chkResponseSpectra.TabIndex = 21;
            this.chkResponseSpectra.Text = "&Response Spectrum";
            this.chkResponseSpectra.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreZeroAccel
            // 
            this.chkIgnoreZeroAccel.AutoSize = true;
            this.chkIgnoreZeroAccel.Checked = global::EqAT.Properties.Settings.Default.IgnoreZeroBaseAccel;
            this.chkIgnoreZeroAccel.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "IgnoreZeroBaseAccel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkIgnoreZeroAccel.Location = new System.Drawing.Point(232, 64);
            this.chkIgnoreZeroAccel.Name = "chkIgnoreZeroAccel";
            this.chkIgnoreZeroAccel.Size = new System.Drawing.Size(148, 17);
            this.chkIgnoreZeroAccel.TabIndex = 15;
            this.chkIgnoreZeroAccel.Text = "Ignore Zero Accelerations";
            this.chkIgnoreZeroAccel.UseVisualStyleBackColor = true;
            // 
            // txtATHSurfaceFile
            // 
            this.txtATHSurfaceFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EqAT.Properties.Settings.Default, "ATHSurface", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtATHSurfaceFile.Location = new System.Drawing.Point(16, 24);
            this.txtATHSurfaceFile.Name = "txtATHSurfaceFile";
            this.txtATHSurfaceFile.Size = new System.Drawing.Size(472, 20);
            this.txtATHSurfaceFile.TabIndex = 13;
            this.txtATHSurfaceFile.Text = global::EqAT.Properties.Settings.Default.ATHSurface;
            // 
            // nudATHCount
            // 
            this.nudATHCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "ATHLineCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudATHCount.Location = new System.Drawing.Point(80, 62);
            this.nudATHCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudATHCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudATHCount.Name = "nudATHCount";
            this.nudATHCount.Size = new System.Drawing.Size(120, 20);
            this.nudATHCount.TabIndex = 8;
            this.nudATHCount.Value = global::EqAT.Properties.Settings.Default.ATHLineCount;
            // 
            // txtATHBaseFile
            // 
            this.txtATHBaseFile.AllowDrop = true;
            this.txtATHBaseFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EqAT.Properties.Settings.Default, "ATHBase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtATHBaseFile.Location = new System.Drawing.Point(16, 24);
            this.txtATHBaseFile.Name = "txtATHBaseFile";
            this.txtATHBaseFile.Size = new System.Drawing.Size(472, 20);
            this.txtATHBaseFile.TabIndex = 12;
            this.txtATHBaseFile.Text = global::EqAT.Properties.Settings.Default.ATHBase;
            // 
            // txtShake91PV
            // 
            this.txtShake91PV.AllowDrop = true;
            this.txtShake91PV.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EqAT.Properties.Settings.Default, "RPShake91", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShake91PV.Location = new System.Drawing.Point(16, 24);
            this.txtShake91PV.Name = "txtShake91PV";
            this.txtShake91PV.Size = new System.Drawing.Size(472, 20);
            this.txtShake91PV.TabIndex = 12;
            this.txtShake91PV.Text = global::EqAT.Properties.Settings.Default.RPShake91;
            // 
            // nudXaxisMaxScale
            // 
            this.nudXaxisMaxScale.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "RPXaxisMaxScale", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudXaxisMaxScale.DecimalPlaces = 2;
            this.nudXaxisMaxScale.Location = new System.Drawing.Point(133, 29);
            this.nudXaxisMaxScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXaxisMaxScale.Name = "nudXaxisMaxScale";
            this.nudXaxisMaxScale.Size = new System.Drawing.Size(120, 20);
            this.nudXaxisMaxScale.TabIndex = 18;
            this.nudXaxisMaxScale.Value = global::EqAT.Properties.Settings.Default.RPXaxisMaxScale;
            // 
            // chkNewmarkImplicitIntegration
            // 
            this.chkNewmarkImplicitIntegration.AutoSize = true;
            this.chkNewmarkImplicitIntegration.Checked = global::EqAT.Properties.Settings.Default.NewmarkImplicitIntegration;
            this.chkNewmarkImplicitIntegration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewmarkImplicitIntegration.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "NewmarkImplicitIntegration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkNewmarkImplicitIntegration.Location = new System.Drawing.Point(16, 48);
            this.chkNewmarkImplicitIntegration.Name = "chkNewmarkImplicitIntegration";
            this.chkNewmarkImplicitIntegration.Size = new System.Drawing.Size(334, 17);
            this.chkNewmarkImplicitIntegration.TabIndex = 22;
            this.chkNewmarkImplicitIntegration.Text = "Use Implicit time intergration scheme of Newmark (more accurate)";
            this.chkNewmarkImplicitIntegration.UseVisualStyleBackColor = true;
            // 
            // chkCreateLoadMultFile
            // 
            this.chkCreateLoadMultFile.AutoSize = true;
            this.chkCreateLoadMultFile.Checked = global::EqAT.Properties.Settings.Default.CreateLoadMultFile;
            this.chkCreateLoadMultFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "CreateLoadMultFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCreateLoadMultFile.Location = new System.Drawing.Point(16, 24);
            this.chkCreateLoadMultFile.Name = "chkCreateLoadMultFile";
            this.chkCreateLoadMultFile.Size = new System.Drawing.Size(262, 17);
            this.chkCreateLoadMultFile.TabIndex = 21;
            this.chkCreateLoadMultFile.Text = "Create Load Multiplier data file for Plaxis Dynamics";
            this.chkCreateLoadMultFile.UseVisualStyleBackColor = true;
            // 
            // nudYieldAccel
            // 
            this.nudYieldAccel.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "YieldAccel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudYieldAccel.DecimalPlaces = 6;
            this.nudYieldAccel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudYieldAccel.Location = new System.Drawing.Point(128, 80);
            this.nudYieldAccel.Name = "nudYieldAccel";
            this.nudYieldAccel.Size = new System.Drawing.Size(120, 20);
            this.nudYieldAccel.TabIndex = 21;
            this.nudYieldAccel.Value = global::EqAT.Properties.Settings.Default.YieldAccel;
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EqAT.Properties.Settings.Default, "ExcelFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtExcelFile.Location = new System.Drawing.Point(16, 32);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(472, 20);
            this.txtExcelFile.TabIndex = 19;
            this.txtExcelFile.Text = global::EqAT.Properties.Settings.Default.ExcelFilePath;
            // 
            // txtShake91ATH
            // 
            this.txtShake91ATH.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EqAT.Properties.Settings.Default, "Shake91ATHFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShake91ATH.Location = new System.Drawing.Point(21, 173);
            this.txtShake91ATH.Name = "txtShake91ATH";
            this.txtShake91ATH.Size = new System.Drawing.Size(472, 20);
            this.txtShake91ATH.TabIndex = 20;
            this.txtShake91ATH.Text = global::EqAT.Properties.Settings.Default.Shake91ATHFile;
            // 
            // nudMaxRecords
            // 
            this.nudMaxRecords.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "MaxATHRecords", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudMaxRecords.Location = new System.Drawing.Point(280, 48);
            this.nudMaxRecords.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudMaxRecords.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxRecords.Name = "nudMaxRecords";
            this.nudMaxRecords.Size = new System.Drawing.Size(120, 20);
            this.nudMaxRecords.TabIndex = 16;
            this.nudMaxRecords.Value = global::EqAT.Properties.Settings.Default.MaxATHRecords;
            // 
            // chkMaxReadings
            // 
            this.chkMaxReadings.AutoSize = true;
            this.chkMaxReadings.Checked = global::EqAT.Properties.Settings.Default.Limit4000Readings;
            this.chkMaxReadings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaxReadings.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "Limit4000Readings", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkMaxReadings.Location = new System.Drawing.Point(280, 24);
            this.chkMaxReadings.Name = "chkMaxReadings";
            this.chkMaxReadings.Size = new System.Drawing.Size(129, 17);
            this.chkMaxReadings.TabIndex = 15;
            this.chkMaxReadings.Text = "Limit to 4000 readings";
            this.chkMaxReadings.UseVisualStyleBackColor = true;
            // 
            // nudDT
            // 
            this.nudDT.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "DT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudDT.DecimalPlaces = 3;
            this.nudDT.Location = new System.Drawing.Point(80, 72);
            this.nudDT.Name = "nudDT";
            this.nudDT.Size = new System.Drawing.Size(120, 20);
            this.nudDT.TabIndex = 11;
            this.nudDT.Value = global::EqAT.Properties.Settings.Default.DT;
            // 
            // nudLP
            // 
            this.nudLP.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "LP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudLP.DecimalPlaces = 2;
            this.nudLP.Location = new System.Drawing.Point(80, 48);
            this.nudLP.Name = "nudLP";
            this.nudLP.Size = new System.Drawing.Size(120, 20);
            this.nudLP.TabIndex = 10;
            this.nudLP.Value = global::EqAT.Properties.Settings.Default.LP;
            // 
            // nudHP
            // 
            this.nudHP.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EqAT.Properties.Settings.Default, "HP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudHP.DecimalPlaces = 2;
            this.nudHP.Location = new System.Drawing.Point(80, 24);
            this.nudHP.Name = "nudHP";
            this.nudHP.Size = new System.Drawing.Size(120, 20);
            this.nudHP.TabIndex = 9;
            this.nudHP.Value = global::EqAT.Properties.Settings.Default.HP;
            // 
            // chkCopyFile
            // 
            this.chkCopyFile.AutoSize = true;
            this.chkCopyFile.Checked = global::EqAT.Properties.Settings.Default.CopyTHFile;
            this.chkCopyFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EqAT.Properties.Settings.Default, "CopyTHFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCopyFile.Location = new System.Drawing.Point(27, 55);
            this.chkCopyFile.Name = "chkCopyFile";
            this.chkCopyFile.Size = new System.Drawing.Size(214, 17);
            this.chkCopyFile.TabIndex = 13;
            this.chkCopyFile.Text = "&Copy Time History file to Shake91 folder";
            this.chkCopyFile.UseVisualStyleBackColor = true;
            // 
            // txtShake91
            // 
            this.txtShake91.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShake91.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtShake91.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EqAT.Properties.Settings.Default, "Shake91", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShake91.Location = new System.Drawing.Point(113, 26);
            this.txtShake91.Name = "txtShake91";
            this.txtShake91.Size = new System.Drawing.Size(330, 20);
            this.txtShake91.TabIndex = 12;
            this.txtShake91.Text = global::EqAT.Properties.Settings.Default.Shake91;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 528);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EqAT - Earthquake Analysis Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tcExcel.ResumeLayout(false);
            this.tpATHExcel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATHCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXaxisMaxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYieldAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkCopyFile;
        private System.Windows.Forms.TextBox txtShake91;
        private System.Windows.Forms.TabControl tcExcel;
        private System.Windows.Forms.TabPage tpATHExcel;
        private System.Windows.Forms.NumericUpDown nudATHCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBrowseSurfaceATH;
        private System.Windows.Forms.Button btnBrowseBaseATH;
        private System.Windows.Forms.TextBox txtATHSurfaceFile;
        private System.Windows.Forms.TextBox txtATHBaseFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtExcelFile;
        private System.ComponentModel.BackgroundWorker bwApp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusApp;
        private System.Windows.Forms.ToolStripProgressBar pbarApp;
        private System.Windows.Forms.CheckBox chkCreateLoadMultFile;
        private System.Windows.Forms.CheckBox chkIgnoreZeroAccel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudYieldAccel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBrowseRP1;
        private System.Windows.Forms.TextBox txtShake91PV;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnExportATH;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtShake91ATH;
        private System.Windows.Forms.NumericUpDown nudLP;
        private System.Windows.Forms.NumericUpDown nudHP;
        private System.Windows.Forms.NumericUpDown nudDT;
        private System.Windows.Forms.NumericUpDown nudXaxisMaxScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkMaxReadings;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox chkNewmarkImplicitIntegration;
        private System.Windows.Forms.NumericUpDown nudMaxRecords;
        private System.Windows.Forms.CheckBox chkCalcDisplacements;
        private System.Windows.Forms.CheckBox chkResponseSpectra;
    }
}

