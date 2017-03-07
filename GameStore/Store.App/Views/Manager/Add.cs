namespace Store.App.Views.Manager
{
    using Consts;
    using SimpleMVC.Interfaces;
    using System;
    using System.IO;
    using System.Text;

    public class Add : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.NavLogged));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Add));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
