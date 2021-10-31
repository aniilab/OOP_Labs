using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace PseudoExcel
{
    class Table
    {
        public int cols;
        public int rows;
        public static List<List<Cell>> grid = new List<List<Cell>>();
        public Dictionary<string, string> dict = new Dictionary<string, string>();



        public void setTable(int col, int row)
        {
            Clear();
            cols = col;
            rows = row;
            for (int i = 0; i < rows; i++)
            {
                List<Cell> newrow = new List<Cell>();
                for (int j = 0; j < cols; j++)
                {
                    newrow.Add(new Cell(i, j));
                    dict.Add(newrow.Last().name, "");
                }
                grid.Add(newrow);
            }

        }

        public void Clear()
        {
            foreach (List<Cell> item in grid)
            {
                item.Clear();
            }
            grid.Clear();
            dict.Clear();
            rows = 0;
            cols = 0;
        }
        private string FullName(int r, int c)
        {
            Cell cell = new Cell(r, c);
            return cell.name;
        }
        public void ChangeCell(int row, int col, string expression, System.Windows.Forms.DataGridView dataGridView)
        {
            grid[row][col].DelPointersRefs();
            grid[row][col].expression = expression;
            grid[row][col].newrefsFromThis.Clear();

            if (expression != "")
            {
                if (expression[0] != '=')
                {
                    grid[row][col].value = expression;
                    dict[FullName(row, col)] = expression;
                    foreach (Cell cell in grid[row][col].pointersToThis)
                    {
                        RefreshCellAndPointers(cell, dataGridView);
                    }
                    return;
                }
            }

            string new_expression = ConvertReferences(row, col, expression);
            if (new_expression != "")
            {
                new_expression = new_expression.Remove(0, 1);
            }
            //if (!grid[row][col].CheckLoop(grid[row][col].newrefsFromThis))
            //{
            //    System.Windows.Forms.MessageBox.Show("There is a loop! Change the expression.");
            //    grid[row][col].expression = "=";
            //    grid[row][col].value = "0";
            //    dataGridView[col, row].Value = "0";
            //    return;
            //}

            grid[row][col].AddPointersRefs();
            string val = Calculate(new_expression);
            if (val == "Error")
            {
                System.Windows.Forms.MessageBox.Show("Error in cell " + FullName(row, col));
                grid[row][col].expression = "";
                grid[row][col].value = "0";
                dataGridView[col, row].Value = "0";
                return;
            }
            grid[row][col].value = val;
            dict[FullName(row, col)] = val;
            foreach (Cell cell in grid[row][col].pointersToThis)
                RefreshCellAndPointers(cell, dataGridView);
        }

        public bool RefreshCellAndPointers(Cell cell, System.Windows.Forms.DataGridView dataGridView)
        {
            cell.newrefsFromThis.Clear();
            string new_expression = ConvertReferences(cell.row, cell.col, cell.expression);
            new_expression = new_expression.Remove(0, 1);
            string Value = Calculate(new_expression);

            if (Value == "Error")
            {
                System.Windows.Forms.MessageBox.Show("Error in cell " + cell.name);
                cell.expression = "";
                cell.value = "0";
                dataGridView[cell.col, cell.row].Value = "0";
                return false;

            }
            grid[cell.row][cell.col].value = Value;
            dict[FullName(cell.row, cell.col)] = Value;
            dataGridView[cell.col, cell.row].Value = Value;

            foreach (Cell point in cell.pointersToThis)
            {
                if (!RefreshCellAndPointers(point, dataGridView))
                    return false;
            }
            return true;

        }
        public void RefreshReferences()
        {
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    if (cell.refsFromThis != null)
                        cell.refsFromThis.Clear();
                    if (cell.newrefsFromThis != null)
                        cell.newrefsFromThis.Clear();
                    if (cell.expression == "")
                        continue;
                    string new_expression = cell.expression;
                    if (cell.expression[0] == '=')
                    {
                        new_expression = ConvertReferences(cell.row, cell.col, cell.expression);
                        cell.refsFromThis.AddRange(cell.newrefsFromThis);
                    }
                }
            }
        }

        public string ConvertReferences(int row, int col, string expr)
        {
            string cellPattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(cellPattern, RegexOptions.IgnoreCase);
            Index nums;

            foreach (Match match in regex.Matches(expr))
            {
                if (dict.ContainsKey(match.Value))
                {
                    nums = Sys26.From26Sys(match.Value);
                    grid[row][col].newrefsFromThis.Add(grid[nums.row_][nums.col_]);

                }
            }
            MatchEvaluator evaluator = new MatchEvaluator(referenceToValue);
            string new_excpression = regex.Replace(expr, evaluator);
            return new_excpression;
        }

        public string referenceToValue(Match m)
        {
            if (dict.ContainsKey(m.Value))
                if (dict[m.Value] == "")
                    return "0";
                else
                    return dict[m.Value];
            return m.Value;
        }

        public string Calculate(string expression)
        {
            string res = null;
            try
            {
                res = Convert.ToString(Calculator.Evaluate(expression));
                if (res == "∞")
                {
                    res = "Dividing by zero error";
                }
                return res;
            }
            catch
            {
                return "Error";
            }
        }

        public bool DeleteRow(System.Windows.Forms.DataGridView dgv)
        {
            List<Cell> neededRow = new List<Cell>();


            List<string> notEmptyCells = new List<string>();

            if (rows == 0)
                return false;

            int curCount = rows - 1;

            for (int i = 0; i < cols; i++)
            {
                string name = FullName(curCount, i);

                if (dict[name] != "0" && dict[name] != "" && dict[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[curCount][i].pointersToThis.Count != 0)
                    neededRow.AddRange(grid[curCount][i].pointersToThis);
            }

            if (neededRow.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are filled cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                    errorMessage += ' ';
                }

                if (neededRow.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current row : ";
                    foreach (Cell cell in neededRow)
                    {
                        errorMessage += string.Join(";", cell.name);
                        errorMessage += " ";
                    }
                }

                errorMessage += "Are you sure you want to delete rhis row?";
                System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(errorMessage, "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);

                if (res == System.Windows.Forms.DialogResult.No)
                    return false;
            }

            for (int i = 0; i < cols; i++)
            {
                string name = FullName(curCount, i);
                dict.Remove(name);
            }

            foreach (Cell cell in neededRow)
                RefreshCellAndPointers(cell, dgv);
            grid.RemoveAt(curCount);
            rows--;
            return true;
        }


        public bool DeleteColumn(System.Windows.Forms.DataGridView dataGridView)
        {
            List<Cell> lastCol = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (cols == 0)
                return false;

            int curCount = cols - 1;

            for (int i = 0; i < rows; i++)
            {
                string name = FullName(i, curCount);
                if (dict[name] != "0" && dict[name] != "" && dict[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[i][curCount].pointersToThis.Count != 0)
                    lastCol.AddRange(grid[i][curCount].pointersToThis);
            }

            if (lastCol.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                }

                if (lastCol.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current column: ";
                    foreach (Cell cell in lastCol)
                        errorMessage += string.Join(";", cell.name);
                }

                errorMessage += "Are you sure you want to delete this column?";
                System.Windows.Forms.DialogResult res = System.Windows.Forms.MessageBox.Show(errorMessage, "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);

                if (res == System.Windows.Forms.DialogResult.No)
                    return false;
            }

            for (int i = 0; i < rows; i++)
            {
                string name = FullName(i, curCount);
                dict.Remove(name);
            }

            foreach (Cell cell in lastCol)
                RefreshCellAndPointers(cell, dataGridView);

            for (int i = 0; i < rows; i++)
            {
                grid[i].RemoveAt(curCount);
            }

            cols--;
            return true;
        }
    }

    

}

