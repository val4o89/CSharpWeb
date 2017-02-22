using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Views.Home
{
    public class Buy : IRenderable<ProductsViewModel>
    {
        public ProductsViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();

            string buyPage = File.ReadAllText("../../content/buy.html");
            sb.AppendLine("<div class=\"row\"");
            sb.AppendLine($"<div class=\"thumbnail col-lg-3\" style=\"margin-right: 8%\">");
            sb.AppendLine($"<img src=\"{Model.Url}\" alt=\"300x150\">");
            sb.AppendLine($"<div class=\"caption\">");
            sb.AppendLine($"<h3>{Model.Name}</h3>");
            sb.AppendLine($"<p><small>${Model.Price}</small></p>");
            sb.AppendLine($"</div>");
            sb.AppendLine($"</div>");
            sb.AppendLine($"</div>");

            string form = string.Format(File.ReadAllText("../../content/buy-form.html"), $"value=\"{Model.Id}\"");
            

            return string.Format(buyPage, sb.ToString(), form);
        }
    }
}