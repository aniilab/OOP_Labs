using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoExcel
{
    public partial class PseudoExcelForm : Form
    {
        Table newtable = new Table();
        private string savepath = "";
        private const int row0 = 20;
        private const int col0 = 12;


        public PseudoExcelForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            CreateTable(col0, row0);

        }

        private void CreateTable(int cols, int rows)
        {
            table.ColumnHeadersVisible = true;
            table.RowHeadersVisible = true;
            table.ColumnCount = cols;


            FillHeaders(cols, rows);

            table.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            newtable.setTable(cols, rows);
        }

        private void FillHeaders(int cols, int rows)

        {

            for (int i = 0; i < cols; i++)
            {
                table.Columns[i].HeaderText = Sys26.To26Sys(i);
                table.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add("");
                table.Rows[i].HeaderCell.Value = i.ToString();
            }
        }






        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            CellManager.Instance.CurrentCell = new Cell(col, row);
            string expression = Table.grid[row][col].expression;
            string value = Table.grid[row][col].value;
            textBox.Text = expression;
            textBox.Focus();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            int col = table.SelectedCells[0].ColumnIndex;
            int row = table.SelectedCells[0].RowIndex;
            string expression = textBox.Text;
            if (expression == "") return;
            newtable.ChangeCell(row, col, expression, table);
            table[col, row].Value = Table.grid[row][col].value;

        }

        private void SaveTable(string path)
        {
            savepath = path;
            table.EndEdit();
            DataTable dtable = new DataTable("something");
            ForgeDataTable(dtable);
            dtable.WriteXml(path);
        }

        private void ForgeDataTable(DataTable dtable)
        {
            foreach (DataGridViewColumn c in table.Columns)
            {
                dtable.Columns.Add(c.Index.ToString());
            }
            foreach (DataGridViewRow r in table.Rows)
            {
                DataRow dataRow = dtable.NewRow();
                foreach (DataColumn c in dtable.Columns)
                {
                    Cell cell = (Cell)r.Cells[Int32.Parse(c.ColumnName)].Tag;
                    dataRow[c.ColumnName] = cell.value;
                }
                dtable.Rows.Add(dataRow);
            }
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

        private void LoadTable(string path)
        {
            savepath = path;
            DataSet dataset = new DataSet();
            dataset.ReadXml(path);
            DataTable dtable = dataset.Tables[0];

            table.ColumnCount = dtable.Columns.Count;
            table.RowCount = dtable.Rows.Count;

            foreach (DataGridViewRow r in table.Rows)
            {
                foreach (DataGridViewCell cell in r.Cells)
                {
                    Cell temp = new Cell(cell.RowIndex, cell.ColumnIndex);
                    string value = dtable.Rows[cell.RowIndex][cell.ColumnIndex].ToString();
                    temp.value = value;
                    cell.Tag = temp;

                }
            }

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CellManager.Instance.CurrentCell = new Cell();
                LoadTable(openFileDialog.FileName);
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
            table.Rows[newtable.rows].HeaderCell.Value = (newtable.rows).ToString();
            //newtable.AddRow(table);
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("There are no rows!");
                return;
            }
            string name = Sys26.To26Sys(newtable.cols); ;
            table.Columns.Add(name, name);
            //newtable.AddColumn(table);
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("There are no rows!");
                return;
            }
            if (!newtable.DeleteRow(table))
                return;
            table.Rows.RemoveAt(newtable.rows);
        }

        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            if (table.Columns.Count == 0)
            {
                MessageBox.Show("There are no columns!");
                return;
            }
            if (!newtable.DeleteColumn(table))
                return;
            table.Columns.RemoveAt(newtable.cols);
        }
    }
}
