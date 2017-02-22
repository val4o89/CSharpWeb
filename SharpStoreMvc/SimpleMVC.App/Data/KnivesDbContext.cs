namespace SimpleMVC.App.Data
{
    using System.Data.Entity;
    using Models;

    public partial class KnivesDbContext : DbContext
    {
        public KnivesDbContext()
            : base("KnivesDbContext")
        {
        }

        public virtual DbSet<Knife> Knives { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<BoughtKnives> BoughtKnives { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
