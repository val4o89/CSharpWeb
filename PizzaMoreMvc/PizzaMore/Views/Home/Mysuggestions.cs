using Models;
using SimpleMVC.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Views.Home
{
    public class Mysuggestions : IRenderable<ICollection<Pizza>>
    {
        public ICollection<Pizza> Model { get; set; }

        public string Render()
        {
            var page = new StringBuilder();
            page.AppendLine(File.ReadAllText("../../content/menu-top.html"));

            foreach (var pizza in Model)
            {
                page.AppendLine(pizza.ToString());
            }

            page.AppendLine(File.ReadAllText("../../content/menu-bottom.html"));

            return page.ToString();
        }
    }
}
