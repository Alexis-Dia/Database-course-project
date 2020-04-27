namespace CourseProjectDB
{
    partial class PrintTaskForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.carriages_systemDataSet = new CourseProjectDB.carriages_systemDataSet();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskTableAdapter = new CourseProjectDB.carriages_systemDataSetTableAdapters.taskTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.carriages_systemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.taskBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CourseProjectDB.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(797, 392);
            this.reportViewer1.TabIndex = 0;
            // 
            // carriages_systemDataSet
            // 
            this.carriages_systemDataSet.DataSetName = "carriages_systemDataSet";
            this.carriages_systemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataMember = "task";
            this.taskBindingSource.DataSource = this.carriages_systemDataSet;
            // 
            // taskTableAdapter
            // 
            this.taskTableAdapter.ClearBeforeFill = true;
            // 
            // PrintTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintTaskForm";
            this.Text = "Страница печати отчетов";
            this.Load += new System.EventHandler(this.PrintTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carriages_systemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private carriages_systemDataSet carriages_systemDataSet;
        private carriages_systemDataSetTableAdapters.taskTableAdapter taskTableAdapter;
    }
}