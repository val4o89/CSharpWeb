using SimpleMVC.App.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.ViewModels
{
    public class AllNeededUserDataViewModel
    {
        public AllNeededUserDataViewModel()
        {
            this.Users = new List<UserBindingModel>();
        }
        public ICollection<UserBindingModel> Users { get; set; }
    }
}
