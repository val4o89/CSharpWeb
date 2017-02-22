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
    public class Products : IRenderable<IEnumerable<ProductsViewModel>>
    {
        public IEnumerable<ProductsViewModel> Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine(File.ReadAllText("../../content/products-top.html"));

            foreach (var knive in Model)
            {
                sb.AppendLine($"<div class=\"thumbnail col-lg-3\" style=\"margin-right: 8%\">");
                sb.AppendLine($"<img src=\"{knive.Url}\" alt=\"300x150\">");
                sb.AppendLine($"<div class=\"caption\">");
                sb.AppendLine($"<h3>{knive.Name}</h3>");
                sb.AppendLine($"<p><small>${knive.Price}</small></p>");
                sb.AppendLine($"<form action=\"/home/buy\">");
                sb.AppendLine($"<input type=\"hidden\" name=\"id\" value=\"{knive.Id}\">");
                sb.AppendLine($"<input type=\"submit\" class=\"btn btn-primary\" role=\"button\" value=\"Buy Now\">");
                sb.AppendLine($"</form>");
                sb.AppendLine($"</div>");
                sb.AppendLine($"</div>");
            }

            sb.AppendLine(File.ReadAllText("../../content/products-botom.html"));

            return sb.ToString();
        }
    }
}
