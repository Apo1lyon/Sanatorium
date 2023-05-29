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
    /// Класс форму FormSunCurrortBook
    /// </summary>
    public partial class FormSunCurrortBook : TableForm
    {
        //Поля
        string tablePrimary = "SunCurrortBook";
        string tableSecondary = "Patient";
        string tableTernary = "Specialist";

        /// <summary>
        /// Конструктор класса FormSunCurrortBook
        /// </summary>
        public FormSunCurrortBook()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
            TablePrimary = tablePrimary;
        }
        
        //Методы при загрузке и обновлении формы
        private void FormSunCurrortBook_Load(object sender, EventArgs e) =>
            Form_Load(sender, e);
        
        //Cобытия
        private void btnClose_Click(object sender, EventArgs e) => 
            OpenChildForm(new FormListPatient(), sender);

        private void btnAdd_Click(object sender, EventArgs e) =>
            AddValue($"insert into {tablePrimary} (SunCurrortBookID, PatientID, SpecialistID, Date) " +
                $"values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{dateTimePicker1.Value}')");

        private void btnUpdate_Click(object sender, EventArgs e) => 
            UpdateTable();

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.ValueChanged(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => 
            SqlConnection.DeletingRow(dgvDataBase, tablePrimary);

        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableSecondary);
            if (dgvSelectDataBase.DataSource == null) SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableTernary);
        }

        private void dgvSelectDataBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.BroadcastID(dgvDataBase, dgvSelectDataBase, dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText);

        private void btnDate_Click(object sender, EventArgs e)
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = SqlConnection.GetData($"SELECT * FROM {tablePrimary} WHERE Date >= '{dtpStartDate.Value}' and Date <= '{dtpEndDate.Value}'", new DataTable($"{tablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        }
    }
}
