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
    public partial class FormOperation : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        string tablePrimary = "Diagnosis";
        string tableSecondary = "Disease";

        public FormOperation()
        {
            InitializeComponent();
            FillDate();
        }

        private void FormDataGrid_Load(object sender, EventArgs e)
        {
            LoadTheme();
            lblTextTitleForm.Text = this.Text;
        }

        private void FillDate()
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"SELECT Diagnosis.NumDiagnosis, Disease.TypeOfDisease, Disease.NameDisease, Disease.Symptoms, Diagnosis.Complications, Diagnosis.Diagnosis, Diagnosis.Date FROM Diagnosis JOIN Disease ON Disease.DiseaseID = Diagnosis.DiseaseID", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }


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
    }
}
