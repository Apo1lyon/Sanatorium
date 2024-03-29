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
    public partial class FormListPatient : Form
    {
        public FormListPatient()
        {
            InitializeComponent();
        }

        private void FormListPatient_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control item in this.panelDesktop.Controls)
            {
                if (item.GetType() == typeof(Label)) item.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        
        private void OpenChildForm(Form childForm, object btnSender)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }//Открытие дочерней формы
        
        private void FormDisease_Click(object sender, EventArgs e) => OpenChildForm(new FormDisease(), sender);
        
        private void FormMedication_Click(object sender, EventArgs e) => OpenChildForm(new FormMedication(), sender);
        
        private void FormPatient_Click(object sender, EventArgs e) => OpenChildForm(new FormPatient(), sender);
        
        private void FormDiagnosis_Click(object sender, EventArgs e) => OpenChildForm(new FormDiagnosis(), sender);

        private void FormAppoint_Click(object sender, EventArgs e) => OpenChildForm(new FormAppoint(), sender);

        private void FormSunCurrortBook_Click(object sender, EventArgs e) => OpenChildForm(new FormSunCurrortBook(), sender);
        
        private void FormRecordSunCurrortBook_Click(object sender, EventArgs e) => OpenChildForm(new FormRecordSunCurrortBook(), sender);
        
        private void FormOperationMedication_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationMedication(), sender);

        private void FormOperationPatient_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationPatient(), sender);

        private void FormOperationDisease_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationDisease(), sender);

        private void FormOperationDiagnosis_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationDiagnosis(), sender);
    }
}
