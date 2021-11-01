using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PseudoExcel
{
    public partial class PseudoExcelForm : Form
    {
        private string savepath = "";
        Table tableModel = new Table();
        private const int INITIAL_COLS = 12;
        private const int INITIAL_ROWS = 20;


        public PseudoExcelForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            InitializeDGV();
        }

        private void InitializeDGV()
        {
            table.ColumnHeadersVisible = true;
            table.RowHeadersVisible = true;
            table.ColumnCount = INITIAL_COLS;

            table.FillHeaders(INITIAL_COLS, INITIAL_ROWS);

            table.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            table.MultiSelect = false;
            tableModel.SetTable(INITIAL_COLS,INITIAL_ROWS);
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            string expression = tableModel.grid[row][col].expression;
            string value = tableModel.grid[row][col].value;
            textBox.Text = expression;
            textBox.Focus();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            string expression = textBox.Text;
            if (expression == "") return;
            tableModel.ChangeCell(row, col, expression, table);
            table[col, row].Value = tableModel.grid[row][col].value;
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveTable(string path)
        {
            savepath = path;
            table.EndEdit();
            string serializedTable = JsonConvert.SerializeObject(tableModel, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(savepath, serializedTable);
        }

        private bool IsSavedTable(string path)
        {
            if (path != "")
            {
                SaveTable(path);
                return true;
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTable(saveFileDialog.FileName);
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
                tableModel.FillDGV(table);
            }
            catch(Exception ex)
            {
                MessageBox.Show("File contains wrong data!");
            }
        }


        private void saveFile_Click(object sender, EventArgs e)
        {
            IsSavedTable(savepath);
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new System.Windows.Forms.DataGridViewRow();
            if (table.Columns.Count == 0)
            {
                MessageBox.Show("There are no columns!");
                return;
            }
            table.Rows.Add(row);
            table.Rows[tableModel.rows].HeaderCell.Value = (tableModel.rows).ToString();
            tableModel.AddRow(table);
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("There are no rows!");
                return;
            }
            int Col = table.CurrentCell.ColumnIndex;
            string name = Sys26.To26Sys(tableModel.cols);
            table.Columns.Add(name, name);
            tableModel.AddColumn(table);
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            if (!tableModel.DeleteRow(table))
                return;
            table.Rows.RemoveAt(tableModel.rows);
        }

        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            if (!tableModel.DeleteColumn(table))
                return;
            table.Columns.RemoveAt(tableModel.cols);
        }
    }
}
