using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoExcel
{
    public class Cell
    {
        [JsonProperty]
        public string expression { set; get; }

        [JsonProperty]
        public string value { set; get; }

        [JsonProperty]
        public string name { set; get; }

        [JsonProperty]
        public int row { set; get; }

        [JsonProperty]
        public int col { set; get; }

        [JsonIgnore]
        public List<Cell> PointersOnCells = new List<Cell>();
        [JsonIgnore]
        public List<Cell> CellsPointOnMe = new List<Cell>();
        [JsonIgnore]
        public List<Cell> NewCellsPointOnMe = new List<Cell>();

        private Cell() { }

        public Cell(int i, int j)
        {
            row = i;
            col = j;
            name = Sys26.To26Sys(col) + row.ToString();
            value = "";
            expression = "";
        }

        public bool CheckLoop(List<Cell> list)
        {
            foreach (Cell cell in list)
            {
                if (cell.name == name) return false;
            }
            foreach (Cell pointer in PointersOnCells)
            {
                foreach (Cell cell in list)
                {
                    if (cell.name == pointer.name) return false;
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
            //if (CellsPointOnMe != null)
            //{
                foreach (Cell point in CellsPointOnMe)
                {
                    point.PointersOnCells.Remove(this);
                }
                CellsPointOnMe.Clear();
            //}
        }
    }
}

