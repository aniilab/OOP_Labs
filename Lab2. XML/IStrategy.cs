using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabXML
{
    interface IStrategy
    {
        List<Movie> AnalyzeFile(Movie mySearch, string path);
    }
}
