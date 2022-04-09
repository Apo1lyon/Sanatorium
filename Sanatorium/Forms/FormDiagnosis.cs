using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorium.Forms
{
    public partial class FormDiagnosis : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand command;
        BindingSource bindingSourcePrimary;
        string tablePrimary = "Diagnosis";
        string tableSecondary = "Disease";

        public FormDiagnosis()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
        }
        
        private void FormDataGrid_Load(object sender, EventArgs e)
        {
            LoadTheme();
            FillDate();
        }

        private void FillDate()
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"SELECT * FROM {tablePrimary}", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        private void LoadTheme()
        {
            foreach (Control panel in this.panelDesktop.Controls)
            {
                foreach (Control item in  panel.Controls)
                {
                    if (item.GetType() == typeof(Label)) item.ForeColor = ThemeColor.PrimaryColor;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => OpenChildForm(new FormList(), sender);
        
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FillDate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.connection.Open();
                string addQuery = $"insert into {tablePrimary} (DiagnosisID, DiseaseID, Complications, Diagnosis, Date) values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{dateTimePicker1.Text}')";

                command = new SqlCommand(addQuery, sqlConnection.connection);
                command.ExecuteNonQuery();
                
                bindingSourcePrimary = new BindingSource();
                bindingSourcePrimary.DataSource = sqlConnection.GetData($"Select * From {tablePrimary}", new DataTable($"{tablePrimary}"));

                sqlConnection.ClearTextBox(panelSetValue.Controls);

                sqlConnection.connection.Close();
            }
            catch (Exception)
            {
                sqlConnection.connection.Close();
                MessageBox.Show("Данных не существует или они повторяются", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) => sqlConnection.ClearTextBox(panelSetValue.Controls);

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => sqlConnection.ValueChanged(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => sqlConnection.DeletingRow(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e) => sqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableSecondary);

        private void dgvSelectDataBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => sqlConnection.BroadcastID(dgvDataBase, dgvSelectDataBase, tableSecondary);

        private void btnDate_Click(object sender, EventArgs e)
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"SELECT * FROM {tablePrimary} WHERE Date >= '{dtpStartDate.Value}' and Date <= '{dtpEndDate.Value}'", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }
    }
}
