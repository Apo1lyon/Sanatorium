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
    internal class TableForm : Form
    {
        //Свойства
        private BindingSource BindingSource { get; set; }
        private DataGridView dgvDataBase { get; set; }
        protected TextBox[] textBox { get; set; }
        protected string table { get; set; }
        private Panel Panel { get; set; }

        protected void Form_Load(object sender, EventArgs e)
        {
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
                    if (item is TextBox) textBox.Append(item);
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
            bindingSourcePrimary.DataSource = SqlConnection.GetData($"SELECT * FROM {table}", new DataTable($"{table}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        private void UpdateTable()
        {
            FillDate();
            SqlConnection.ClearTextBox(Controls);
            textBox[0].Text = SqlConnection.NextID(dgvDataBase);
        }

        protected void OpenChildForm(Form childForm, object btnSender)
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

        protected string CreateAddQuery(params string[] strings)
        {
            string query = $"insert into {table} (";
            foreach (string s in strings) 
            {  
                query += s;
                if (s != strings[strings.Length - 1]) query += ",";
                else query += ") values (";
            }
            return query;
        }
        protected void AddValue(string addQuery)
        {
            try
            {
                SqlConnection.connection.Open();
                SqlCommand sqlCommand = new SqlCommand(addQuery, SqlConnection.connection);
                sqlCommand.ExecuteNonQuery();
                BindingSource = new BindingSource();
                BindingSource.DataSource = SqlConnection.GetData($"Select * From {table}", new DataTable($"{table}"));
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
