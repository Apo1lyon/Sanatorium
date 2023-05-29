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
    public partial class FormAppoint : TableForm
    {
        //Поля
        string tablePrimary = "Appoint";
        string tableSecondary = "Medication";
        string tableTernary = "Services";

        /// <summary>
        /// Конструктор класса FormAppoint
        /// </summary>
        public FormAppoint()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
            TablePrimary = tablePrimary;
        }
        
        //Методы при загрузке и обновлении формы
        private void FormAppoint_Load(object sender, EventArgs e) =>
            Form_Load(sender, e);
        
        //События
        private void btnClose_Click(object sender, EventArgs e) => 
            OpenChildForm(new FormListPersonnel(), sender); //Закрытие формы и возврат на предыдущую форму

        private void btnAdd_Click(object sender, EventArgs e) => 
            AddValue($"insert into {tablePrimary} (AppointID, MedicationID, ServicesID) " +
                $"values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}')");

        private void btnUpdate_Click(object sender, EventArgs e) => 
            UpdateTable(); //Обновление данных в таблице и полях, обновление базы данных

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.ValueChanged(dgvDataBase, tablePrimary); //Изменение данных в таблице и обновление базы данных
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => 
            SqlConnection.DeletingRow(dgvDataBase, tablePrimary); //Удаление данных в таблице и обновление базы данных

        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableSecondary);
            if (dgvSelectDataBase.DataSource == null) SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableTernary);
        }//Открытие дочерней базы данных во второй таблице, при выборе вторичного ключа в первой таблице

        private void dgvSelectDataBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.BroadcastID(dgvDataBase, dgvSelectDataBase, dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText); //Присвоение данных из второй таблицы в первую
    }
}
