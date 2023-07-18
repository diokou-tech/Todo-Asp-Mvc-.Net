namespace Todo_Asp_Mvc.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class persons_adresses_timestamps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rue = c.Int(nullable: false),
                        Angle = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(),
                        Nom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        AdresseId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.adresses", t => t.AdresseId, cascadeDelete: true)
                .Index(t => t.AdresseId);
            
            AddColumn("dbo.todos", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.todos", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.persons", "AdresseId", "dbo.adresses");
            DropIndex("dbo.persons", new[] { "AdresseId" });
            DropColumn("dbo.todos", "UpdatedAt");
            DropColumn("dbo.todos", "CreatedAt");
            DropTable("dbo.persons");
            DropTable("dbo.adresses");
        }
    }
}
