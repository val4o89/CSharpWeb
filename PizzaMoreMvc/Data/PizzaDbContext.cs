namespace Data
{
    using System.Data.Entity;
    using Models;

    public partial class PizzaDbContext : DbContext
    {
        public PizzaDbContext()
            : base("PizzaDbContext")
        {
        }

        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<LogIn> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
