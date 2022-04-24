
namespace Sanatorium.Forms
{
    partial class ReportingDiagnosis
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTextTitleForm = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.sanatoriumDataSet = new Sanatorium.SanatoriumDataSet();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicesTableAdapter = new Sanatorium.SanatoriumDataSetTableAdapters.ServicesTableAdapter();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sanatoriumDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSetServices";
            reportDataSource1.Value = this.servicesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sanatorium.Forms.ReportingTables.Reporting.ReportServices.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 50);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(10);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(928, 432);
            this.reportViewer1.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitleBar.BackColor = System.Drawing.Color.White;
            this.panelTitleBar.Controls.Add(this.btnBack);
            this.panelTitleBar.Controls.Add(this.lblTextTitleForm);
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(948, 40);
            this.panelTitleBar.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Montserrat", 15F);
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Image = global::Sanatorium.Properties.Resources.icons8_двойная_стрелка_влево_24;
            this.btnBack.Location = new System.Drawing.Point(3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(33, 35);
            this.btnBack.TabIndex = 3;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTextTitleForm
            // 
            this.lblTextTitleForm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTextTitleForm.AutoSize = true;
            this.lblTextTitleForm.Font = new System.Drawing.Font("Montserrat", 12F);
            this.lblTextTitleForm.Location = new System.Drawing.Point(42, 8);
            this.lblTextTitleForm.Name = "lblTextTitleForm";
            this.lblTextTitleForm.Size = new System.Drawing.Size(128, 22);
            this.lblTextTitleForm.TabIndex = 0;
            this.lblTextTitleForm.Text = "Data Grid View";
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.panelTitleBar);
            this.panelDesktop.Controls.Add(this.reportViewer1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(948, 492);
            this.panelDesktop.TabIndex = 3;
            // 
            // sanatoriumDataSet
            // 
            this.sanatoriumDataSet.DataSetName = "SanatoriumDataSet";
            this.sanatoriumDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataMember = "Services";
            this.servicesBindingSource.DataSource = this.sanatoriumDataSet;
            // 
            // servicesTableAdapter
            // 
            this.servicesTableAdapter.ClearBeforeFill = true;
            // 
            // ReportingDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 492);
            this.Controls.Add(this.panelDesktop);
            this.Name = "ReportingDiagnosis";
            this.Text = "Отчёт по услугам";
            this.Load += new System.EventHandler(this.ReportingDiagnosis_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sanatoriumDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTextTitleForm;
        private System.Windows.Forms.Panel panelDesktop;
        private SanatoriumDataSet sanatoriumDataSet;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private SanatoriumDataSetTableAdapters.ServicesTableAdapter servicesTableAdapter;
    }
}