namespace Store.App.Views.Home
{
    using Consts;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class All : IRenderable<IEnumerable<GameViewModel>>
    {
        public IEnumerable<GameViewModel> Model { get; set; }

        public string Render()
        {
            string thumb = File.ReadAllText(Constants.ContentPath + Constants.Thumbnail);


            var sb = new StringBuilder();
            var sbThumbnail = new StringBuilder();

            var thumbCounter = 1;
            foreach (var game in Model)
            {
                if (thumbCounter == 1)
                {
                    sbThumbnail.AppendLine("<div class=\"card-group\">");
                }
                sbThumbnail.AppendLine(string.Format(thumb, $"src=\"{game.Thumbnail}\"", game.Title, game.Price, game.Size, game.Description.Substring(0, 300), game.GameId));
                if (thumbCounter == 3)
                {
                    sbThumbnail.AppendLine("</div>");
                    thumbCounter = 0;
                }
                thumbCounter++;
            }
            if (thumbCounter < 3)
            {
                sbThumbnail.AppendLine("</div>");
            }

            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.NavLogged));
            sb.AppendLine(string.Format(File.ReadAllText(Constants.ContentPath + Constants.Home), sbThumbnail));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
