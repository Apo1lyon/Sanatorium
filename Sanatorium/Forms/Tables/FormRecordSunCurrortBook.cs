﻿using System;
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
    public partial class FormRecordSunCurrortBook : System.Windows.Forms.Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand command;
        BindingSource bindingSourcePrimary;

        string tablePrimary = "RecordSunCurrortBook";
        string tableSecondary = "SunCurrortBook";
        string tableTernary = "Diagnosis";
        string tableFourth = "Appoint";
        string tableFive = "Specialist";
       
        public FormRecordSunCurrortBook()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
        }
        
        private void FormRecordSunCurrortBook_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateTable();
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

        private void UpdateTable()
        {
            FillDate();
            sqlConnection.ClearTextBox(panelSetValue.Controls);
        }

        private void OpenChildForm(System.Windows.Forms.Form childForm, object btnSender)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }//Открытие дочерней формы

        private void btnClose_Click(object sender, EventArgs e) => OpenChildForm(new FormListPatient(), sender);

        private void btnAdd_Click(object sender, EventArgs e)
        {
           try
           {
                sqlConnection.connection.Open();
                string addQuery = $"insert into {tablePrimary} (SunCurrortBookID, DiagnosisID, AppointID, SpecialistID, Date) values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{dateTimePicker1.Value}')";

                command = new SqlCommand(addQuery, sqlConnection.connection);
                command.ExecuteNonQuery();
                
                bindingSourcePrimary = new BindingSource();
                bindingSourcePrimary.DataSource = sqlConnection.GetData($"Select * From {tablePrimary}", new DataTable($"{tablePrimary}"));

                sqlConnection.ClearTextBox(panelSetValue.Controls);

                UpdateTable();

                sqlConnection.connection.Close();
           }
            catch (Exception)
           {
               sqlConnection.connection.Close();
               MessageBox.Show($"Некорректные данные или их отсутствие. Проверьте чтобы все данные были введены корректно ({tableSecondary}ID) и не повторялись ({tablePrimary}ID)!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void btnDelete_Click(object sender, EventArgs e) => UpdateTable();

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => sqlConnection.ValueChanged(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => sqlConnection.DeletingRow(dgvDataBase, tablePrimary);

        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableSecondary);
            if (dgvSelectDataBase.DataSource == null) sqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableTernary);
            if (dgvSelectDataBase.DataSource == null) sqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableFourth);
            if (dgvSelectDataBase.DataSource == null) sqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableFive);
        }

        private void dgvSelectDataBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => sqlConnection.BroadcastID(dgvDataBase, dgvSelectDataBase, dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText);

        private void btnDate_Click(object sender, EventArgs e)
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = sqlConnection.GetData($"SELECT * FROM {tablePrimary} WHERE Date >= '{dtpStartDate.Value}' and Date <= '{dtpEndDate.Value}'", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }

        private void btnAllTime_Click(object sender, EventArgs e) => UpdateTable();
    }
}
