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
    public partial class FormDiagnosis : TableForm
    {
        //Поля
        string tablePrimary = "Diagnosis";
        string tableSecondary = "Disease";

        /// <summary>
        /// Конструктор класса FormDiagnosis
        /// </summary>
        public FormDiagnosis()
        {
            InitializeComponent();
            lblTextTitleForm.Text = this.Text;
            TablePrimary = tablePrimary;
        }
        
        //Методы при загрузке и обновлении формы
        private void FormDataGrid_Load(object sender, EventArgs e) =>
            Form_Load(sender, e);

        //События
        private void btnClose_Click(object sender, EventArgs e) => 
            OpenChildForm(new FormListPersonnel(), sender);

        private void btnAdd_Click(object sender, EventArgs e) => 
            AddValue($"insert into {tablePrimary} (DiagnosisID, DiseaseID, Complications, Diagnosis) " +
                $"values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}')");

        private void btnUpdate_Click(object sender, EventArgs e) => 
            UpdateTable();

        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.ValueChanged(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => 
            SqlConnection.DeletingRow(dgvDataBase, tablePrimary);
        
        private void dgvDataBase_CellClick(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.Relations(dgvDataBase, dgvSelectDataBase, tableSecondary);

        private void dgvSelectDataBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => 
            SqlConnection.BroadcastID(dgvDataBase, dgvSelectDataBase, dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText);
    }
}
