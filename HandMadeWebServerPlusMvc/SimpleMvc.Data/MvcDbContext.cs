namespace SimpleMvc.Data
{
    using SimpleMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MvcDbContext : DbContext
    {
        public MvcDbContext()
            : base("MvcDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }
    }
}