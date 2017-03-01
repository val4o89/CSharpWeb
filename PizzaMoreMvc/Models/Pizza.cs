using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public partial class Pizza
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Reciepe { get; set; }

        public string ImageUrl { get; set; }

        public int? UpVotes { get; set; }

        public int? DownVotes { get; set; }

        [ForeignKey("User")]
        public int OwnerId { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<div class=\"thumbnail col-lg-3\" style=\"margin-right: 8%\">");
            sb.AppendLine($"<img src=\"{ImageUrl}\" alt=\"300x150\">");
            sb.AppendLine($"<div class=\"caption\">");
            sb.AppendLine($"<h3>{Title}</h3>");
            sb.AppendLine($"<p><small>Reciepe: {Reciepe}</small></p>");
            sb.AppendLine($"<p><small>UpVotes: {UpVotes}</small></p>");
            sb.AppendLine($"<p><small>DownVotes: {DownVotes}</small></p>");
            sb.AppendLine($"<form method=\"POST\" action=\"/home/menu\">");
            sb.AppendLine($"<input type=\"hidden\" name=\"PizzaId\" value=\"{Id}\">");
            sb.AppendLine($"<button type=\"submit\" class=\"btn btn-primary\" name=\"Vote\" value=\"1\">Vote Up</button>");
            sb.AppendLine($"<button type=\"submit\" class=\"btn btn-primary\" name=\"Vote\" value=\"-1\">Vote Down</button>");
            sb.AppendLine($"</form>");
            sb.AppendLine($"</div>");
            sb.AppendLine($"</div>");

            return sb.ToString();
        }
    }
}
