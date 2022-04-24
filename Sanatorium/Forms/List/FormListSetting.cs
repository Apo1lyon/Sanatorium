using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorium.Forms
{
    public partial class FormListSetting : Form
    {

        SqlConnection sqlConnection = new SqlConnection();
        public FormListSetting()
        {
            InitializeComponent();
        }

        private void FormListSetting_Load(object sender, EventArgs e)
        {
            LoadTheme();
            lblConnectionString.Text = ConfigurationManager.ConnectionStrings["Sanatorium.Properties.Settings.SanatoriumConnectionString"].ConnectionString;
        }

        private void LoadTheme()
        {
            foreach (Control item in this.panelDesktop.Controls)
            {
                if (item.GetType() == typeof(Label)) item.ForeColor = ThemeColor.PrimaryColor;
            }
        }

        private void btnChangeNameServer_Click(object sender, EventArgs e) 
        { 
            sqlConnection.ChangingNameServer(tbServerName.Text);
            lblConnectionString.Text = ConfigurationManager.ConnectionStrings["Sanatorium.Properties.Settings.SanatoriumConnectionString"].ConnectionString;
        } 
    }
}