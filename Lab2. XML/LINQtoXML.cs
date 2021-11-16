using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabXML
{
    class LINQtoXML : IStrategy
    {
        private List<Movie> find = null;

        XDocument doc = new XDocument();

        public List<Movie> AnalyzeFile(Movie mySearch, string path)
        {
            doc = XDocument.Load(@path);
            find = new List<Movie>();

            List<XElement> matches = (from val in doc.Descendants("Movie")
                                      where ((mySearch.Name == null || mySearch.Name == val.Attribute("Name").Value) &&
                                      (mySearch.Country == null || mySearch.Country == val.Attribute("Country").Value) &&
                                      (mySearch.Genre == null || mySearch.Genre == val.Attribute("Genre").Value) &&
                                      (mySearch.ReleaseDate == null || mySearch.ReleaseDate == val.Attribute("ReleaseDate").Value) &&
                                      (mySearch.RunningTime == null || mySearch.RunningTime == val.Attribute("RunningTime").Value) &&
                                      (mySearch.Production == null || mySearch.Production == val.Attribute("Production").Value) &&
                                      (mySearch.Budget == null || mySearch.Budget == val.Attribute("Budget").Value) &&
                                      (mySearch.Watched == null || mySearch.Watched == val.Attribute("Watched").Value))
                                      select val).ToList();

            foreach (XElement match in matches)
            {
                Movie res = new Movie();
                res.Name = match.Attribute("Name").Value;
                res.Country = match.Attribute("Country").Value;
                res.Genre = match.Attribute("Genre").Value;
                res.RunningTime = match.Attribute("RunningTime").Value;
                res.ReleaseDate = match.Attribute("ReleaseDate").Value;
                res.Production = match.Attribute("Production").Value;
                res.Budget = match.Attribute("Budget").Value;
                res.Watched = match.Attribute("Watched").Value;
                find.Add(res);
            }
            return find;
        }
    }
}

