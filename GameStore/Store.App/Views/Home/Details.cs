namespace Store.App.Views.Home
{
    using Consts;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Details : IRenderable<GameViewModel>
    {
        public GameViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.NavLogged));
            sb.AppendLine(string.Format(File.ReadAllText(Constants.ContentPath + Constants.Details), Model.Title, Model.YoutubeId, Model.Description, Model.Price, Model.Size, Model.ReleaseDate, Model.GameId));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
