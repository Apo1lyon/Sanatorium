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
        string tableSecondary = "Disease";

        public FormOperation()
        {
            InitializeComponent();
            FillDate();
            operations.CreateChartColumn(chart1, dgvDataBase, 5, 4); 
            operations.CreateChartDoughnut(chart2, dgvDataBase, 0, 4);
        }

        private void FormDataGrid_Load(object sender, EventArgs e)
        {
            LoadTheme();
            lblTextTitleForm.Text = this.Text;
        }

        private void FillDate()
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"SELECT DISTINCT Disease.NameDisease AS Болезнь, Disease.TypeOfDisease AS ТипБолезни, Disease.Reason AS Причина, Disease.Symptoms AS Симптом, COUNT(Disease.NameDisease) OVER (PARTITION BY Disease.NameDisease) AS Колличество, FORMAT(Diagnosis.Date,'%M.%y') AS Дата FROM Diagnosis JOIN Disease ON Diagnosis.DiseaseID = Disease.DiseaseID  Group by Disease.NameDisease, Disease.TypeOfDisease, Disease.Reason, Disease.Symptoms, Diagnosis.Date", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
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
