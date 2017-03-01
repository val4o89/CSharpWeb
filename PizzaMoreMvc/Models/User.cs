namespace Models
{
    using System.Collections.Generic;

    public partial class User
    {
        public User()
        {
            this.Pizzas = new HashSet<Pizza>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public ICollection<Pizza> Pizzas { get; private set; }
    }
}
