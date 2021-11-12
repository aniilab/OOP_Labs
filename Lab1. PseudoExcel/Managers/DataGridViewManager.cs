using PseudoExcel.Entities;
using PseudoExcel.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PseudoExcel.Managers
{
    public class DataGridViewManager
    {
        private DataGridView _dataGridView;

        public DataGridViewManager(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }

        public void InitializeDGV(int cols, int rows)
        {
            _dataGridView.ColumnHeadersVisible = true;
            _dataGridView.RowHeadersVisible = true;
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            _dataGridView.MultiSelect = false;

            _dataGridView.ColumnCount = cols;
            _dataGridView.RowCount = 0;
            FillHeaders(cols, rows);
        }

        public void UpdateDGV(int columnsAmount, int rowsAmount, List<List<Cell>> grid)
        {
            InitializeDGV(columnsAmount, rowsAmount);

            for (int row = 0; row < rowsAmount; row++)
            {
                for (int column = 0; column < columnsAmount; column++)
                {
                    _dataGridView.Rows[row].Cells[column].Value = grid[row][column].Value;
                }
            }
        }

        private void FillHeaders(int cols, int rows)
        {
            for (int i = 0; i < cols; i++)
            {
                _dataGridView.Columns[i].HeaderText = Sys26.To26Sys(i);
                _dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < rows; i++)
            {
                _dataGridView.Rows.Add(string.Empty);
                _dataGridView.Rows[i].HeaderCell.Value = (i).ToString();
            }
        }
    }
}
