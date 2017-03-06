namespace Store.App.Views.Manager
{
    using Consts;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class All : IRenderable<IEnumerable<ManageGameViewModel>>
    {
        public IEnumerable<ManageGameViewModel> Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.Append(File.ReadAllText(Constants.ContentPath + Constants.Header));
            sb.Append(File.ReadAllText(Constants.ContentPath + Constants.NavLogged));

            var sbRows = new StringBuilder();

            foreach (var game in Model)
            {
                sbRows.AppendLine(string.Format(File.ReadAllText(Constants.ContentPath + Constants.TableRow), game.Name, game.Size, game.Price, game.Id));
            }

            sb.AppendLine(string.Format(File.ReadAllText(Constants.ContentPath + Constants.AdminGames), sbRows.ToString()));

            sb.Append(File.ReadAllText(Constants.ContentPath + Constants.Footer));

            return sb.ToString();
        }
    }
}
