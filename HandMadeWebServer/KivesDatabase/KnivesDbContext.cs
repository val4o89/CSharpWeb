namespace KivesDatabase
{
    using Knives.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KnivesDbContext : DbContext
    {

        public KnivesDbContext()
            : base("KnivesDbContext")
        {
        }

        public virtual DbSet<Knive> Knives { get; set; }

        public virtual DbSet<Message> Messages { get; set; }


    }
}