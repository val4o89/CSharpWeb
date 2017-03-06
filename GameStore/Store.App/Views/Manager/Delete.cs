namespace Store.App.Views.Manager
{
    using Consts;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class Delete : IRenderable<DeleteGameViewModel>
    {
        public DeleteGameViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.NavLogged));
            sb.AppendLine(string.Format(File.ReadAllText(Constants.ContentPath + Constants.DeleteGame), Model.Id, Model.Name));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
