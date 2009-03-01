namespace AccelerationTimeHistoryGen
{
    partial class Form1
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(25, 57);
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
            this.label4.Location = new System.Drawing.Point(22, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(25, 221);
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
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 202);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceleration Time History file generator for Shake91";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

