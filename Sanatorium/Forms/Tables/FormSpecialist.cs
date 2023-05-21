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
    public partial class FormSpecialist : System.Windows.Forms.Form
    {
        //Поля
        SqlCommand command;
        BindingSource bindingSourcePrimary;

        string tablePrimary = "Specialist";
        string tableSecondary = "Specialty";
        string tableTernary = "DoctorOffice";

        //Конструктор класса
        public FormSpecialist()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
        }
        
        //Методы при загрузке и обновлении формы
        private void FormSpecialist_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateTable();
        }

        private void FillDate()
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = SqlConnection.GetData($"SELECT * FROM {tablePrimary}", new DataTable($"{tablePrimary}"));
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

        private void UpdateTable()
        {
            FillDate();
            OperationsDataBase.ClearTextBox(panelSetValue.Controls);
            textBox1.Text = SqlConnection.NextID(dgvDataBase);
        }

        //Методы при выполнении событий 
        private void OpenChildForm(System.Windows.Forms.Form childForm, object btnSender)
        {
            this.Dispose();
            this.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }//Открытие дочерней формы

        private void btnClose_Click(object sender, EventArgs e) => OpenChildForm(new FormListPersonnel(), sender);

        private void btnAdd_Click(object sender, EventArgs e)
        {
           try
           {
                SqlConnection.connection.Open();
                string addQuery = $"insert into {tablePrimary} (SpecialistID, LastName, FirstName, MiddleName, SpecialtyID, DoctorOfficeID) values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')";

                command = new SqlCommand(addQuery, SqlConnection.connection);
                command.ExecuteNonQuery();
                
                bindingSourcePrimary = new BindingSource();
                bindingSourcePrimary.DataSource = SqlConnection.GetData($"Select * From {tablePrimary}", new DataTable($"{tablePrimary}"));

                UpdateTable();

                SqlConnection.connection.Close();
           }
            catch (Exception)
           {
               SqlConnection.connection.Close();
               MessageBox.Show($"Некорректные данные или их отсутствие. Проверьте чтобы все данные были введены корректно ({tableSecondary}ID) и не повторялись ({tablePrimary}ID)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void btnUpdate_Click(object sender, EventArgs e) => UpdateTable();

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => SqlConnection.ValueChanged(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => SqlConnection.DeletingRow(dgvDataBase, tablePrimary);

        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableSecondary);
            if (dgvSelectDataBase.DataSource == null) SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableTernary);
        }

        private void dgvSelectDataBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => SqlConnection.BroadcastID(dgvDataBase, dgvSelectDataBase, dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText);
    }
}
