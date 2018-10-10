namespace TestManagerTool
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.ComOpenClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.TestPathTxt = new System.Windows.Forms.TextBox();
            this.TestImportBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(38, 99);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadBtn.TabIndex = 0;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(38, 29);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 20);
            this.portComboBox.TabIndex = 1;
            // 
            // ComOpenClose
            // 
            this.ComOpenClose.Location = new System.Drawing.Point(177, 29);
            this.ComOpenClose.Name = "ComOpenClose";
            this.ComOpenClose.Size = new System.Drawing.Size(75, 23);
            this.ComOpenClose.TabIndex = 2;
            this.ComOpenClose.Text = "Open";
            this.ComOpenClose.UseVisualStyleBackColor = true;
            this.ComOpenClose.Click += new System.EventHandler(this.ComOpenClose_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(333, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(444, 254);
            this.textBox1.TabIndex = 3;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(38, 144);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(38, 182);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 5;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.Location = new System.Drawing.Point(702, 289);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearLogBtn.TabIndex = 6;
            this.ClearLogBtn.Text = "Clear Log";
            this.ClearLogBtn.UseVisualStyleBackColor = true;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // TestPathTxt
            // 
            this.TestPathTxt.Location = new System.Drawing.Point(38, 65);
            this.TestPathTxt.Name = "TestPathTxt";
            this.TestPathTxt.Size = new System.Drawing.Size(121, 19);
            this.TestPathTxt.TabIndex = 7;
            // 
            // TestImportBtn
            // 
            this.TestImportBtn.Location = new System.Drawing.Point(177, 63);
            this.TestImportBtn.Name = "TestImportBtn";
            this.TestImportBtn.Size = new System.Drawing.Size(75, 23);
            this.TestImportBtn.TabIndex = 8;
            this.TestImportBtn.Text = "Import Test";
            this.TestImportBtn.UseVisualStyleBackColor = true;
            this.TestImportBtn.Click += new System.EventHandler(this.TestImportBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 348);
            this.Controls.Add(this.TestImportBtn);
            this.Controls.Add(this.TestPathTxt);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ComOpenClose);
            this.Controls.Add(this.portComboBox);
            this.Controls.Add(this.LoadBtn);
            this.Name = "Form1";
            this.Text = "Test Manager Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadBtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button ComOpenClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button ClearLogBtn;
        private System.Windows.Forms.TextBox TestPathTxt;
        private System.Windows.Forms.Button TestImportBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

