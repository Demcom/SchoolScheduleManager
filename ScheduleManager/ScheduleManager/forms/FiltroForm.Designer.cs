namespace ScheduleManager.forms
{
    partial class TestData
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.scheduleManagerDataSet = new ScheduleManager.ScheduleManagerDataSet();
            this.estructuraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estructuraTableAdapter = new ScheduleManager.ScheduleManagerDataSetTableAdapters.EstructuraTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccdepcveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccpercveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccpertarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccpernomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccplmcveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccperaraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cccatcveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccplmhrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cchfglicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cchfgposDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccdesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccfacDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ccmotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccmatcveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccmatncoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccmathteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccmathprDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccngpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cccarncoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cctitncoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccesrcedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccperrfcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccacdncoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccacdhrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccmatnomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleManagerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estructuraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.ccdepcveDataGridViewTextBoxColumn,
            this.ccpercveDataGridViewTextBoxColumn,
            this.ccpertarDataGridViewTextBoxColumn,
            this.ccpernomDataGridViewTextBoxColumn,
            this.ccplmcveDataGridViewTextBoxColumn,
            this.ccperaraDataGridViewTextBoxColumn,
            this.cccatcveDataGridViewTextBoxColumn,
            this.ccplmhrsDataGridViewTextBoxColumn,
            this.cchfglicDataGridViewTextBoxColumn,
            this.cchfgposDataGridViewTextBoxColumn,
            this.ccdesDataGridViewTextBoxColumn,
            this.ccfacDataGridViewCheckBoxColumn,
            this.ccmotDataGridViewTextBoxColumn,
            this.ccmatcveDataGridViewTextBoxColumn,
            this.ccmatncoDataGridViewTextBoxColumn,
            this.ccmathteDataGridViewTextBoxColumn,
            this.ccmathprDataGridViewTextBoxColumn,
            this.ccngpDataGridViewTextBoxColumn,
            this.cccarncoDataGridViewTextBoxColumn,
            this.cctitncoDataGridViewTextBoxColumn,
            this.ccesrcedDataGridViewTextBoxColumn,
            this.ccperrfcDataGridViewTextBoxColumn,
            this.ccacdncoDataGridViewTextBoxColumn,
            this.ccacdhrsDataGridViewTextBoxColumn,
            this.ccmatnomDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.estructuraBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(830, 236);
            this.dataGridView1.TabIndex = 0;
            // 
            // scheduleManagerDataSet
            // 
            this.scheduleManagerDataSet.DataSetName = "ScheduleManagerDataSet";
            this.scheduleManagerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estructuraBindingSource
            // 
            this.estructuraBindingSource.DataMember = "Estructura";
            this.estructuraBindingSource.DataSource = this.scheduleManagerDataSet;
            // 
            // estructuraTableAdapter
            // 
            this.estructuraTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ccdepcveDataGridViewTextBoxColumn
            // 
            this.ccdepcveDataGridViewTextBoxColumn.DataPropertyName = "ccdepcve";
            this.ccdepcveDataGridViewTextBoxColumn.HeaderText = "ccdepcve";
            this.ccdepcveDataGridViewTextBoxColumn.Name = "ccdepcveDataGridViewTextBoxColumn";
            // 
            // ccpercveDataGridViewTextBoxColumn
            // 
            this.ccpercveDataGridViewTextBoxColumn.DataPropertyName = "ccpercve";
            this.ccpercveDataGridViewTextBoxColumn.HeaderText = "ccpercve";
            this.ccpercveDataGridViewTextBoxColumn.Name = "ccpercveDataGridViewTextBoxColumn";
            // 
            // ccpertarDataGridViewTextBoxColumn
            // 
            this.ccpertarDataGridViewTextBoxColumn.DataPropertyName = "ccpertar";
            this.ccpertarDataGridViewTextBoxColumn.HeaderText = "ccpertar";
            this.ccpertarDataGridViewTextBoxColumn.Name = "ccpertarDataGridViewTextBoxColumn";
            // 
            // ccpernomDataGridViewTextBoxColumn
            // 
            this.ccpernomDataGridViewTextBoxColumn.DataPropertyName = "ccpernom";
            this.ccpernomDataGridViewTextBoxColumn.HeaderText = "ccpernom";
            this.ccpernomDataGridViewTextBoxColumn.Name = "ccpernomDataGridViewTextBoxColumn";
            // 
            // ccplmcveDataGridViewTextBoxColumn
            // 
            this.ccplmcveDataGridViewTextBoxColumn.DataPropertyName = "ccplmcve";
            this.ccplmcveDataGridViewTextBoxColumn.HeaderText = "ccplmcve";
            this.ccplmcveDataGridViewTextBoxColumn.Name = "ccplmcveDataGridViewTextBoxColumn";
            // 
            // ccperaraDataGridViewTextBoxColumn
            // 
            this.ccperaraDataGridViewTextBoxColumn.DataPropertyName = "ccperara";
            this.ccperaraDataGridViewTextBoxColumn.HeaderText = "ccperara";
            this.ccperaraDataGridViewTextBoxColumn.Name = "ccperaraDataGridViewTextBoxColumn";
            // 
            // cccatcveDataGridViewTextBoxColumn
            // 
            this.cccatcveDataGridViewTextBoxColumn.DataPropertyName = "cccatcve";
            this.cccatcveDataGridViewTextBoxColumn.HeaderText = "cccatcve";
            this.cccatcveDataGridViewTextBoxColumn.Name = "cccatcveDataGridViewTextBoxColumn";
            // 
            // ccplmhrsDataGridViewTextBoxColumn
            // 
            this.ccplmhrsDataGridViewTextBoxColumn.DataPropertyName = "ccplmhrs";
            this.ccplmhrsDataGridViewTextBoxColumn.HeaderText = "ccplmhrs";
            this.ccplmhrsDataGridViewTextBoxColumn.Name = "ccplmhrsDataGridViewTextBoxColumn";
            // 
            // cchfglicDataGridViewTextBoxColumn
            // 
            this.cchfglicDataGridViewTextBoxColumn.DataPropertyName = "cchfglic";
            this.cchfglicDataGridViewTextBoxColumn.HeaderText = "cchfglic";
            this.cchfglicDataGridViewTextBoxColumn.Name = "cchfglicDataGridViewTextBoxColumn";
            // 
            // cchfgposDataGridViewTextBoxColumn
            // 
            this.cchfgposDataGridViewTextBoxColumn.DataPropertyName = "cchfgpos";
            this.cchfgposDataGridViewTextBoxColumn.HeaderText = "cchfgpos";
            this.cchfgposDataGridViewTextBoxColumn.Name = "cchfgposDataGridViewTextBoxColumn";
            // 
            // ccdesDataGridViewTextBoxColumn
            // 
            this.ccdesDataGridViewTextBoxColumn.DataPropertyName = "ccdes";
            this.ccdesDataGridViewTextBoxColumn.HeaderText = "ccdes";
            this.ccdesDataGridViewTextBoxColumn.Name = "ccdesDataGridViewTextBoxColumn";
            // 
            // ccfacDataGridViewCheckBoxColumn
            // 
            this.ccfacDataGridViewCheckBoxColumn.DataPropertyName = "ccfac";
            this.ccfacDataGridViewCheckBoxColumn.HeaderText = "ccfac";
            this.ccfacDataGridViewCheckBoxColumn.Name = "ccfacDataGridViewCheckBoxColumn";
            // 
            // ccmotDataGridViewTextBoxColumn
            // 
            this.ccmotDataGridViewTextBoxColumn.DataPropertyName = "ccmot";
            this.ccmotDataGridViewTextBoxColumn.HeaderText = "ccmot";
            this.ccmotDataGridViewTextBoxColumn.Name = "ccmotDataGridViewTextBoxColumn";
            // 
            // ccmatcveDataGridViewTextBoxColumn
            // 
            this.ccmatcveDataGridViewTextBoxColumn.DataPropertyName = "ccmatcve";
            this.ccmatcveDataGridViewTextBoxColumn.HeaderText = "ccmatcve";
            this.ccmatcveDataGridViewTextBoxColumn.Name = "ccmatcveDataGridViewTextBoxColumn";
            // 
            // ccmatncoDataGridViewTextBoxColumn
            // 
            this.ccmatncoDataGridViewTextBoxColumn.DataPropertyName = "ccmatnco";
            this.ccmatncoDataGridViewTextBoxColumn.HeaderText = "ccmatnco";
            this.ccmatncoDataGridViewTextBoxColumn.Name = "ccmatncoDataGridViewTextBoxColumn";
            // 
            // ccmathteDataGridViewTextBoxColumn
            // 
            this.ccmathteDataGridViewTextBoxColumn.DataPropertyName = "ccmathte";
            this.ccmathteDataGridViewTextBoxColumn.HeaderText = "ccmathte";
            this.ccmathteDataGridViewTextBoxColumn.Name = "ccmathteDataGridViewTextBoxColumn";
            // 
            // ccmathprDataGridViewTextBoxColumn
            // 
            this.ccmathprDataGridViewTextBoxColumn.DataPropertyName = "ccmathpr";
            this.ccmathprDataGridViewTextBoxColumn.HeaderText = "ccmathpr";
            this.ccmathprDataGridViewTextBoxColumn.Name = "ccmathprDataGridViewTextBoxColumn";
            // 
            // ccngpDataGridViewTextBoxColumn
            // 
            this.ccngpDataGridViewTextBoxColumn.DataPropertyName = "ccngp";
            this.ccngpDataGridViewTextBoxColumn.HeaderText = "ccngp";
            this.ccngpDataGridViewTextBoxColumn.Name = "ccngpDataGridViewTextBoxColumn";
            // 
            // cccarncoDataGridViewTextBoxColumn
            // 
            this.cccarncoDataGridViewTextBoxColumn.DataPropertyName = "cccarnco";
            this.cccarncoDataGridViewTextBoxColumn.HeaderText = "cccarnco";
            this.cccarncoDataGridViewTextBoxColumn.Name = "cccarncoDataGridViewTextBoxColumn";
            // 
            // cctitncoDataGridViewTextBoxColumn
            // 
            this.cctitncoDataGridViewTextBoxColumn.DataPropertyName = "cctitnco";
            this.cctitncoDataGridViewTextBoxColumn.HeaderText = "cctitnco";
            this.cctitncoDataGridViewTextBoxColumn.Name = "cctitncoDataGridViewTextBoxColumn";
            // 
            // ccesrcedDataGridViewTextBoxColumn
            // 
            this.ccesrcedDataGridViewTextBoxColumn.DataPropertyName = "ccesrced";
            this.ccesrcedDataGridViewTextBoxColumn.HeaderText = "ccesrced";
            this.ccesrcedDataGridViewTextBoxColumn.Name = "ccesrcedDataGridViewTextBoxColumn";
            // 
            // ccperrfcDataGridViewTextBoxColumn
            // 
            this.ccperrfcDataGridViewTextBoxColumn.DataPropertyName = "ccperrfc";
            this.ccperrfcDataGridViewTextBoxColumn.HeaderText = "ccperrfc";
            this.ccperrfcDataGridViewTextBoxColumn.Name = "ccperrfcDataGridViewTextBoxColumn";
            // 
            // ccacdncoDataGridViewTextBoxColumn
            // 
            this.ccacdncoDataGridViewTextBoxColumn.DataPropertyName = "ccacdnco";
            this.ccacdncoDataGridViewTextBoxColumn.HeaderText = "ccacdnco";
            this.ccacdncoDataGridViewTextBoxColumn.Name = "ccacdncoDataGridViewTextBoxColumn";
            // 
            // ccacdhrsDataGridViewTextBoxColumn
            // 
            this.ccacdhrsDataGridViewTextBoxColumn.DataPropertyName = "ccacdhrs";
            this.ccacdhrsDataGridViewTextBoxColumn.HeaderText = "ccacdhrs";
            this.ccacdhrsDataGridViewTextBoxColumn.Name = "ccacdhrsDataGridViewTextBoxColumn";
            // 
            // ccmatnomDataGridViewTextBoxColumn
            // 
            this.ccmatnomDataGridViewTextBoxColumn.DataPropertyName = "ccmatnom";
            this.ccmatnomDataGridViewTextBoxColumn.HeaderText = "ccmatnom";
            this.ccmatnomDataGridViewTextBoxColumn.Name = "ccmatnomDataGridViewTextBoxColumn";
            // 
            // TestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 261);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TestData";
            this.Text = "TestData";
            this.Load += new System.EventHandler(this.TestData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleManagerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estructuraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ScheduleManagerDataSet scheduleManagerDataSet;
        private System.Windows.Forms.BindingSource estructuraBindingSource;
        private ScheduleManagerDataSetTableAdapters.EstructuraTableAdapter estructuraTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccdepcveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccpercveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccpertarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccpernomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccplmcveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccperaraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cccatcveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccplmhrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cchfglicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cchfgposDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccdesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccfacDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccmotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccmatcveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccmatncoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccmathteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccmathprDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccngpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cccarncoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cctitncoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccesrcedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccperrfcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccacdncoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccacdhrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccmatnomDataGridViewTextBoxColumn;
    }
}