namespace THTool
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
            this.txtLP = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCopyFile = new System.Windows.Forms.CheckBox();
            this.txtShake91 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpATHExcel = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkCalcDisp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudYieldAccel = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkIgnoreZeroAccel = new System.Windows.Forms.CheckBox();
            this.btnBrowseSurfaceATH = new System.Windows.Forms.Button();
            this.txtATHSurfaceFile = new System.Windows.Forms.TextBox();
            this.nudATHCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowseBaseATH = new System.Windows.Forms.Button();
            this.txtATHBaseFile = new System.Windows.Forms.TextBox();
            this.tpRP = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnBrowseRP1 = new System.Windows.Forms.Button();
            this.txtRPShake91 = new System.Windows.Forms.TextBox();
            this.tpATHGen = new System.Windows.Forms.TabPage();
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.bwApp = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusApp = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbarApp = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpATHExcel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYieldAccel)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATHCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tpRP.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpATHGen.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DT (s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "HP (Hz)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "LP (Hz)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 124);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtLP
            // 
            this.txtLP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "LP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLP.Location = new System.Drawing.Point(82, 56);
            this.txtLP.Name = "txtLP";
            this.txtLP.Size = new System.Drawing.Size(100, 20);
            this.txtLP.TabIndex = 8;
            this.txtLP.Text = global::THTool.Properties.Settings.Default.LP;
            // 
            // txtHP
            // 
            this.txtHP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "HP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHP.Location = new System.Drawing.Point(82, 30);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(100, 20);
            this.txtHP.TabIndex = 6;
            this.txtHP.Text = global::THTool.Properties.Settings.Default.HP;
            // 
            // txtDT
            // 
            this.txtDT.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "DT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDT.Location = new System.Drawing.Point(82, 84);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(100, 20);
            this.txtDT.TabIndex = 4;
            this.txtDT.Text = global::THTool.Properties.Settings.Default.DT;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Drag && Drop one or more raw acceleration time history files...";
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
            this.groupBox2.Location = new System.Drawing.Point(23, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 88);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            this.groupBox2.Visible = false;
            // 
            // chkCopyFile
            // 
            this.chkCopyFile.AutoSize = true;
            this.chkCopyFile.Checked = global::THTool.Properties.Settings.Default.CopyTHFile;
            this.chkCopyFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::THTool.Properties.Settings.Default, "CopyTHFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.txtShake91.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "Shake91", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShake91.Location = new System.Drawing.Point(113, 26);
            this.txtShake91.Name = "txtShake91";
            this.txtShake91.Size = new System.Drawing.Size(330, 20);
            this.txtShake91.TabIndex = 12;
            this.txtShake91.Text = global::THTool.Properties.Settings.Default.Shake91;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpATHExcel);
            this.tabControl1.Controls.Add(this.tpRP);
            this.tabControl1.Controls.Add(this.tpATHGen);
            this.tabControl1.Location = new System.Drawing.Point(16, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(664, 368);
            this.tabControl1.TabIndex = 13;
            // 
            // tpATHExcel
            // 
            this.tpATHExcel.Controls.Add(this.groupBox5);
            this.tpATHExcel.Controls.Add(this.groupBox4);
            this.tpATHExcel.Controls.Add(this.groupBox3);
            this.tpATHExcel.Location = new System.Drawing.Point(4, 22);
            this.tpATHExcel.Name = "tpATHExcel";
            this.tpATHExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tpATHExcel.Size = new System.Drawing.Size(656, 342);
            this.tpATHExcel.TabIndex = 1;
            this.tpATHExcel.Text = "Accelerogram Maker";
            this.tpATHExcel.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkCalcDisp);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.nudYieldAccel);
            this.groupBox5.Location = new System.Drawing.Point(16, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(624, 120);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options";
            // 
            // chkCalcDisp
            // 
            this.chkCalcDisp.AutoSize = true;
            this.chkCalcDisp.Checked = global::THTool.Properties.Settings.Default.CalcDisp;
            this.chkCalcDisp.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::THTool.Properties.Settings.Default, "CalcDisp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCalcDisp.Location = new System.Drawing.Point(16, 24);
            this.chkCalcDisp.Name = "chkCalcDisp";
            this.chkCalcDisp.Size = new System.Drawing.Size(142, 17);
            this.chkCalcDisp.TabIndex = 21;
            this.chkCalcDisp.Text = "Calculate Displacements";
            this.chkCalcDisp.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Yield Acceleration (g)";
            // 
            // nudYieldAccel
            // 
            this.nudYieldAccel.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::THTool.Properties.Settings.Default, "YieldAccel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudYieldAccel.DecimalPlaces = 4;
            this.nudYieldAccel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudYieldAccel.Location = new System.Drawing.Point(128, 56);
            this.nudYieldAccel.Name = "nudYieldAccel";
            this.nudYieldAccel.Size = new System.Drawing.Size(120, 20);
            this.nudYieldAccel.TabIndex = 21;
            this.nudYieldAccel.Value = global::THTool.Properties.Settings.Default.YieldAccel;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkIgnoreZeroAccel);
            this.groupBox4.Controls.Add(this.btnBrowseSurfaceATH);
            this.groupBox4.Controls.Add(this.txtATHSurfaceFile);
            this.groupBox4.Controls.Add(this.nudATHCount);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(16, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 103);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ATH (Surface - from Shake91)";
            // 
            // chkIgnoreZeroAccel
            // 
            this.chkIgnoreZeroAccel.AutoSize = true;
            this.chkIgnoreZeroAccel.Checked = global::THTool.Properties.Settings.Default.IgnoreZeroBaseAccel;
            this.chkIgnoreZeroAccel.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::THTool.Properties.Settings.Default, "IgnoreZeroBaseAccel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkIgnoreZeroAccel.Location = new System.Drawing.Point(232, 64);
            this.chkIgnoreZeroAccel.Name = "chkIgnoreZeroAccel";
            this.chkIgnoreZeroAccel.Size = new System.Drawing.Size(148, 17);
            this.chkIgnoreZeroAccel.TabIndex = 15;
            this.chkIgnoreZeroAccel.Text = "Ignore Zero Accelerations";
            this.chkIgnoreZeroAccel.UseVisualStyleBackColor = true;
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
            // txtATHSurfaceFile
            // 
            this.txtATHSurfaceFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "ATHSurface", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtATHSurfaceFile.Location = new System.Drawing.Point(16, 24);
            this.txtATHSurfaceFile.Name = "txtATHSurfaceFile";
            this.txtATHSurfaceFile.Size = new System.Drawing.Size(472, 20);
            this.txtATHSurfaceFile.TabIndex = 13;
            this.txtATHSurfaceFile.Text = global::THTool.Properties.Settings.Default.ATHSurface;
            // 
            // nudATHCount
            // 
            this.nudATHCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::THTool.Properties.Settings.Default, "ATHLineCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.nudATHCount.Value = global::THTool.Properties.Settings.Default.ATHLineCount;
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
            this.groupBox3.Size = new System.Drawing.Size(623, 65);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ATH (Base - from http://peer.berkeley.edu/smcat/search.html)";
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
            // txtATHBaseFile
            // 
            this.txtATHBaseFile.AllowDrop = true;
            this.txtATHBaseFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "ATHBase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtATHBaseFile.Location = new System.Drawing.Point(16, 24);
            this.txtATHBaseFile.Name = "txtATHBaseFile";
            this.txtATHBaseFile.Size = new System.Drawing.Size(472, 20);
            this.txtATHBaseFile.TabIndex = 12;
            this.txtATHBaseFile.Text = global::THTool.Properties.Settings.Default.ATHBase;
            // 
            // tpRP
            // 
            this.tpRP.Controls.Add(this.groupBox6);
            this.tpRP.Location = new System.Drawing.Point(4, 22);
            this.tpRP.Name = "tpRP";
            this.tpRP.Padding = new System.Windows.Forms.Padding(3);
            this.tpRP.Size = new System.Drawing.Size(656, 342);
            this.tpRP.TabIndex = 2;
            this.tpRP.Text = "Reponse Spectra Generator";
            this.tpRP.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBrowseRP1);
            this.groupBox6.Controls.Add(this.txtRPShake91);
            this.groupBox6.Location = new System.Drawing.Point(16, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(623, 65);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Shake91 Output File 1";
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
            // txtRPShake91
            // 
            this.txtRPShake91.AllowDrop = true;
            this.txtRPShake91.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "RPShake91", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtRPShake91.Location = new System.Drawing.Point(16, 24);
            this.txtRPShake91.Name = "txtRPShake91";
            this.txtRPShake91.Size = new System.Drawing.Size(472, 20);
            this.txtRPShake91.TabIndex = 12;
            this.txtRPShake91.Text = global::THTool.Properties.Settings.Default.RPShake91;
            // 
            // tpATHGen
            // 
            this.tpATHGen.Controls.Add(this.label4);
            this.tpATHGen.Controls.Add(this.groupBox2);
            this.tpATHGen.Controls.Add(this.groupBox1);
            this.tpATHGen.Location = new System.Drawing.Point(4, 22);
            this.tpATHGen.Name = "tpATHGen";
            this.tpATHGen.Padding = new System.Windows.Forms.Padding(3);
            this.tpATHGen.Size = new System.Drawing.Size(656, 342);
            this.tpATHGen.TabIndex = 0;
            this.tpATHGen.Text = "ATH Generator (Experimental)";
            this.tpATHGen.UseVisualStyleBackColor = true;
            this.tpATHGen.DragEnter += new System.Windows.Forms.DragEventHandler(this.tpATHGen_DragEnter);
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::THTool.Properties.Settings.Default, "ExcelFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtExcelFile.Location = new System.Drawing.Point(16, 32);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(472, 20);
            this.txtExcelFile.TabIndex = 19;
            this.txtExcelFile.Text = global::THTool.Properties.Settings.Default.ExcelFilePath;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(496, 32);
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
            this.bwApp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwApp_RunWorkerCompleted);
            this.bwApp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwApp_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusApp,
            this.pbarApp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(707, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusApp
            // 
            this.statusApp.Name = "statusApp";
            this.statusApp.Size = new System.Drawing.Size(590, 17);
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
            this.groupBox7.Location = new System.Drawing.Point(40, 392);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(616, 72);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Export to Excel";
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 501);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Earthquake Analysis Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpATHExcel.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYieldAccel)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATHCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tpRP.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tpATHGen.ResumeLayout(false);
            this.tpATHGen.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkCopyFile;
        private System.Windows.Forms.TextBox txtShake91;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpATHGen;
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
        private System.Windows.Forms.CheckBox chkCalcDisp;
        private System.Windows.Forms.CheckBox chkIgnoreZeroAccel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudYieldAccel;
        private System.Windows.Forms.TabPage tpRP;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBrowseRP1;
        private System.Windows.Forms.TextBox txtRPShake91;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

