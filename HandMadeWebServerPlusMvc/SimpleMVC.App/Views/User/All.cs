﻿namespace SimpleMVC.App.Views.User
{
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using SimpleMVC.App.ViewModels;
    using System.Text;

    public class All : IRenderable<AllNeededUserDataViewModel>
    {
        public AllNeededUserDataViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.Append("<a href=\"/home/index\">&lt;Home</a><br>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");

            foreach (var user in Model.Users)
            {
                sb.AppendLine($"<li><a href=\"/user/profile?id={user.Id}\">{user.Username}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}
