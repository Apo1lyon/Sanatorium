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
    /// <summary>
    /// Класс для работы с формой-таблицей
    /// </summary>
    public partial class TableForm : Form
    {
        //Свойства
        private DataGridView dgvDataBase { get; set; }
        private TextBox TextBoxId { get; set; }
        
        /// <summary>
        /// Название главной таблицы
        /// </summary>
        public string TablePrimary { get; set; }
        private Panel PanelDesktop { get; set; }
        private Panel PanelSetValue { get; set; }

        /// <summary>
        /// Загружает данные для формы
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Событие</param>
        public void Form_Load(object sender, EventArgs e)
        {
            LoadProperty();
            LoadTheme();
            UpdateTable();
        }

        private void LoadProperty()
        {
            foreach (Panel panel in Controls) { if (panel.Name == "panelDesktop") PanelDesktop = panel; }
            foreach (Panel panel in PanelDesktop.Controls)
            {
                if (panel.Name == "panelSetValue") PanelSetValue = panel;
                foreach (Control item in panel.Controls)
                {
                    if (item is TextBox)
                        if (item.Name == "textBox1") TextBoxId = item as TextBox;
                    if (item is DataGridView)
                        if (item.Name == "dgvDataBase") dgvDataBase = (DataGridView)item;
                }
            }
        } //Загружает свойства
        
        private void LoadTheme()
        {
            foreach (Control panel in PanelDesktop.Controls)
            {
                foreach (Control item in panel.Controls)
                {
                    if (item is Label) item.ForeColor = ThemeColor.PrimaryColor;
                }
            }
        } //Загружает цветовую тему для формы
        
        private void FillDate()
        {
            BindingSource bindingSourcePrimary = new BindingSource();
            bindingSourcePrimary.DataSource = SqlConnection.GetData($"SELECT * FROM {TablePrimary}", new DataTable($"{TablePrimary}"));
            dgvDataBase.DataSource = bindingSourcePrimary;
        } //Загружает данные для таблицы

        /// <summary>
        /// Обновляет форму-таблицу
        /// </summary>
        public void UpdateTable()
        {
            FillDate();
            OperationsDataBase.ClearTextBox(PanelSetValue.Controls);
            TextBoxId.Text = SqlConnection.NextID(dgvDataBase);
        }

        /// <summary>
        /// Открывает дочернюю форму
        /// </summary>
        /// <param name="childForm">Дочерняя форма</param>
        /// <param name="btnSender">Кнопка отправитель</param>
        public void OpenChildForm(Form childForm, object btnSender)
        {
            Dispose();
            Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesktop.Controls.Add(childForm);
            PanelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Добавляет данные в базу данных
        /// </summary>
        /// <param name="addQuery">SQL запрос</param>
        public void AddValue(string addQuery)
        {
            try
            {
                SqlConnection.connection.Open();
                SqlCommand sqlCommand = new SqlCommand(addQuery, SqlConnection.connection);
                sqlCommand.ExecuteNonQuery();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = SqlConnection.GetData($"Select * From {TablePrimary}", new DataTable($"{TablePrimary}"));
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
