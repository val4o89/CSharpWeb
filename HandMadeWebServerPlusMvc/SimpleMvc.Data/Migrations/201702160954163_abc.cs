namespace SimpleMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Owner_iD = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_iD)
                .Index(t => t.Owner_iD);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        iD = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.iD);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Owner_iD", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "Owner_iD" });
            DropTable("dbo.Users");
            DropTable("dbo.Notes");
        }
    }
}
