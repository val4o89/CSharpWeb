namespace Store.App.Views.Manager
{
    using Consts;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Edit : IRenderable<GameViewModel>
    {
        public GameViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.NavLogged));

            sb.AppendLine(string.Format(File.ReadAllText(Constants.ContentPath + Constants.EditGame),
                Model.GameId,
                Model.Title,
                Model.Description,
                Model.Thumbnail,
                Model.Price,
                Model.Size,
                Model.YoutubeId
                ));

            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
