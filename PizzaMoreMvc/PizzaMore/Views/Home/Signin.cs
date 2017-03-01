using SimpleMVC.Interfaces;
using System.IO;

namespace PizzaMore.Views.Home
{
    public class Signin : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signin.html");
        }
    }
}
