using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Models
{
    public class BoughtKnives
    {
        public int Id { get; set; }

        public Knife Knife { get; set; }

        public string BuyersName { get; set; }

        public string PhoneNumber { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
