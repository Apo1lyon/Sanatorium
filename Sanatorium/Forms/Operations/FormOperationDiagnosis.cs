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
    public partial class FormOperationDiagnosis : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        OperationsDataBase operations = new OperationsDataBase();
        string tablePrimary = "SunCurrortBook";
        public string QueryDate { get; set; }

        public FormOperationDiagnosis()
        {
            InitializeComponent();
        }

        private void FormOperationDiagnosis_Load(object sender, EventArgs e)
        {
            LoadTheme();
            lblTextTitleForm.Text = this.Text;
            FillChart();
            FillDate($"SELECT RecordSunCurrortBook.NumRecordSunCurrortBook as 'Номер записи', SunCurrortBook.SunCurrortBookID as 'ID Санаторной книги', Patient.LastName as 'Фамилия', Patient.FirstName as 'Имя', Patient.MiddleName as 'Отчество', Diagnosis.Diagnosis as 'Диагноз', Medication.NameMedication as 'Лекарства', Services.NameServices as 'Услуги', Specialist.LastName as 'Лечащий врач', RecordSunCurrortBook.Date as 'Дата записи'  FROM SunCurrortBook " +
                    "JOIN RecordSunCurrortBook ON RecordSunCurrortBook.SunCurrortBookID = SunCurrortBook.SunCurrortBookID " +
                    "JOIN Diagnosis ON Diagnosis.DiagnosisID = RecordSunCurrortBook.DiagnosisID " +
                    "JOIN Appoint ON RecordSunCurrortBook.AppointID = Appoint.AppointID " +
                    "JOIN Medication ON Medication.MedicationID = Appoint.MedicationID " +
                    "JOIN Services ON Services.ServicesID = Appoint.ServicesID " +
                    "JOIN Patient ON Patient.PatientID = SunCurrortBook.PatientID " +
                    $"JOIN Specialist ON SunCurrortBook.SpecialistID = Specialist.SpecialistID {QueryDate}" +
                    "Group by RecordSunCurrortBook.NumRecordSunCurrortBook, SunCurrortBook.SunCurrortBookID, Patient.LastName, Patient.FirstName, Patient.MiddleName, Diagnosis.Diagnosis, Medication.NameMedication, Services.NameServices, Specialist.LastName, RecordSunCurrortBook.Date");
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
            FillDate($"SELECT Diagnosis.Diagnosis, Count(Diagnosis.Diagnosis), RecordSunCurrortBook.Date FROM Diagnosis " +
                    $"JOIN RecordSunCurrortBook ON RecordSunCurrortBook.DiagnosisID = Diagnosis.DiagnosisID {QueryDate}" +
                    $"Group by  Diagnosis.Diagnosis, RecordSunCurrortBook.Date Order by COUNT(Diagnosis.Diagnosis) DESC");
            operations.CreateChartPrimary(chart1, dgvDataBase, SeriesChartType.Column, 2, 1);

            FillDate($"SELECT Distinct Diagnosis.Diagnosis, Count(Diagnosis.Diagnosis) OVER(PARTITION BY Diagnosis.Diagnosis) FROM SunCurrortBook " +
                        "JOIN RecordSunCurrortBook ON RecordSunCurrortBook.SunCurrortBookID = SunCurrortBook.SunCurrortBookID " +
                        $"JOIN Diagnosis ON RecordSunCurrortBook.DiagnosisID = Diagnosis.DiagnosisID {QueryDate}" +
                        "Group by RecordSunCurrortBook.NumRecordSunCurrortBook, Diagnosis.Diagnosis, SunCurrortBook.SunCurrortBookID, RecordSunCurrortBook.Date");
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
            FormOperationDiagnosis_Load(sender, e);
        }

        private void btnLast30days_Click(object sender, EventArgs e)
        {
            QueryDate = "Where RecordSunCurrortBook.Date >= DATEADD(day, -30, GETDATE()) and RecordSunCurrortBook.Date <= GETDATE() ";
            FormOperationDiagnosis_Load(sender, e);
        }

        private void btnLast7days_Click(object sender, EventArgs e)
        {
            QueryDate = "Where RecordSunCurrortBook.Date >= DATEADD(day, -7, GETDATE()) and RecordSunCurrortBook.Date <= GETDATE() ";
            FormOperationDiagnosis_Load(sender, e);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            QueryDate = $"Where RecordSunCurrortBook.Date = '{DateTime.Now.Date.ToString()}' ";
            FormOperationDiagnosis_Load(sender, e);
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            QueryDate = $"Where RecordSunCurrortBook.Date >= '{dtpStartDate.Value}' and RecordSunCurrortBook.Date <= '{dtpEndDate.Value}' ";
            FormOperationDiagnosis_Load(sender, e);
        }

        private void btbAllTime_Click(object sender, EventArgs e)
        {
            QueryDate = "";
            FormOperationDiagnosis_Load(sender, e);
        }
    }
}
