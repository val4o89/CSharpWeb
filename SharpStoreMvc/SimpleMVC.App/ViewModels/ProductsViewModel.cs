using SimpleMVC.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.ViewModels
{
    public class ProductsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }
    }
}
