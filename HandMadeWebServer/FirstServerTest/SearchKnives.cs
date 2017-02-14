using KivesDatabase;
using Knives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirstServerTest
{
    public static class SearchKnives
    {
        public static IEnumerable<Knive> Search(KnivesDbContext db, string url)
        {
            string urlParameters = WebUtility.UrlDecode(url.Substring(url.LastIndexOf('?') + 1));

            var kniveData = urlParameters.Split('=');

            if (kniveData.Length == 2 & kniveData[0] == "model")
            {
                return db.Knives.ToList().Where(x => x.Name.ToLower().Contains(kniveData[1].ToLower()));
            }
            else
            {
                return db.Knives;
            }
        }
    }
}
