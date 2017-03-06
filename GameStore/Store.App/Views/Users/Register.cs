namespace Store.App.Views.Users
{
    using Consts;
    using SimpleMVC.Interfaces;
    using System;
    using System.IO;
    using System.Text;

    public class Register : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Register));
            sb.AppendLine(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
