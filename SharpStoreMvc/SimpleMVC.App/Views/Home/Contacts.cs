﻿using SimpleMVC.App.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Views.Home
{
    public class Contacts : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/contacts.html");
        }
    }
}
