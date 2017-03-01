using SimpleMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Views.Home
{
    public class Indexde : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home-de.html");
        }
    }
}
