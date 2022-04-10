﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sanatorium
{
    public class SqlConnection
    {
        private int Number;
        private string ID;
        private string Country;
        private string PersonName;
        private int Start;
        private int Final;
        public int Number1 { get => Number; set => Number = value; }
        public string ID1 { get => ID; set => ID = value; }
        public string Country1 { get => Country; set => Country = value; }
        public string Person1 { get => PersonName; set => PersonName = value; }
        public int Start1 { get => Start; set => Start = value; }
        public int Final1 { get => Final; set => Final = value; }

        public System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection("server=DESKTOP-AIJD8J6; integrated security=true; database=Sanatorium");

        public DataTable GetData(string sqlCommand, DataTable table)
        {
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataAdapter adapter = new SqlDataAdapter{ SelectCommand = command };
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

        public void ClearTextBox(Control.ControlCollection contains)
        {
            foreach (Control item in contains) if (item.GetType() == typeof(TextBox)) item.Text = "";
        }

        public void DeletingRow(DataGridView dataGrid, string table)
        {
            connection.Open();
            int index = dataGrid.CurrentCell.RowIndex;
            var value = dataGrid.Rows[index].Cells[0].Value;
            var deleteQuery = $"delete from {table} where Num{table} = {value}";

            var command = new SqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void ValueChanged(DataGridView dataGrid, string table)
        {
            try
            {
                connection.Open();
                string fieldTable = dataGrid.Columns[dataGrid.CurrentCell.ColumnIndex].HeaderText;
                string addQuery = $"UPDATE {table} SET {fieldTable} = '{dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells[dataGrid.CurrentCell.ColumnIndex].Value}' WHERE Num{table} = '{dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells[0].Value}'";
                var command = new SqlCommand(addQuery, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                MessageBox.Show($"Эти данные нельзя изменить.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

        }

        public void Relations(DataGridView dgvDataBase, DataGridView dgvSelectDataBase, string tableSecondary)
        {
            if (dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText == $"{tableSecondary}ID")
            {
                SqlDataAdapter adapterSecondary = new SqlDataAdapter($"SELECT * FROM {tableSecondary}", connection);

                DataSet ds = new DataSet();
                adapterSecondary.Fill(ds, $"{tableSecondary}");

                var bindingSourceSecondary = new BindingSource(ds, $"{tableSecondary}");
                dgvSelectDataBase.DataSource = bindingSourceSecondary;
            }
            else dgvSelectDataBase.DataSource = null;
        }

        public void BroadcastID(DataGridView dgvDataBase, DataGridView dgvSelectDataBase, string table)
        {
            if (dgvSelectDataBase.CurrentCell.OwningColumn.Name == $"{table}" && dgvDataBase.CurrentCell.OwningColumn.Name == $"{table}") dgvDataBase.CurrentCell.Value = dgvSelectDataBase.CurrentCell.Value;
        }

        public string NextID(DataGridView dgvDataBase)
        {
            string textID = (string)dgvDataBase.Rows[dgvDataBase.Rows.Count - 2].Cells[1].Value;
            string ID = null;
            string text = null;
            foreach (var item in textID)
            {
                if (Char.IsNumber(item)) ID += item;
                else text += item;
            }
            ID = $"{ Convert.ToInt32(ID) + 1}";
            return text + ID;
        }
    } 
}
