using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.BindingModels
{
    public class PizzaBindingModel
    {
        public string Title { get; set; }

        public string Reciepe { get; set; }

        public int OwnerId { get; set; }

        public string ImageUrl { get; set; }
    }
}
