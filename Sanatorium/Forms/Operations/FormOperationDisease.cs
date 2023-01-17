using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sanatorium.Forms
{
    public partial class FormOperationDisease : Form
    {
        OperationsDataBase operations = new OperationsDataBase();
        string tablePrimary = "Diagnosis";
        public string QueryDate { get; set; }

        public FormOperationDisease()
        {
            InitializeComponent();
        }

        private void FormOperationDisease_Load(object sender, EventArgs e)
        {
            LoadTheme();
            lblTextTitleForm.Text = this.Text;
            FillChart();
            FillDate($"SELECT RecordSunCurrortBook.NumRecordSunCurrortBook as 'Номер записи', SunCurrortBook.SunCurrortBookID as 'ID Санаторной книги', Patient.LastName as 'Фамилия', Patient.FirstName as 'Имя', Patient.MiddleName as 'Отчество', Diagnosis.Diagnosis as 'Диагноз', Disease.NameDisease as 'Болезнь', Medication.NameMedication as 'Лекарства', Services.NameServices as 'Услуги', Specialist.LastName as 'Лечащий врач', RecordSunCurrortBook.Date as 'Дата записи'  FROM SunCurrortBook " +
                                "JOIN RecordSunCurrortBook ON RecordSunCurrortBook.SunCurrortBookID = SunCurrortBook.SunCurrortBookID " +
                                "JOIN Diagnosis ON Diagnosis.DiagnosisID = RecordSunCurrortBook.DiagnosisID " +
                                "JOIN Disease ON Disease.DiseaseID = Diagnosis.DiseaseID " +
                                "JOIN Appoint ON RecordSunCurrortBook.AppointID = Appoint.AppointID " +
                                "JOIN Medication ON Medication.MedicationID = Appoint.MedicationID " +
                                "JOIN Services ON Services.ServicesID = Appoint.ServicesID " +
                                "JOIN Patient ON Patient.PatientID = SunCurrortBook.PatientID " +
                                $"JOIN Specialist ON SunCurrortBook.SpecialistID = Specialist.SpecialistID {QueryDate}" +
                                "Group by RecordSunCurrortBook.NumRecordSunCurrortBook, SunCurrortBook.SunCurrortBookID, Patient.LastName, Patient.FirstName, Patient.MiddleName, Diagnosis.Diagnosis, Medication.NameMedication, Services.NameServices, Specialist.LastName, Disease.NameDisease, RecordSunCurrortBook.Date");
            lblCol.Text = dgvDataBase.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells[0].Value)).ToString();

        }

        private void FillDate(string Query)
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = SqlConnection.GetData($"{Query}", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        private void FillChart()
        {
            FillDate($"SELECT Disease.NameDisease, Count(Disease.NameDisease), RecordSunCurrortBook.Date FROM Disease " +
                $"JOIN Diagnosis ON Diagnosis.DiseaseID = Disease.DiseaseID " +
                $"JOIN RecordSunCurrortBook ON RecordSunCurrortBook.DiagnosisID = Diagnosis.DiagnosisID {QueryDate}" +
                $"Group by  Disease.NameDisease, RecordSunCurrortBook.Date Order by Count(Disease.NameDisease) DESC");
            operations.CreateChartPrimary(chart1, dgvDataBase, SeriesChartType.Column, 2, 1);

            FillDate($"SELECT Distinct Disease.NameDisease, Count(Disease.NameDisease) OVER(PARTITION BY Disease.NameDisease) FROM SunCurrortBook " +
                     "JOIN RecordSunCurrortBook ON RecordSunCurrortBook.SunCurrortBookID = SunCurrortBook.SunCurrortBookID " +
                     "JOIN Diagnosis ON RecordSunCurrortBook.DiagnosisID = Diagnosis.DiagnosisID " +
                    $"JOIN Disease ON Disease.DiseaseID = Diagnosis.DiseaseID { QueryDate}" +
                     "Group by RecordSunCurrortBook.NumRecordSunCurrortBook, Disease.NameDisease, SunCurrortBook.SunCurrortBookID, RecordSunCurrortBook.Date");
            lblMax.Text = operations.ReturnDistributed(dgvDataBase, 1);
            lblMin.Text = operations.ReturnNonDistributed(dgvDataBase, 1);
            operations.CreateChartSecondary(chart2, dgvDataBase, SeriesChartType.Doughnut, 0, 1);
        }
        
        private void OpenChildForm(Form childForm, object btnSender)
        {
            this.Dispose();
            this.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }//Открытие дочерней формы

        private void LoadTheme()
        {
            foreach (Control panel in this.panelDesktop.Controls)
            {
                foreach (Control item in panel.Controls)
                {
                    if (item.GetType() == typeof(Label)) item.ForeColor = ThemeColor.PrimaryColor;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => OpenChildForm(new FormListPatient(), sender);

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            QueryDate = "Where DATEPART(m, RecordSunCurrortBook.Date) = DATEPART(m, DATEADD(m, 0, getdate()))AND DATEPART(yyyy, RecordSunCurrortBook.Date) = DATEPART(yyyy, DATEADD(m, 0, getdate())) ";
            FormOperationDisease_Load(sender, e);
        }

        private void btnLast30days_Click(object sender, EventArgs e)
        {
            QueryDate = "Where RecordSunCurrortBook.Date >= DATEADD(day, -30, GETDATE()) and RecordSunCurrortBook.Date <= GETDATE() ";
            FormOperationDisease_Load(sender, e);
        }

        private void btnLast7days_Click(object sender, EventArgs e)
        {
            QueryDate = "Where RecordSunCurrortBook.Date >= DATEADD(day, -7, GETDATE()) and RecordSunCurrortBook.Date <= GETDATE() ";
            FormOperationDisease_Load(sender, e);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            QueryDate = $"Where RecordSunCurrortBook.Date = '{DateTime.Now.Date.ToString()}' ";
            FormOperationDisease_Load(sender, e);
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            QueryDate = $"Where RecordSunCurrortBook.Date>= '{dtpStartDate.Value}' and RecordSunCurrortBook.Date <= '{dtpEndDate.Value}' ";
            FormOperationDisease_Load(sender, e);
        }

        private void btbAllTime_Click(object sender, EventArgs e)
        {
            QueryDate = "";
            FormOperationDisease_Load(sender, e);
        }
    }
}
