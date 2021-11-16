using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LabXML
{
    class SAX:IStrategy
    {
        private List<Movie> Lres = null;
        public List<Movie> AnalyzeFile(Movie mySearch, string path)
        {
            XmlReader reader = XmlReader.Create(path);
            List<Movie> res = new List<Movie>();

            Movie find = null;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Movie")
                        {
                            find = new Movie();
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "Name")
                                {
                                    find.Name = reader.Value;
                                }
                                if (reader.Name == "Genre")
                                {
                                    find.Genre = reader.Value;
                                }
                                if (reader.Name == "ReleaseDate")
                                {
                                    find.ReleaseDate = reader.Value;
                                }
                                if (reader.Name == "RunningTime")
                                {
                                    find.RunningTime = reader.Value;
                                }
                                if (reader.Name == "Budget")
                                {
                                    find.Budget = reader.Value;
                                }
                                if (reader.Name == "Country")
                                {
                                    find.Country = reader.Value;
                                }
                                if (reader.Name == "Watched")
                                {
                                    find.Watched = reader.Value;
                                }
                                if (reader.Name == "Production")
                                {
                                    find.Production = reader.Value;
                                }
                            }
                            res.Add(find);
                        }
                        break;
                }
            }
            Lres = Filter(res, mySearch);
            return Lres;
        }

        private List<Movie> Filter(List<Movie> allres, Movie Temp)
        {
            List<Movie> newres = new List<Movie>();
            if (allres != null)
            {
                foreach (Movie s in allres)
                {
                    if ((Temp.Name == s.Name || Temp.Name == null) &&
                        (Temp.Budget == s.Budget || Temp.Budget == null) &&
                        (Temp.ReleaseDate == s.ReleaseDate || Temp.ReleaseDate == null) &&
                        (Temp.Country == s.Country || Temp.Country == null) &&
                        (Temp.RunningTime == s.RunningTime || Temp.RunningTime == null) &&
                        (Temp.Watched == s.Watched || Temp.Watched == null) &&
                        (Temp.Production == s.Production || Temp.Production == null) &&
                        (Temp.Genre == s.Genre || Temp.Genre == null))
                    {
                        newres.Add(s);
                    }
                }
            }
            return newres;
        }
    }
}
