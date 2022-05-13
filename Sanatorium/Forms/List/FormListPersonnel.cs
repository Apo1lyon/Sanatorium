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
    public partial class FormListPersonnel : Form
    {
        public FormListPersonnel()
        {
            InitializeComponent();
        }

        private void FormClient_Load(object sender, EventArgs e)
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

        private void FormSpecialty_Click(object sender, EventArgs e) => OpenChildForm(new FormSpecialty(), sender);

        private void FormDoctorOffice_Click(object sender, EventArgs e) => OpenChildForm(new FormDoctorOffice(), sender);

        private void FormSpecialist_Click(object sender, EventArgs e) => OpenChildForm(new FormSpecialist(), sender);

        private void FormOperationAppoint_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationPatient(), sender);

        private void FormOperationSpecialist_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationSpecialist(), sender);
    }
}
