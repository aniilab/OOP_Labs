using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.IO;
using PseudoExcel.Entities;
using PseudoExcel.Managers;
using PseudoExcel.Utils;

namespace PseudoExcel
{
    public partial class PseudoExcelForm : Form
    {
        private readonly DataGridViewManager _dataGridViewManager;

        private string savedTableFilePath = string.Empty;
        private Table tableModel = null;

        public PseudoExcelForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            _dataGridViewManager = new DataGridViewManager(table);
            _dataGridViewManager.InitializeDGV(Constants.InitialColumnsAmount, Constants.InitialRowsAmount);
            tableModel = new Table(Constants.InitialColumnsAmount, Constants.InitialRowsAmount);
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string expression = tableModel.grid[e.RowIndex][e.ColumnIndex].Expression;
                textBox.Text = expression;
            }
        }

        private void CellValueChanged(string input, int col, int row)
        {
            string oldExpression = tableModel.grid[row][col].Expression;
            string oldValue = tableModel.grid[row][col].Value;
            if (tableModel.ChangeCell(row, col, input, table))
            {
                table[col, row].Value = tableModel.grid[row][col].Value;
                textBox.Text = tableModel.grid[row][col].Expression;
            }
            else
            {
                tableModel.ChangeCell(row, col, string.IsNullOrEmpty(oldExpression) ? oldValue : oldExpression, table);

                table[col, row].Value = tableModel.grid[row][col].Value;
                textBox.Text = tableModel.grid[row][col].Expression;
            }

        }

        private void table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                table.CellValueChanged -= table_CellValueChanged;

                try
                {
                    string input = string.Empty;
                    if (table[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        input = table[e.ColumnIndex, e.RowIndex].Value.ToString();
                    }
                    CellValueChanged(input, e.ColumnIndex, e.RowIndex);
                }
                finally
                {
                    table.CellValueChanged += table_CellValueChanged;
                }
            }
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            CellValueChanged(textBox.Text, col, row);
            textBox.Focus();
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            string message = File.ReadAllText(Constants.HelpFilePath);
            MessageBox.Show(message, "Help Info");
        }

        private void SaveTable(string path)
        {
            savedTableFilePath = path;
            table.EndEdit();
            string serializedTable = JsonConvert.SerializeObject(tableModel, Formatting.Indented);
            File.WriteAllText(savedTableFilePath, serializedTable);
        }

        private bool IsSavedTable(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                SaveTable(path);
                return true;
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTable(saveFileDialog.FileName);
                return true;
            }
            return false;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            string serializedTable = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                serializedTable = File.ReadAllText(openFileDialog.FileName);
            }
            try
            {
                tableModel = JsonConvert.DeserializeObject<Table>(serializedTable);

                table.CellValueChanged -= table_CellValueChanged;
                _dataGridViewManager.UpdateDGV(tableModel.ColumnsAmount, tableModel.RowsAmount, tableModel.grid);
                table.CellValueChanged += table_CellValueChanged;
            }
            catch
            {
                MessageBox.Show("File contains wrong data!");
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if(IsSavedTable(savedTableFilePath))
            {
                MessageBox.Show("Successfully saved!");
            }
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            if (table.Columns.Count == 0)
            {
                MessageBox.Show("There are no columns!");
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            int rowNumber = table.Rows.Count;
            table.Rows.Add(row);
            table.Rows[rowNumber].HeaderCell.Value = rowNumber.ToString();
            tableModel.AddRow(table);
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("There are no rows!");
                return;
            }
            string name = Sys26.To26Sys(table.Columns.Count);
            table.Columns.Add(name, name);
            tableModel.AddColumn(table);
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            table.CellValueChanged -= table_CellValueChanged;
            try
            {
                if (tableModel.DeleteRow(table))
                    table.Rows.RemoveAt(table.Rows.Count - 1);
            }
            finally
            {
                table.CellValueChanged += table_CellValueChanged;
            }
        }

        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            table.CellValueChanged -= table_CellValueChanged;
            try
            {
                if (tableModel.DeleteColumn(table))
                    table.Columns.RemoveAt(table.Columns.Count - 1);
            }
            finally
            {
                table.CellValueChanged += table_CellValueChanged;
            }
        }

        private void authorInfoMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author of this laboratory work says hi!\nAuthor: Alina Bedenko from K-27.", "Author Info");
        }

        private void PseudoExcelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitDialogResult = MessageBox.Show("Are you sure you want to exit?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exitDialogResult == DialogResult.Yes)
            {
                DialogResult saveFileDialogResult = MessageBox.Show("Do you want to save file?", "Wanna save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (saveFileDialogResult == DialogResult.Yes)
                {
                    if (IsSavedTable(savedTableFilePath))
                    {
                        MessageBox.Show("Successfully saved!");
                        return;
                    }
                    else return;
                }
                else return;
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
