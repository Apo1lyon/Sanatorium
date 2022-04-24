﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorium.Forms
{
    public partial class ReportingDiagnosis : Form
    {
        public ReportingDiagnosis()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
        }

        private void ReportingDiagnosis_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sanatoriumDataSet.Services". При необходимости она может быть перемещена или удалена.
            this.servicesTableAdapter.Fill(this.sanatoriumDataSet.Services);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void OpenChildForm(System.Windows.Forms.Form childForm, object btnSender)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }//Открытие дочерней формы

        private void btnBack_Click(object sender, EventArgs e) => OpenChildForm(new FormListReporting(), sender);
    }
}
