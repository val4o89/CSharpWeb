namespace SimpleMVC.App.Views.User
{
    using SimpleMVC.App.MVC.Interfaces;
    using System.IO;

    public class Register : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../HTMLs/register.html");
        }
    }
}
