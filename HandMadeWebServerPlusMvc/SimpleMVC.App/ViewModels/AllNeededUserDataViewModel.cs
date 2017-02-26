namespace SimpleMVC.App.ViewModels
{
    using SimpleMVC.App.BindingModels;
    using System.Collections.Generic;

    public class AllNeededUserDataViewModel
    {
        public AllNeededUserDataViewModel()
        {
            this.Users = new List<UserBindingModel>();
        }
        public ICollection<UserBindingModel> Users { get; set; }
    }
}
