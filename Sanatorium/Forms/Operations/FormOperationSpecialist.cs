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
    public partial class FormOperationSpecialist : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        OperationsDataBase operations = new OperationsDataBase();
        string tablePrimary = "SunCurrortBook";
        public string QueryDate { get; set; }

        public FormOperationSpecialist()
        {
            InitializeComponent();
        }

        private void FormOperationSpecialist_Load(object sender, EventArgs e)
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
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"{Query}", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        private void FillChart()
        {
            FillDate($"SELECT Distinct Specialist.LastName, Count(Specialist.LastName) OVER(PARTITION BY RecordSunCurrortBook.Date), RecordSunCurrortBook.Date FROM SunCurrortBook " +
                    "JOIN RecordSunCurrortBook ON RecordSunCurrortBook.SunCurrortBookID = SunCurrortBook.SunCurrortBookID " +
                    $"JOIN Specialist ON Specialist.SpecialistID = SunCurrortBook.SpecialistID {QueryDate}" +
                    "Group by RecordSunCurrortBook.NumRecordSunCurrortBook, Specialist.LastName, SunCurrortBook.SunCurrortBookID, RecordSunCurrortBook.Date");
            
            operations.CreateChartPrimary(chart1, dgvDataBase, SeriesChartType.Column, 2, 1);

            FillDate($"SELECT Distinct Specialist.LastName, Count(Specialist.LastName) OVER(PARTITION BY Specialist.LastName) FROM SunCurrortBook " +
                    "JOIN RecordSunCurrortBook ON RecordSunCurrortBook.SunCurrortBookID = SunCurrortBook.SunCurrortBookID " +
                    $"JOIN Specialist ON Specialist.SpecialistID = SunCurrortBook.SpecialistID {QueryDate}" +
                    "Group by RecordSunCurrortBook.NumRecordSunCurrortBook, Specialist.LastName, SunCurrortBook.SunCurrortBookID, RecordSunCurrortBook.Date");
            lblMax.Text = operations.ReturnDistributed(dgvDataBase, 1);
            lblMin.Text = operations.ReturnNonDistributed(dgvDataBase, 1);
            operations.CreateChartSecondary(chart2, dgvDataBase, SeriesChartType.Doughnut, 0, 1);
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

        private void btnClose_Click(object sender, EventArgs e) => OpenChildForm(new FormListPersonnel(), sender);

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            QueryDate = "Where DATEPART(m, RecordSunCurrortBook.Date) = DATEPART(m, DATEADD(m, 0, getdate()))AND DATEPART(yyyy, RecordSunCurrortBook.Date) = DATEPART(yyyy, DATEADD(m, 0, getdate())) ";
            FormOperationSpecialist_Load(sender, e);
        }

        private void btnLast30days_Click(object sender, EventArgs e)
        {
            QueryDate = "Where RecordSunCurrortBook.Date >= DATEADD(day, -30, GETDATE()) and RecordSunCurrortBook.Date <= GETDATE() ";
            FormOperationSpecialist_Load(sender, e);
        }

        private void btnLast7days_Click(object sender, EventArgs e)
        {
            QueryDate = "Where RecordSunCurrortBook.Date >= DATEADD(day, -7, GETDATE()) and RecordSunCurrortBook.Date <= GETDATE() ";
            FormOperationSpecialist_Load(sender, e);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            QueryDate = $"Where RecordSunCurrortBook.Date = '{DateTime.Now.Date.ToString()}' ";
            FormOperationSpecialist_Load(sender, e);
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            QueryDate = $"Where RecordSunCurrortBook.Date >= '{dtpStartDate.Value}' and RecordSunCurrortBook.Date <= '{dtpEndDate.Value}' ";
            FormOperationSpecialist_Load(sender, e);
        }

        private void btbAllTime_Click(object sender, EventArgs e)
        {
            QueryDate = "";
            FormOperationSpecialist_Load(sender, e);
        }
    }
}
