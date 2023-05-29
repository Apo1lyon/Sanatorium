using Sanatorium.Class;
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
    /// <summary>
    /// Класс формы FormPatient
    /// </summary>
    public partial class FormPatient : TableForm
    {
        //Поля
        string tablePrimary = "Patient";

        /// <summary>
        /// Конструктор класса FormPatient
        /// </summary>
        public FormPatient()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
            TablePrimary = tablePrimary;
        }
        
        private void FormPatient_Load(object sender, EventArgs e) =>
            Form_Load(sender, e);
        
        //События
        private void btnClose_Click(object sender, EventArgs e) => 
            OpenChildForm(new FormListPatient(), sender);

        private void btnAdd_Click(object sender, EventArgs e) =>
            AddValue($"insert into {tablePrimary} (PatientID, Passport, LastName, FirstName, MiddleName, Age) " +
                $"values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')");

        private void btnUpdate_Click(object sender, EventArgs e) => 
            UpdateTable();

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.ValueChanged(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => 
            SqlConnection.DeletingRow(dgvDataBase, tablePrimary);
    }
}
