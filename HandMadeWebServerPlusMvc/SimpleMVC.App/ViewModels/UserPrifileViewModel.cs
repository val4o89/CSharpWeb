using System.Collections.Generic;

namespace SimpleMVC.App.ViewModels
{
    public class UserPrifileViewModel
    {
        public UserPrifileViewModel()
        {
            this.Notes = new List<NoteViewModel>();
        }
        public string Username { get; set; }

        public int Id { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}
