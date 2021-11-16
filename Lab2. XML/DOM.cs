using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LabXML
{
    class DOM : IStrategy
    {
        XmlDocument doc = new XmlDocument();
        public List<Movie> AnalyzeFile(Movie mySearch, string path)
        {
            doc.Load(path);
            List<List<Movie>> resultinfo = new List<List<Movie>>();

            if (mySearch.Name == null && mySearch.RunningTime == null && mySearch.Genre == null &&
                mySearch.ReleaseDate == null && mySearch.Production == null && mySearch.Watched == null &&
                mySearch.Country == null && mySearch.Budget == null) 
            {
                return ErrorCatch(doc);
            }

            if (mySearch.Name != null) resultinfo.Add(SearchByAttribute("Movie", "Name", mySearch.Name, doc));
            if (mySearch.RunningTime != null) resultinfo.Add(SearchByAttribute("Movie", "RunningTime", mySearch.RunningTime, doc));
            if (mySearch.Genre != null) resultinfo.Add(SearchByAttribute("Movie", "Genre", mySearch.Genre, doc));
            if (mySearch.ReleaseDate != null) resultinfo.Add(SearchByAttribute("Movie", "ReleaseDate", mySearch.ReleaseDate, doc));
            if (mySearch.Production != null) resultinfo.Add(SearchByAttribute("Movie", "Production", mySearch.Production, doc));
            if (mySearch.Watched != null) resultinfo.Add(SearchByAttribute("Movie", "Watched", mySearch.Watched, doc));
            if (mySearch.Country != null) resultinfo.Add(SearchByAttribute("Movie", "Country", mySearch.Country, doc));
            if (mySearch.Budget != null) resultinfo.Add(SearchByAttribute("Movie", "Budget", mySearch.Production, doc));

            return Cross(resultinfo, mySearch);
        }

        public List<Movie> SearchByAttribute(string Name, string Attribute, string Temp, XmlDocument doc)
        {
            List<Movie> find = new List<Movie>();

            if (Temp != null)
            {
                XmlNodeList lst = doc.SelectNodes("//" + Name + "[@" + Attribute + "=\"" + Temp + "\"]");
                foreach (XmlNode x in lst)
                {
                    find.Add(Info(x));
                }
            }
            return find;
        }

        public List<Movie> ErrorCatch(XmlDocument doc)
        {
            List<Movie> res = new List<Movie>();
            XmlNodeList lst = doc.SelectNodes("//" + "Movie");
            foreach (XmlNode x in lst)
            {
                res.Add(Info(x));
            }
            return res;
        }

        public Movie Info(XmlNode node)
        {
            Movie search = new Movie();
            search.Name = node.Attributes.GetNamedItem("Name").Value;
            search.RunningTime = node.Attributes.GetNamedItem("RunningTime").Value;
            search.Genre = node.Attributes.GetNamedItem("Genre").Value;
            search.ReleaseDate = node.Attributes.GetNamedItem("ReleaseDate").Value;
            search.Production = node.Attributes.GetNamedItem("Production").Value;
            search.Watched = node.Attributes.GetNamedItem("Watched").Value;
            search.Country = node.Attributes.GetNamedItem("Country").Value;
            search.Budget = node.Attributes.GetNamedItem("Budget").Value;

            return search;
        }

        public List<Movie> Cross(List<List<Movie>> Movies, Movie Temp)
        {
            List<Movie> res = new List<Movie>();
            List<Movie> clear = CheckNodes(Movies, Temp);
            foreach (Movie x in clear)
            {
                res.Add(x);
            }
            return res;
        }

        public List<Movie> CheckNodes(List<List<Movie>> Movie, Movie Temp)
        {
            List<Movie> res = new List<Movie>();
            foreach (List<Movie> x in Movie)
            {
                foreach (Movie s in x)
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
                        res.Add(s);
                    }
                }
            }
            return res;
        }
    }
}

