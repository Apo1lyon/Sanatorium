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
    /// Класс операций над базой данных
    /// </summary>
    class OperationsDataBase
    {
        /// <summary>
        /// Построение диаграммы по таблице
        /// </summary>
        /// <param name="chart">Элемент управления диаграммы</param>
        /// <param name="dataGrid">Таблица</param>
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
    
        public void CreateChartSecondary(Chart chart, DataGridView dataGrid, SeriesChartType type, int X, int Y)
        {
            chart.Series.Clear();
            Series s = chart.Series.Add("pie");
            s.ChartType = type;
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++) s.Points.AddXY(dataGrid.Rows[rowindex].Cells[X].Value, dataGrid.Rows[rowindex].Cells[Y].Value);
        }//Создание круговой диаграммы на основе таблицы

        public string ReturnDistributed(DataGridView dataGrid, int cellIndex)
        {
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++)
            {
                if ((int)dataGrid.Rows[rowindex].Cells[cellIndex].Value == dataGrid.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells[cellIndex].Value)))
                    return (string)dataGrid.Rows[rowindex].Cells[0].Value;
            }
            return "";
        } //Возвращение наибольшего значения в таблице
       
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

        } //Возвращение наименьшего значения в таблице
    }  
}
