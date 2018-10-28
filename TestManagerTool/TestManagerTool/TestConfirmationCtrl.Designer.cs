namespace TestManagerTool
{
    partial class TestConfirmationCtrl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ParameterPreview = new System.Windows.Forms.TextBox();
            this.TestParameterLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.testDataTableDataGridView = new System.Windows.Forms.DataGridView();
            this.testDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testCaseDataSet = new TestManagerTool.TestCaseDataSet();
            this.TestNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestEnableColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.testDataTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ParameterPreview
            // 
            this.ParameterPreview.Location = new System.Drawing.Point(318, 33);
            this.ParameterPreview.Multiline = true;
            this.ParameterPreview.Name = "ParameterPreview";
            this.ParameterPreview.ReadOnly = true;
            this.ParameterPreview.Size = new System.Drawing.Size(300, 264);
            this.ParameterPreview.TabIndex = 1;
            // 
            // TestParameterLabel
            // 
            this.TestParameterLabel.AutoSize = true;
            this.TestParameterLabel.Location = new System.Drawing.Point(316, 7);
            this.TestParameterLabel.Name = "TestParameterLabel";
            this.TestParameterLabel.Size = new System.Drawing.Size(84, 12);
            this.TestParameterLabel.TabIndex = 2;
            this.TestParameterLabel.Text = "Test Parameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test List";
            // 
            // testDataTableDataGridView
            // 
            this.testDataTableDataGridView.AllowUserToAddRows = false;
            this.testDataTableDataGridView.AllowUserToDeleteRows = false;
            this.testDataTableDataGridView.AutoGenerateColumns = false;
            this.testDataTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testDataTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestNumColumn,
            this.TestNameColumn,
            this.TestEnableColumn});
            this.testDataTableDataGridView.DataSource = this.testDataTableBindingSource;
            this.testDataTableDataGridView.Location = new System.Drawing.Point(12, 33);
            this.testDataTableDataGridView.MultiSelect = false;
            this.testDataTableDataGridView.Name = "testDataTableDataGridView";
            this.testDataTableDataGridView.ReadOnly = true;
            this.testDataTableDataGridView.RowTemplate.Height = 21;
            this.testDataTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.testDataTableDataGridView.Size = new System.Drawing.Size(300, 264);
            this.testDataTableDataGridView.TabIndex = 4;
            this.testDataTableDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TestDataTableDataGridView_CellContentClick);
            // 
            // testDataTableBindingSource
            // 
            this.testDataTableBindingSource.DataMember = "TestDataTable";
            this.testDataTableBindingSource.DataSource = this.testCaseDataSet;
            // 
            // testCaseDataSet
            // 
            this.testCaseDataSet.DataSetName = "TestCaseDataSet";
            this.testCaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TestNumColumn
            // 
            this.TestNumColumn.DataPropertyName = "TestNum";
            this.TestNumColumn.HeaderText = "#";
            this.TestNumColumn.Name = "TestNumColumn";
            this.TestNumColumn.ReadOnly = true;
            this.TestNumColumn.Width = 30;
            // 
            // TestNameColumn
            // 
            this.TestNameColumn.DataPropertyName = "Name";
            this.TestNameColumn.HeaderText = "Test Name";
            this.TestNameColumn.Name = "TestNameColumn";
            this.TestNameColumn.ReadOnly = true;
            this.TestNameColumn.Width = 175;
            // 
            // TestEnableColumn
            // 
            this.TestEnableColumn.DataPropertyName = "Enable";
            this.TestEnableColumn.HeaderText = "Enable";
            this.TestEnableColumn.Name = "TestEnableColumn";
            this.TestEnableColumn.ReadOnly = true;
            this.TestEnableColumn.Width = 50;
            // 
            // TestConfirmationCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testDataTableDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TestParameterLabel);
            this.Controls.Add(this.ParameterPreview);
            this.Name = "TestConfirmationCtrl";
            this.Size = new System.Drawing.Size(635, 312);
            ((System.ComponentModel.ISupportInitialize)(this.testDataTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ParameterPreview;
        private System.Windows.Forms.Label TestParameterLabel;
        private System.Windows.Forms.Label label2;
        private TestCaseDataSet testCaseDataSet;
        private System.Windows.Forms.BindingSource testDataTableBindingSource;
        private System.Windows.Forms.DataGridView testDataTableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TestEnableColumn;
    }
}
