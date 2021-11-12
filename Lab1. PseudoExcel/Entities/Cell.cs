using Newtonsoft.Json;
using PseudoExcel.Utils;
using System.Collections.Generic;

namespace PseudoExcel.Entities
{
    public class Cell
    {
        [JsonProperty]
        public string Expression { get; set; }

        [JsonProperty]
        public string Value { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int RowNumber { get; set; }

        [JsonProperty]
        public int ColumnNumber { get; set; }

        [JsonIgnore]
        public List<Cell> PointersOnCells = new List<Cell>();
        [JsonIgnore]
        public List<Cell> CellsPointOnMe = new List<Cell>();
        [JsonIgnore]
        public List<Cell> NewCellsPointOnMe = new List<Cell>();

        private Cell() { }

        public Cell(int rowNumber, int columnNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
            Name = Sys26.To26Sys(columnNumber) + rowNumber.ToString();
            Value = string.Empty;
            Expression = string.Empty;
        }

        public bool CheckLoop(List<Cell> list)
        {
            foreach (Cell cell in list)
            {
                if (cell.Name == Name) return false;
            }
            foreach (Cell pointer in PointersOnCells)
            {
                foreach (Cell cell in list)
                {
                    if (cell.Name == pointer.Name) return false;
                }
                if (!pointer.CheckLoop(list)) return false;
            }
            return true;
        }

        public void AddPointersAndRefs()
        {
            foreach (Cell point in NewCellsPointOnMe)
            {
                point.PointersOnCells.Add(this);
            }
            CellsPointOnMe = NewCellsPointOnMe;
        }

        public void DeletePointersAndRefs()
        {
            foreach (Cell point in CellsPointOnMe)
            {
                point.PointersOnCells.Remove(this);
            }
            CellsPointOnMe.Clear();
        }
    }
}

