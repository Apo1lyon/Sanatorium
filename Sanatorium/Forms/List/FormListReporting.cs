using System;
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
    public partial class FormListReporting : Form
    {
        public FormListReporting()
        {
            InitializeComponent();
        }

        private void FormListReporting_Load(object sender, EventArgs e)
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

        private void FormReportingServices_Click(object sender, EventArgs e) => OpenChildForm(new ReportingServices(), sender);

        private void FormReportingDiagnosis_Click(object sender, EventArgs e) => OpenChildForm(new ReportingDiagnosis(), sender);

        private void FormReportingPatient_Click(object sender, EventArgs e) => OpenChildForm(new ReportingPatient(), sender);

        private void FormReportingSpecialist_Click(object sender, EventArgs e) => OpenChildForm(new ReportingSpecialist(), sender);

        private void FormReportingMedication_Click(object sender, EventArgs e) => OpenChildForm(new ReportingMedication(), sender);
        
        private void FormReportingDisease_Click(object sender, EventArgs e) => OpenChildForm(new ReportingDisease(), sender);

        private void FormReportingDoctorOffice_Click(object sender, EventArgs e) => OpenChildForm(new ReportingDoctorOffice(), sender);

        private void FormReportingSpecialty_Click(object sender, EventArgs e) => OpenChildForm(new ReportingSpecialty(), sender);

        private void FormReportingAppoint_Click(object sender, EventArgs e) => OpenChildForm(new ReportingAppoint(), sender);

        private void FormReportingSunCurrortBook_Click(object sender, EventArgs e) => OpenChildForm(new ReportingSunCurrortBook(), sender);

        private void FormReportingRecordSunCurrortBook_Click(object sender, EventArgs e) => OpenChildForm(new ReportingRecordSunCurrortBook(), sender);
    }
}
