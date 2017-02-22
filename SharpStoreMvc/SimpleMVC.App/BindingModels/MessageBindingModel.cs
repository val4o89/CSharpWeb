using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.BindingModels
{
    public class MessageBindingModel
    {
        public string Email { get; set; }

        public string Subject { get; set; }

        public string MessageText { get; set; }
    }
}
