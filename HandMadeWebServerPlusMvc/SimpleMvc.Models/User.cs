using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.Models
{
    public class User
    {
        private ICollection<Note> notes;
        public User()
        {
            this.notes = new HashSet<Note>();
        }
        public int iD { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Note> Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }
    }
}
