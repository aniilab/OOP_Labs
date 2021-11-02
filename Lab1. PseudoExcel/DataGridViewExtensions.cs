using System.Windows.Forms;

namespace PseudoExcel
{
    public static class DataGridViewExtensions
    {
        public static void InitializeDGV(this DataGridView table, int cols, int rows)
        {
            table.ColumnHeadersVisible = true;
            table.RowHeadersVisible = true;
            table.AllowUserToAddRows = false;
            table.ColumnCount = cols;
            table.RowCount = 0;
            table.FillHeaders(cols, rows);
            table.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            table.MultiSelect = false;
        }

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
                dgv.Rows[i].HeaderCell.Value = (i).ToString();
            }
        }
    }
}
