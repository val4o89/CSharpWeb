namespace SimpleMVC.App.Views.User
{
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using SimpleMVC.App.ViewModels;
    using System.IO;
    using System.Text;

    public class Profile : IRenderable<UserPrifileViewModel>
    {
        public UserPrifileViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            
            foreach (var note in Model.Notes)
            {
                sb.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }
            return string.Format(File.ReadAllText("../../HTMLs/add-note.html"), Model.Username, $"value=\"{Model.Id}\"", sb.ToString());
        }
    }
}
