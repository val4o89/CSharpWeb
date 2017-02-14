using KivesDatabase;
using Knives.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstServerTest
{
    public static class ProductsPage
    {
        private static string topOfThePage = File.ReadAllText("../../content/products-top.html");
        private static string botomOfThePage = File.ReadAllText("../../content/products-botom.html");

        public static string ReturnPage(IEnumerable<Knive> knives)
        {
            var page = new StringBuilder();
            page.AppendLine(topOfThePage);

            foreach (var knive in knives)
            {
                page.AppendLine($"<div class=\"thumbnail col-lg-3\" style=\"margin-right: 8%\">");
                page.AppendLine($"<img src=\"{knive.Url}\" alt=\"300x150\">");
                page.AppendLine($"<div class=\"caption\">");
                page.AppendLine($"<h3>{knive.Name}</h3>");
                page.AppendLine($"<p><small>${knive.Prie}</small></p>");
                page.AppendLine($"<p><a href=\"#\" class=\"btn btn-primary\" role=\"button\">Buy Now</a></p>");
                page.AppendLine($"</div>");
                page.AppendLine($"</div>");
            }

            page.AppendLine(botomOfThePage);

            return page.ToString();
        }
        
    }
}
