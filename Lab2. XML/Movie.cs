using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabXML
{
    class Movie
    {
        public string Name = null;
        public string ReleaseDate = null;
        public string Genre = null;
        public string RunningTime = null;
        public string Budget = null;
        public string Production = null;
        public string Country = null;
        public string Watched = null;

        public Movie() { }
        public Movie(string[] data)
        {
            Name = data[0];
            ReleaseDate = data[1];
            Genre = data[2];
            RunningTime = data[3];
            Budget = data[4];
            Production = data[5];
            Country = data[6];
            Watched = data[7];
        }

        public bool Compare(Movie obj)
        {
            if ((Country == obj.Country) &&
                (Name == obj.Name) &&
                (ReleaseDate == obj.ReleaseDate) &&
                (Genre == obj.Genre) &&
                (RunningTime == obj.RunningTime) &&
                (Budget == obj.Budget) &&
                (Production == obj.Production) &&
                (Watched == obj.Watched))
                return true;
            else return false;
        }

    }

}
