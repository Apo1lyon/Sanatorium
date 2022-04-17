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
    public partial class FormOperation : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        OperationsDataBase operations = new OperationsDataBase();
        string tablePrimary = "Diagnosis";

        public FormOperation()
        {
            InitializeComponent();
        }

        private void FormOperation_Load(object sender, EventArgs e)
        {
            LoadTheme();
            lblTextTitleForm.Text = this.Text;
            FillChart();
            FillDate("SELECT Diagnosis.NumDiagnosis as 'Номер Диагноза', Diagnosis.DiagnosisID as 'ID Диагноза', Disease.NameDisease as 'Болезнь', " +
                "Disease.TypeOfDisease as 'Тип болезни', Disease.Symptoms as 'Симптомы', Diagnosis.Complications as 'Осложнения', " +
                "Diagnosis.Diagnosis as 'Диагноз', Diagnosis.Date as 'Дата' FROM Diagnosis JOIN Disease ON Diagnosis.DiseaseID = Disease.DiseaseID " +
                "Group by Diagnosis.NumDiagnosis, Diagnosis.DiagnosisID, Disease.NameDisease, Disease.TypeOfDisease, Disease.Symptoms, " +
                "Diagnosis.Complications, Diagnosis.Diagnosis, Diagnosis.Date");
        }

        private void FillDate(string Query)
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"{Query}", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        private void FillChart()
        {
            FillDate("SELECT Disease.NameDisease AS Болезнь, Disease.TypeOfDisease AS ТипБолезни, Disease.Reason AS Причина, Disease.Symptoms AS Симптом, COUNT(Disease.NameDisease) AS Колличество, Diagnosis.Date as Дата FROM Diagnosis JOIN Disease ON Diagnosis.DiseaseID = Disease.DiseaseID GROUP BY Disease.NameDisease, Disease.TypeOfDisease, Disease.Reason, Disease.Symptoms, Diagnosis.Date Order by COUNT(Disease.NameDisease) DESC");
            operations.CreateChartPrimary(chart1, dgvDataBase, SeriesChartType.Column, 5, 4);
            FillDate("SELECT Distinct Disease.NameDisease AS Болезнь, Disease.TypeOfDisease AS ТипБолезни, Disease.Reason AS Причина, Disease.Symptoms AS Симптом, COUNT(Disease.NameDisease) OVER(PARTITION BY Disease.NameDisease) AS Колличество FROM Diagnosis JOIN Disease ON Diagnosis.DiseaseID = Disease.DiseaseID GROUP BY Disease.NameDisease, Disease.TypeOfDisease, Disease.Reason, Disease.Symptoms, Diagnosis.Date");
            operations.CreateChartSecondary(chart2, dgvDataBase, SeriesChartType.Doughnut, 0, 4);
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

        private void btnClose_Click(object sender, EventArgs e) => OpenChildForm(new FormListPatient(), sender);
    }
}
