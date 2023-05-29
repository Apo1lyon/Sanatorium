using Sanatorium.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorium.Class
{
    public partial class TableForm : Form
    {
        //Свойства
        private BindingSource BindingSource { get; set; }
        private DataGridView dgvDataBase { get; set; }
        private TextBox TextBoxId { get; set; }
        public string TablePrimary { get; set; }
        private Panel Panel { get; set; }

        public void Form_Load(object sender, EventArgs e)
        {
            LoadProperty();
            LoadTheme();
            UpdateTable();
        }

        private void LoadProperty()
        {
            foreach (Panel panel in Controls) { if (panel.Name == "panelDesktop") Panel = panel; }
            foreach (Panel panel in Panel.Controls)
            {
                foreach (Control item in panel.Controls)
                {
                    if (item is TextBox)
                        if (item.Name == "textBox1") TextBoxId = item as TextBox;
                    if (item is DataGridView)
                        if (item.Name == "dgvDataBase") dgvDataBase = (DataGridView)item;
                }
            }

        }
        
        private void LoadTheme()
        {
            foreach (Control panel in Panel.Controls)
            {
                foreach (Control item in panel.Controls)
                {
                    if (item is Label) item.ForeColor = ThemeColor.PrimaryColor;
                }
            }
        }
        
        private void FillDate()
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = SqlConnection.GetData($"SELECT * FROM {TablePrimary}", new DataTable($"{TablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        public void UpdateTable()
        {
            FillDate();
            OperationsDataBase.ClearTextBox(Controls);
            TextBoxId.Text = SqlConnection.NextID(dgvDataBase);
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            Dispose();
            Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Panel.Controls.Add(childForm);
            Panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }//Открытие дочерней формы

        public void AddValue(string addQuery)
        {
            try
            {
                SqlConnection.connection.Open();
                SqlCommand sqlCommand = new SqlCommand(addQuery, SqlConnection.connection);
                sqlCommand.ExecuteNonQuery();
                BindingSource = new BindingSource();
                BindingSource.DataSource = SqlConnection.GetData($"Select * From {TablePrimary}", new DataTable($"{TablePrimary}"));
                UpdateTable();
                SqlConnection.connection.Close();
            }
            catch (Exception)
            {
                SqlConnection.connection.Close();
                MessageBox.Show($"Некорректные данные или их отсутствие. Проверьте чтобы все данные были введены корректно и не повторялись!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
