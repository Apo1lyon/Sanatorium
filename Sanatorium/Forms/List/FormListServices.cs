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
    public partial class FormListServices : Form
    {
        public FormListServices()
        {
            InitializeComponent();
        }

        private void FormListServices_Load(object sender, EventArgs e)
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
        
        private void FormServices_Click(object sender, EventArgs e) => OpenChildForm(new FormServices(), sender);

        private void FormOperationServices_Click(object sender, EventArgs e) => OpenChildForm(new FormOperationServices(), sender);
    }
}