using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PseudoExcelExpressionCalculator;
using PseudoExcel.Utils;

namespace PseudoExcel.Entities
{
    public class Table
    {
        [JsonProperty]
        public int ColumnsAmount { get; private set; }

        [JsonProperty]
        public int RowsAmount { get; private set; }

        [JsonProperty]
        public List<List<Cell>> grid = new List<List<Cell>>();

        [JsonProperty]
        private Dictionary<string, string> CellNameValue = new Dictionary<string, string>();

        private Table() { }

        public Table(int columns, int rows)
        {
            ColumnsAmount = columns;
            RowsAmount = rows;
            for (int i = 0; i < rows; i++)
            {
                List<Cell> newrow = new List<Cell>();
                for (int j = 0; j < columns; j++)
                {
                    Cell temp = new Cell(i, j);
                    newrow.Add(temp);
                    CellNameValue.Add(temp.Name, string.Empty);
                }
                grid.Add(newrow);
            }
        }

        public bool ChangeCell(int row, int column, string expression, DataGridView dgv)
        {
            grid[row][column].DeletePointersAndRefs();
            grid[row][column].NewCellsPointOnMe.Clear();

            if (!string.IsNullOrEmpty(expression))
            {
                if (!expression.StartsWith("="))
                {
                    grid[row][column].Value = expression;
                    grid[row][column].Expression = string.Empty;
                    CellNameValue[Sys26.To26Sys(column) + row.ToString()] = expression;
                    foreach (Cell cell in grid[row][column].PointersOnCells)
                    {
                        if (!RefreshCellAndPointers(cell, dgv))
                            return false;
                    }
                    return true;
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
                return false;
            }

            grid[row][column].AddPointersAndRefs();
            string value = Calculate(new_expression);
            if (value == "error")
            {
                MessageBox.Show("Error in the cell - " + grid[row][column].Name);
                return false;
            }


            grid[row][column].Expression = expression;
            grid[row][column].Value = value;
            CellNameValue[grid[row][column].Name] = value;
            foreach (Cell cell in grid[row][column].PointersOnCells.ToList())
            {
                if (!RefreshCellAndPointers(cell, dgv))
                    return false;
            }

            return true;
        }

        public bool RefreshCellAndPointers(Cell cell, DataGridView dgv)
        {
            cell.NewCellsPointOnMe.Clear();
            string new_expression = ConvertReferences(cell.RowNumber, cell.ColumnNumber, cell.Expression);
            new_expression = new_expression.Remove(0, 1);
            string value = Calculate(new_expression);

            if (value == "error")
            {
                MessageBox.Show("Error in the cell - " + cell.Name);
                return false;
            }

            grid[cell.RowNumber][cell.ColumnNumber].Value = value;
            CellNameValue[grid[cell.RowNumber][cell.ColumnNumber].Name] = value;

            dgv[cell.ColumnNumber, cell.RowNumber].Value = value;

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

            MatchEvaluator evaluator = new MatchEvaluator(ReferencesToValue);
            string new_expression = regex.Replace(expression, evaluator);
            return new_expression;
        }

        public string ReferencesToValue(Match m)
        {
            if (CellNameValue.ContainsKey(m.Value) && !string.IsNullOrWhiteSpace(CellNameValue[m.Value]))
                return CellNameValue[m.Value];
            else
                return "0";
        }

        public string Calculate(string expression)
        {
            string result;
            try
            {
                result = Calculator.Evaluate(expression);
                if (result == "∞")
                {
                    MessageBox.Show("The expression is approaching infinity. Be attentive!");
                }
                return result;
            }
            catch (Exception e)
            {
                return "error";
            }
        }

        public void RefreshRefs()
        {
            foreach (List<Cell> row in grid)
            {
                foreach (Cell cell in row)
                {
                    cell.CellsPointOnMe.Clear();
                    cell.NewCellsPointOnMe.Clear();

                    if (string.IsNullOrEmpty(cell.Expression))
                        continue;

                    if (cell.Expression.StartsWith("="))
                    {
                        ConvertReferences(cell.RowNumber, cell.ColumnNumber, cell.Expression);
                        cell.CellsPointOnMe.AddRange(cell.NewCellsPointOnMe);
                    }
                }
            }
        }

        public void AddRow(DataGridView dgv)
        {
            List<Cell> newRow = new List<Cell>();

            for (int j = 0; j < ColumnsAmount; j++)
            {
                Cell temp = new Cell(RowsAmount, j);
                newRow.Add(temp);
                CellNameValue.Add(temp.Name, "");
            }
            grid.Add(newRow);
            RefreshRefs();
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    foreach (Cell cell_ref in cell.CellsPointOnMe)
                    {
                        if (cell_ref.RowNumber == RowsAmount)
                        {
                            if (!cell_ref.PointersOnCells.Contains(cell))
                                cell_ref.PointersOnCells.Add(cell);
                        }
                    }
                }
            }
            for (int i = 0; i < ColumnsAmount; i++)
            {
                ChangeCell(RowsAmount, i, "", dgv);
            }

