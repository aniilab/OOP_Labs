using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoExcel
{
    class Cell
    {
        public string expression { set; get; }
        public string value { set; get; }
        public string name { set; get; }
        public int row { set; get; }
        public int col { set; get; }

        public List<Cell> pointersToThis = new List<Cell>();
        public List<Cell> refsFromThis = new List<Cell>();
        public List<Cell> newrefsFromThis = new List<Cell>();
        public Cell() { }
        public Cell(int i, int j)
        {
            row = i;
            col = j;
            name = Sys26.To26Sys(col) + row.ToString();
            value = "0";
            expression = "";
        }

        public void SetCell(string e, string v, List<Cell> refs, List<Cell> pointers)
        {
            value = v;
            expression = e;
            refsFromThis = new List<Cell>(refs);
            pointersToThis = new List<Cell>(pointers);

        }

        public bool CheckLoop(List<Cell> list)
        {
            foreach (Cell cell in list)
            {
                if (cell.name == name) return false;
            }
            foreach (Cell p in pointersToThis)
            {
                foreach (Cell cell in list)
                {
                    if (cell.name == p.name) return false;
                }
                if (!p.CheckLoop(list)) return false;
            }
            return true;
        }

        public void AddPointersRefs()
        {
            foreach (Cell point in newrefsFromThis)
            {
                point.pointersToThis.Add(this);
            }
            refsFromThis = newrefsFromThis;
        }

        public void DelPointersRefs()
        {
            if (refsFromThis != null)
            {
                foreach (Cell point in refsFromThis)
                {
                    point.pointersToThis.Remove(this);
                }
                refsFromThis = null;
            }
        }
    }
}

