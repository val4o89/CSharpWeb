namespace Store.Data
{
    using ViewModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext()
            : base("GameStoreDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }
}