namespace SimpleMVC.App.Views.Home
{
    using SimpleMVC.App.MVC.Interfaces;
    using System.IO;

    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../HTMLs/index.html");
        }
    }
}
