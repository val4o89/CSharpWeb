using PizzaMore.BindingModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Views.Home
{
    public class Addsuggestion : IRenderable<int>
    {
        public int Model { get; set; }

        public string Render()
        {
            var page = new StringBuilder();

            page.AppendLine(File.ReadAllText("../../content/menu-top.html"));

            page.AppendLine(string.Format(File.ReadAllText("../../content/menu-form.html"), $"value=\"{Model}\""));

            page.AppendLine(File.ReadAllText("../../content/menu-bottom.html"));

            return page.ToString();
        }
    }
}