            RowsAmount++;
        }

        public void AddColumn(DataGridView dgv)
        {
            List<Cell> newCol = new List<Cell>();

            for (int i = 0; i < RowsAmount; i++)
            {
                Cell temp = new Cell(i, ColumnsAmount);
                grid[i].Add(temp);
                CellNameValue.Add(temp.Name, "");
            }

            RefreshRefs();
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    foreach (Cell cell_ref in cell.CellsPointOnMe)
                    {
                        if (cell_ref.ColumnNumber == ColumnsAmount)
                        {
                            if (!cell_ref.PointersOnCells.Contains(cell))
                                cell_ref.PointersOnCells.Add(cell);
                        }
                    }
                }
            }
            for (int i = 0; i < RowsAmount; i++)
            {
                ChangeCell(i, ColumnsAmount, "", dgv);
            }
            ColumnsAmount++;
        }

        public bool DeleteRow(DataGridView dataGridView)
        {
            List<Cell> cellsPointingOnMe = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (RowsAmount <= 1)
                return false;

            int currow = RowsAmount - 1;

            for (int i = 0; i < ColumnsAmount; i++)
            {
                string name = Sys26.To26Sys(i) + currow.ToString();

                if (CellNameValue[name] != "0" && CellNameValue[name] != "" && CellNameValue[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[currow][i].PointersOnCells.Count != 0)
                    cellsPointingOnMe.AddRange(grid[currow][i].PointersOnCells);
            }

            if (cellsPointingOnMe.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                    errorMessage += ". ";
                }

                if (cellsPointingOnMe.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current row : ";
                    foreach (Cell cell in cellsPointingOnMe)
                    {
                        errorMessage += string.Join(";", cell.Name);
                        errorMessage += ". ";
                    }
                }

                errorMessage += "Are you sure you want to delete this row?";
                DialogResult res = MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                    return false;
            }

            for (int i = 0; i < ColumnsAmount; i++)
            {
                string name = Sys26.To26Sys(i) + currow.ToString();
                CellNameValue.Remove(name);
            }

            foreach (Cell cell in cellsPointingOnMe)
                RefreshCellAndPointers(cell, dataGridView);
            grid.RemoveAt(currow);
            RowsAmount--;
            return true;
        }

        public bool DeleteColumn(DataGridView dataGridView)
        {
            List<Cell> cellsPointingOnMe = new List<Cell>();
            List<string> notEmptyCells = new List<string>();

            if (ColumnsAmount == 0 || ColumnsAmount == 1)
                return false;

            int curcol = ColumnsAmount - 1;

            for (int i = 0; i < RowsAmount; i++)
            {
                string name = Sys26.To26Sys(curcol) + (i).ToString();
                if (CellNameValue[name] != "0" && CellNameValue[name] != "" && CellNameValue[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[i][curcol].PointersOnCells.Count != 0)
                    cellsPointingOnMe.AddRange(grid[i][curcol].PointersOnCells);
            }

            if (cellsPointingOnMe.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";

                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                    errorMessage += ". ";
                }

                if (cellsPointingOnMe.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current column: ";
                    foreach (Cell cell in cellsPointingOnMe)
                        errorMessage += string.Join(";", cell.Name);
                    errorMessage += ". ";
                }

                errorMessage += "Are you sure you want to delete this column?";
                DialogResult res = MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                    return false;
            }

            for (int i = 0; i < RowsAmount; i++)
            {
                string name = Sys26.To26Sys(curcol) + i.ToString();
                CellNameValue.Remove(name);
            }

            foreach (Cell cell in cellsPointingOnMe)
                RefreshCellAndPointers(cell, dataGridView);

            for (int i = 0; i < RowsAmount; i++)
            {
                grid[i].RemoveAt(curcol);
            }

            ColumnsAmount--;
            return true;
        }
    }
}
