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
        public void CreateChartColumn(Chart chart, DataGridView dataGrid, int X, int Y)
        {
            chart.Series.Clear();
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if (chart.Series.IsUniqueName($"{dataGrid.Rows[i].Cells[0].Value}"))chart.Series.Add($"{dataGrid.Rows[i].Cells[0].Value}");
                chart.Series[$"{dataGrid.Rows[i].Cells[0].Value}"].Points.AddXY(dataGrid.Rows[i].Cells[X].Value, dataGrid.Rows[i].Cells[Y].Value);
            }
        }
    
        public void CreateChartDoughnut(Chart chart, DataGridView dataGrid, int X, int Y)
        {
            Series s = chart.Series.Add("pie");
            s.ChartType = SeriesChartType.Pie;
            for (int rowindex = 0; rowindex < dataGrid.Rows.Count - 1; rowindex++)
            {
                s.Points.AddXY(dataGrid.Rows[rowindex].Cells[X].Value,
                dataGrid.Rows[rowindex].Cells[Y].Value);
            }
        }
    }  
}
