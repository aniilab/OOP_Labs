using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PseudoExcel
{
    public class Table
    {
        [JsonProperty]
        public int cols;

        [JsonProperty]
        public int rows;

        [JsonProperty]
        public List<List<Cell>> grid = new List<List<Cell>>();

        [JsonProperty]
        private Dictionary<string, string> CellNameValue = new Dictionary<string, string>();

        public Table()
        {}

        public void SetTable(int col, int row)
        {
            Clear();
            cols = col;
            rows = row;
            for (int i = 0; i < rows; i++)
            {
                List<Cell> newrow = new List<Cell>();
                for (int j = 0; j < cols; j++)
                {
                    Cell temp = new Cell(i, j);
                    newrow.Add(temp);
                    CellNameValue.Add(temp.name, "");
                }
                grid.Add(newrow);
            }
        }
        public void Clear()
        {
            foreach (List<Cell> list in grid)
            {
                list.Clear();
            }
            grid.Clear();
            CellNameValue.Clear();
            rows = 0;
            cols = 0;
        }

        public void ChangeCell(int row, int column, string expression, DataGridView dgv)
        {
            grid[row][column].DeletePointersAndRefs();
            grid[row][column].NewCellsPointOnMe.Clear();

            if (expression != "")
            {
                if (expression[0] != '=')
                {
                    grid[row][column].value = expression;
                    CellNameValue[Sys26.To26Sys(column)+row.ToString()] = expression;
                    foreach (Cell cell in grid[row][column].PointersOnCells)
                    {
                        RefreshCellAndPointers(cell, dgv);
                    }
                    return;
                }
            }

            string new_expression = ConvertReferences(row, column, expression);

            if (new_expression != "")
            {
                new_expression = new_expression.Remove(0, 1);
            }

            if (!grid[row][column].CheckLoop(grid[row][column].NewCellsPointOnMe))
            {
                MessageBox.Show("There is a loop! Please, change your expression.");
                return;
            }

            grid[row][column].AddPointersAndRefs();
            string value = Calculate(new_expression);
            if (value == "error")
            {
                MessageBox.Show("Error in the cell - " + grid[row][column].name);
                return;
            }


            grid[row][column].expression = expression;
            grid[row][column].value = value;
            CellNameValue[grid[row][column].name] = value;
            foreach (Cell cell in grid[row][column].PointersOnCells)
                RefreshCellAndPointers(cell, dgv);

            return;
        }

        public bool RefreshCellAndPointers(Cell cell, DataGridView dgv)
        {
            cell.NewCellsPointOnMe.Clear();
            string new_expression = ConvertReferences(cell.row, cell.col, cell.expression);
            new_expression = new_expression.Remove(0, 1);
            string value = Calculate(new_expression);

            if (value == "error")
            {
                MessageBox.Show("Error in the cell - " + cell.name);
                return false;
            }

            grid[cell.row][cell.col].value = value;
            CellNameValue[grid[cell.row][cell.col].name] = value;
            dgv[cell.col, cell.row].Value = value;

            foreach (Cell point in cell.PointersOnCells)
            {
                if (!RefreshCellAndPointers(point, dgv))
                    return false;
            }
            return true;
        }

        public string ConvertReferences(int row, int column, string expression)
        {
            string cellPattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(cellPattern, RegexOptions.IgnoreCase);
            Index nums;

            foreach (Match match in regex.Matches(expression))
            {
                if (CellNameValue.ContainsKey(match.Value))
                {
                    nums = Sys26.From26Sys(match.Value);
                    grid[row][column].NewCellsPointOnMe.Add(grid[nums.row_][nums.col_]);
                }
            }

            MatchEvaluator evaluator = new MatchEvaluator(referencesToValue);
            string new_expression = regex.Replace(expression, evaluator);
            return new_expression;
        }

        public string referencesToValue(Match m)
        {
            if (CellNameValue.ContainsKey(m.Value))
                if (CellNameValue[m.Value] == "")
                    return "0";
                else
                    return CellNameValue[m.Value];
            return m.Value;
        }

        public string Calculate(string expression)
        {
            string result = null;
            try
            {
                result = Calculator.Evaluate(expression);
                if (result == "∞")
                {
                    MessageBox.Show("The expression is approaching infinity. Be attentive!");
                }
                return result;
            }
            catch(Exception e)
            {
                return "error";
            }
        }

        public void RefreshRefs()
        {
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    //if (cell.CellsPointOnMe != null)
                        cell.CellsPointOnMe.Clear();
                    //if (cell.NewCellsPointOnMe != null)
                        cell.NewCellsPointOnMe.Clear();
                    if (cell.expression == "")
                        continue;
                    string new_expression = cell.expression;
                    if (cell.expression[0] == '=')
                    {
                        new_expression = ConvertReferences(cell.row, cell.col, cell.expression);
                        cell.CellsPointOnMe.AddRange(cell.NewCellsPointOnMe);
                    }
                }
            }
        }

        public void AddRow(DataGridView dgv)
        {
            List<Cell> newRow = new List<Cell>();

            for (int j = 0; j < cols; j++)
            {
                Cell temp = new Cell(rows, j);
                newRow.Add(temp);
                CellNameValue.Add(temp.name, "");
            }
            grid.Add(newRow);
            RefreshRefs();
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    //if (cell.CellsPointOnMe != null)
                    //{
                        foreach (Cell cell_ref in cell.CellsPointOnMe)
                        {
                            if (cell_ref.row == rows)
                            {
                                if (!cell_ref.PointersOnCells.Contains(cell))
                                    cell_ref.PointersOnCells.Add(cell);
                            }
                        }
                    //}
                }
            }
            for (int i = 0; i < cols; i++)
            {
                ChangeCell(rows, i, "", dgv);
            }

            rows++;
        }

        public void AddColumn(DataGridView dgv)
        {
            List<Cell> newCol = new List<Cell>();

            for (int i = 0; i < rows; i++)
            {
                Cell temp = new Cell(i, cols);
                grid[i].Add(temp);
                CellNameValue.Add(temp.name, "");
            }

            RefreshRefs();
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    //if (cell.CellsPointOnMe != null)
                    //{
                        foreach (Cell cell_ref in cell.CellsPointOnMe)
                        {
                            if (cell_ref.col == cols)
                            {
                                if (!cell_ref.PointersOnCells.Contains(cell))
                                    cell_ref.PointersOnCells.Add(cell);
                            }
                        }
                    //}
                }
            }
            for (int i = 0; i < rows; i++)
            {
                ChangeCell(i, cols, "", dgv);
            }
            cols++;
        }

        public bool DeleteRow(DataGridView dataGridView)
        {
            List<Cell> lastRow = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (rows == 1 || rows == 0)
                return false;

            int currow = rows-1;

            for (int i = 0; i < cols; i++)
            {
                string name = Sys26.To26Sys(i)+currow.ToString();

                if (CellNameValue[name] != "0" && CellNameValue[name] != "" && CellNameValue[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[currow][i].PointersOnCells.Count != 0)
                    lastRow.AddRange(grid[currow][i].PointersOnCells);
            }

            if (lastRow.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                    errorMessage += ". ";
                }

                if (lastRow.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current row : ";
                    foreach (Cell cell in lastRow)
                    {
                        errorMessage += string.Join(";", cell.name);
                        errorMessage += ". ";
                    }
                }

                errorMessage += "Are you sure you want to delete this row?";
                DialogResult res = MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                    return false;
            }

            for (int i = 0; i < cols; i++)
            {
                string name = Sys26.To26Sys(i)+currow.ToString();
                CellNameValue.Remove(name);
            }

            foreach (Cell cell in lastRow)
                RefreshCellAndPointers(cell, dataGridView);
            grid.RemoveAt(currow);
            rows--;
            return true;
        }

        public bool DeleteColumn(DataGridView dataGridView)
        {
            List<Cell> lastCol = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (cols == 0 || cols == 1)
                return false;

            int curcol = cols-1;

            for (int i = 0; i < rows; i++)
            {
                string name = Sys26.To26Sys(curcol) + (i).ToString();
                if (CellNameValue[name] != "0" && CellNameValue[name] != "" && CellNameValue[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[i][curcol].PointersOnCells.Count != 0)
                    lastCol.AddRange(grid[i][curcol].PointersOnCells);
            }

            if (lastCol.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                    errorMessage += ". ";
                }

                if (lastCol.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current column: ";
                    foreach (Cell cell in lastCol)
                        errorMessage += string.Join(";", cell.name);
                    errorMessage += ". ";
                }

                errorMessage += "Are you sure you want to delete this column?";
                DialogResult res = MessageBox.Show(errorMessage, "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                    return false;
            }

            for (int i = 0; i < rows; i++)
            {
                string name = Sys26.To26Sys(curcol) + i.ToString();
                CellNameValue.Remove(name);
            }

            foreach (Cell cell in lastCol)
                RefreshCellAndPointers(cell, dataGridView);

            for (int i = 0; i < rows; i++)
            {
                grid[i].RemoveAt(curcol);
            }

            cols--;
            return true;
        }

        public void FillDGV(DataGridView table)
        {
            table.InitializeDGV(cols, rows);

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    table.Rows[i].Cells[j].Value = grid[i][j].value;
                }
            }
        }
    }
}

