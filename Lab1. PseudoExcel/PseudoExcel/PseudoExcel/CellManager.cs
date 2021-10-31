using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoExcel
{
    class CellManager
    {
        private static CellManager instance_;

        public Cell CurrentCell { get; set; }
        public static CellManager Instance
        {
            get
            {
                if (instance_ == null)
                {
                    instance_ = new CellManager();
                }
                return instance_;
            }
            set { }
        }
    }
}
