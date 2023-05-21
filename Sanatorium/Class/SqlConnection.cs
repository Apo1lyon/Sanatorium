using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace Sanatorium
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public static class SqlConnection
    {
        //Поля
        /// <summary>
        /// Строка соединяния с базой данных
        /// </summary>
        public static System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Sanatorium.Properties.Settings.SanatoriumConnectionString"].ConnectionString);
     
        /// <summary>
        /// Изменение имени сервера
        /// </summary>
        /// <param name="nameServer">Имя сервера</param>
        public static void ChangingNameServer(string nameServer)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);//Cоздание переменной файла конфигурации

            config.ConnectionStrings.ConnectionStrings["Sanatorium.Properties.Settings.SanatoriumConnectionString"].ConnectionString = $"server={nameServer}; integrated security=true; database=Sanatorium";//Изменение строки соединения под текущий сервер
            config.Save();//Сохранекние конфигурации
            ConfigurationManager.RefreshSection("connectionStrings");//Обновление раздела конфигурации для последующего считывания
        }
        /// <summary>
        /// Заполнение таблицы из базы данных
        /// </summary>
        /// <param name="sqlCommand">Sql запрос</param>
        /// <param name="table">таблица</param>
        /// <returns>Заполненная таблица</returns>
        public static DataTable GetData(string sqlCommand, DataTable table)
        {
            try
            {
                SqlCommand command = new SqlCommand(sqlCommand, connection);//Инициализация экземпляра запроса
                SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = command };//Инициализация экземпляра команд
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;//Добавляет сведения о языке
                adapter.Fill(table);//Добавляет и изменяет данные в таблице
            }
            catch (Exception)
            {
                MessageBox.Show($"Нет связи с сервером!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return table;
        }//Вытягивание данных по запросу в выбранную таблицу

        public static void DeletingRow(DataGridView dataGrid, string table)
        {
            connection.Open(); //Открытие соединения
            int index = dataGrid.CurrentCell.RowIndex;//Присваивание переменной индекс активной ячейки
            var value = dataGrid.Rows[index].Cells[0].Value;//Присваивание переменной значение активной ячейки
            var deleteQuery = $"delete from {table} where Num{table} = {value}";//Запрос на удаление данных из базы данных

            var command = new SqlCommand(deleteQuery, connection);//Создание запроса
            command.ExecuteNonQuery();//Выполнение инструкции

            connection.Close();
        }//Удаление данных из таблицы и базы данных

        public static void ValueChanged(DataGridView dataGrid, string table)
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

        public static void Relations(DataGridView dgvDataBase, DataGridView dgvSelectDataBase, string tableSecondary)
        {
            if (dgvDataBase.Columns[dgvDataBase.CurrentCell.ColumnIndex].HeaderText == $"{tableSecondary}ID")
            {
                SqlDataAdapter adapterSecondary = new SqlDataAdapter($"SELECT * FROM {tableSecondary}", connection);

                DataSet ds = new DataSet();
                adapterSecondary.Fill(ds, $"{tableSecondary}");

                var bindingSourceSecondary = new BindingSource(ds, $"{tableSecondary}");
                dgvSelectDataBase.DataSource = bindingSourceSecondary;
                for (int i = 0; i < dgvSelectDataBase.RowCount - 1; i++)
                {
                    if (dgvDataBase.CurrentCell.Value.ToString().Substring(dgvDataBase.CurrentCell.Value.ToString().Length - 2, 2) == 
                        dgvSelectDataBase.Rows[i].Cells[1].Value.ToString().Substring(dgvSelectDataBase.Rows[i].Cells[1].Value.ToString().Length - 2, 2)) 
                        dgvSelectDataBase.Rows[i].Cells[1].Selected = true;
                }
            }
            else dgvSelectDataBase.DataSource = null;
        }

        public static void BroadcastID(DataGridView dgvDataBase, DataGridView dgvSelectDataBase, string table)
        {
            if (dgvSelectDataBase.CurrentCell.OwningColumn.Name == $"{table}" && dgvDataBase.CurrentCell.OwningColumn.Name == $"{table}") dgvDataBase.CurrentCell.Value = dgvSelectDataBase.CurrentCell.Value;
        }

        public static string NextID(DataGridView dgvDataBase)
        {   
            try
            {
                string textID = (string)dgvDataBase.Rows[dgvDataBase.Rows.Count - 2].Cells[1].Value;
                string ID = null, text = null;
                foreach (var item in textID)
                {
                    if (Char.IsNumber(item)) ID += item;
                    else text += item;
                }
                int num = (Convert.ToInt32(ID)) + 1;

                    return textID = $"{text}{ID.Remove(ID.Length - (num.ToString().Length), num.ToString().Length) + Convert.ToString(num)}";
            }
            catch (Exception)
            {
                MessageBox.Show("Переполнение таблицы по ID номеру или полное отсутствие значений. Добавьте или очистите некоторые позиции!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "###";
            }
        }
    }
}
