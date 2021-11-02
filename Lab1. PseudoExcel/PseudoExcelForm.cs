using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.IO;

namespace PseudoExcel
{
    public partial class PseudoExcelForm : Form
    {
        private string help_path = "D:\\c#\\PseudoExcel\\help.txt";
        private string savepath = "";
        Table tableModel = new Table();
        private int INITIAL_COLS = 12;
        private int INITIAL_ROWS = 20;

        public PseudoExcelForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            table.InitializeDGV(INITIAL_COLS, INITIAL_ROWS);
            tableModel.SetTable(INITIAL_COLS, INITIAL_ROWS);
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            string expression = tableModel.grid[row][col].expression;
            textBox.Text = expression;
        }

        private void table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                table.CellValueChanged -= table_CellValueChanged;

                try
                {
                    CellValueChanged(table[e.ColumnIndex, e.RowIndex].Value.ToString());
                }
                finally
                {
                    table.CellValueChanged += table_CellValueChanged;
                }
            }
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            CellValueChanged(textBox.Text);
            textBox.Focus();
        }

        private void CellValueChanged(string input)
        {
            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            string expression = input;
            if (expression == "") return;
            tableModel.ChangeCell(row, col, expression, table);
            table[col, row].Value = tableModel.grid[row][col].value;
            textBox.Text = expression;
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {
            string message = System.IO.File.ReadAllText(help_path);
            MessageBox.Show(message, "Help Info");
        }

        private void PseudoExcelForm_Load(object sender, EventArgs e)
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
                tableModel.FillDGV(table);
            }
            catch
            {
                MessageBox.Show("File contains wrong data!");
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if(IsSavedTable(savepath))
            {
                MessageBox.Show("Successfully saved!");
            }
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
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

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author of this laboratory work says hi!\nAuthor: Alina Bedenko from K-27.", "Author Info");
        }

        private void PseudoExcelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DialogResult result1 = MessageBox.Show("Do you want to save file?", "Wanna save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    saveFile_Click(sender, e);
                    return;
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
