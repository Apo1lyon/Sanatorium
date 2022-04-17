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
    class OperationsDataBase
    {
        public void CreateChartPrimary(Chart chart, DataGridView dataGrid, SeriesChartType type, int X, int Y)
        {
            chart.Series.Clear();
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++)
            {
                if (chart.Series.IsUniqueName($"{dataGrid.Rows[rowindex].Cells[0].Value}")) chart.Series.Add($"{dataGrid.Rows[rowindex].Cells[0].Value}");
                chart.Series[$"{dataGrid.Rows[rowindex].Cells[0].Value}"].Points.AddXY(dataGrid.Rows[rowindex].Cells[X].Value, dataGrid.Rows[rowindex].Cells[Y].Value);
                chart.Series[$"{dataGrid.Rows[rowindex].Cells[0].Value}"].ChartType = type;
            }
        }
    
        public void CreateChartSecondary(Chart chart, DataGridView dataGrid, SeriesChartType type, int X, int Y)
        {
            chart.Series.Clear();
            Series s = chart.Series.Add("pie");
            s.ChartType = type;
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++) s.Points.AddXY(dataGrid.Rows[rowindex].Cells[X].Value, dataGrid.Rows[rowindex].Cells[Y].Value);
        }
    }  
}
