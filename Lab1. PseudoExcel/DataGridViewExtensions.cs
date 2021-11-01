using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoExcel
{
    public static class DataGridViewExtensions
    {
        public static void FillHeaders(this DataGridView dgv, int cols, int rows)
        {
            for (int i = 0; i < cols; i++)
            {
                dgv.Columns[i].HeaderText = Sys26.To26Sys(i);
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < rows; i++)
            {
                dgv.Rows.Add("");
                dgv.Rows[i].HeaderCell.Value = i.ToString();
            }
        }
    }
}
