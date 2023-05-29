using Microsoft.Build.Framework.XamlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sanatorium
{
    /// <summary>
    /// Операции над базой данных
    /// </summary>
    class OperationsDataBase
    {
        /// <summary>
        /// Построение диаграммы по таблице
        /// </summary>
        /// <param name="chart">Элемент диаграммы</param>
        /// <param name="dataGrid">Экземпляр таблицы</param>
        /// <param name="type">Тип диаграммы</param>
        /// <param name="xValue">Значение X</param>
        /// <param name="yValue">Значение Y</param>
        public void CreateChartPrimary(Chart chart, DataGridView dataGrid, SeriesChartType type, int xValue, int yValue)
        {
            string nameRow;
            chart.Series.Clear();
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++)
            {
                nameRow = (string)dataGrid.Rows[rowindex].Cells[0].Value;
                if (chart.Series.IsUniqueName(nameRow)) chart.Series.Add($"{dataGrid.Rows[rowindex].Cells[0].Value}");
                chart.Series[$"{dataGrid.Rows[rowindex].Cells[0].Value}"].Points.AddXY(dataGrid.Rows[rowindex].Cells[xValue].Value, dataGrid.Rows[rowindex].Cells[yValue].Value);
                chart.Series[$"{dataGrid.Rows[rowindex].Cells[0].Value}"].ChartType = type;
            }
        }
        /// <summary>
        /// Построение круговой диаграммы
        /// </summary>
        /// <param name="chart">Элемент диаграммы</param>
        /// <param name="dataGrid">Экземпляр таблицы</param>
        /// <param name="type">Тип диаграммы</param>
        /// <param name="xValue">Значение X</param>
        /// <param name="yValue">Значение Y</param>
        public void CreateChartSecondary(Chart chart, DataGridView dataGrid, SeriesChartType type, int xValue, int yValue)
        {
            chart.Series.Clear();
            Series s = chart.Series.Add("pie");
            s.ChartType = type;
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++) s.Points.AddXY(dataGrid.Rows[rowindex].Cells[xValue].Value, dataGrid.Rows[rowindex].Cells[yValue].Value);
        }
        /// <summary>
        /// Возвращает наибольшее значение в столбце
        /// </summary>
        /// <param name="dataGrid">Экземпляр таблицы</param>
        /// <param name="columnIndex">Индекс столбца</param>
        /// <returns>Наибольшее значение</returns>
        public string ReturnDistributed(DataGridView dataGrid, int columnIndex)
        {
            for (int rowIndex = 0; rowIndex < dataGrid.Rows.Count - 1; rowIndex++)
            {
                if ((int)dataGrid.Rows[rowIndex].Cells[columnIndex].Value == dataGrid.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells[columnIndex].Value)))
                    return (string)dataGrid.Rows[rowIndex].Cells[0].Value;
            }
            return "";
        }
       /// <summary>
       /// Возвращает наименьшее значение в столбце
       /// </summary>
       /// <param name="dataGrid">Экземпляр таблицы</param>
       /// <param name="cellIndex">Индекс столбца</param>
       /// <returns>Наименьшее значение</returns>
        public string ReturnNonDistributed(DataGridView dataGrid, int cellIndex)
        {
            if(dataGrid.Rows.Count - 1 != 0)
            for (int i = 0; ; i++)
            {
                for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++)
                {
                    if ((int)dataGrid.Rows[rowindex].Cells[cellIndex].Value == i) return (string)dataGrid.Rows[rowindex].Cells[0].Value;
                }
            }
            return "";

        }
        /// <summary>
        /// Очистить содержимое всех textbox
        /// </summary>
        /// <param name="contains"></param>
        public static void ClearTextBox(Control.ControlCollection contains)
        {
            foreach (Control item in contains) if (item.GetType() == typeof(TextBox)) item.Text = "";
        }//Очистка всех textbox на форме
    }  
}
