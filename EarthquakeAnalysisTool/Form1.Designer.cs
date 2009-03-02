namespace AccelerationTimeHistoryGen
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
            this.tpATHGen = new System.Windows.Forms.TabPage();
            this.tpATHExcel = new System.Windows.Forms.TabPage();
            this.nudDT = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudATHCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpATHGen.SuspendLayout();
            this.tpATHExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudATHCount)).BeginInit();
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
            this.txtLP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccelerationTimeHistoryGen.Properties.Settings.Default, "LP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLP.Location = new System.Drawing.Point(82, 56);
            this.txtLP.Name = "txtLP";
            this.txtLP.Size = new System.Drawing.Size(100, 20);
            this.txtLP.TabIndex = 8;
            this.txtLP.Text = global::AccelerationTimeHistoryGen.Properties.Settings.Default.LP;
            // 
            // txtHP
            // 
            this.txtHP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccelerationTimeHistoryGen.Properties.Settings.Default, "HP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHP.Location = new System.Drawing.Point(82, 30);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(100, 20);
            this.txtHP.TabIndex = 6;
            this.txtHP.Text = global::AccelerationTimeHistoryGen.Properties.Settings.Default.HP;
            // 
            // txtDT
            // 
            this.txtDT.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccelerationTimeHistoryGen.Properties.Settings.Default, "DT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDT.Location = new System.Drawing.Point(82, 84);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(100, 20);
            this.txtDT.TabIndex = 4;
            this.txtDT.Text = global::AccelerationTimeHistoryGen.Properties.Settings.Default.DT;
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
            this.chkCopyFile.Checked = global::AccelerationTimeHistoryGen.Properties.Settings.Default.CopyTHFile;
            this.chkCopyFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AccelerationTimeHistoryGen.Properties.Settings.Default, "CopyTHFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.txtShake91.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccelerationTimeHistoryGen.Properties.Settings.Default, "Shake91", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShake91.Location = new System.Drawing.Point(113, 26);
            this.txtShake91.Name = "txtShake91";
            this.txtShake91.Size = new System.Drawing.Size(330, 20);
            this.txtShake91.TabIndex = 12;
            this.txtShake91.Text = global::AccelerationTimeHistoryGen.Properties.Settings.Default.Shake91;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpATHGen);
            this.tabControl1.Controls.Add(this.tpATHExcel);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 538);
            this.tabControl1.TabIndex = 13;
            // 
            // tpATHGen
            // 
            this.tpATHGen.Controls.Add(this.label4);
            this.tpATHGen.Controls.Add(this.groupBox2);
            this.tpATHGen.Controls.Add(this.groupBox1);
            this.tpATHGen.Location = new System.Drawing.Point(4, 22);
            this.tpATHGen.Name = "tpATHGen";
            this.tpATHGen.Padding = new System.Windows.Forms.Padding(3);
            this.tpATHGen.Size = new System.Drawing.Size(677, 512);
            this.tpATHGen.TabIndex = 0;
            this.tpATHGen.Text = "ATH Generator";
            this.tpATHGen.UseVisualStyleBackColor = true;
            this.tpATHGen.DragEnter += new System.Windows.Forms.DragEventHandler(this.tpATHGen_DragEnter);
            // 
            // tpATHExcel
            // 
            this.tpATHExcel.AllowDrop = true;
            this.tpATHExcel.Controls.Add(this.label8);
            this.tpATHExcel.Controls.Add(this.nudATHCount);
            this.tpATHExcel.Controls.Add(this.label7);
            this.tpATHExcel.Controls.Add(this.nudDT);
            this.tpATHExcel.Controls.Add(this.label6);
            this.tpATHExcel.Location = new System.Drawing.Point(4, 22);
            this.tpATHExcel.Name = "tpATHExcel";
            this.tpATHExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tpATHExcel.Size = new System.Drawing.Size(677, 512);
            this.tpATHExcel.TabIndex = 1;
            this.tpATHExcel.Text = "ATH to Excel";
            this.tpATHExcel.UseVisualStyleBackColor = true;
            this.tpATHExcel.DragDrop += new System.Windows.Forms.DragEventHandler(this.tpATHExcel_DragDrop);
            this.tpATHExcel.DragEnter += new System.Windows.Forms.DragEventHandler(this.tpATHExcel_DragEnter);
            // 
            // nudDT
            // 
            this.nudDT.Location = new System.Drawing.Point(103, 83);
            this.nudDT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDT.Name = "nudDT";
            this.nudDT.Size = new System.Drawing.Size(120, 20);
            this.nudDT.TabIndex = 6;
            this.nudDT.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "DT (ms)";
            // 
            // nudATHCount
            // 
            this.nudATHCount.Location = new System.Drawing.Point(103, 57);
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
            this.nudATHCount.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Line Count";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Drag && Drop a Shake91 Time History file";
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 562);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Earthquake Analysis Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpATHGen.ResumeLayout(false);
            this.tpATHGen.PerformLayout();
            this.tpATHExcel.ResumeLayout(false);
            this.tpATHExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudATHCount)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.NumericUpDown nudDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudATHCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

