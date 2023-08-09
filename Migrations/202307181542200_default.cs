namespace Todo_Asp_Mvc.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _default : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.adresses", "CreatedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.adresses", "UpdatedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.persons", "DateNaissance", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.persons", "CreatedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.persons", "UpdatedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.todos", "CreatedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.todos", "UpdatedAt", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.todos", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.todos", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.persons", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.persons", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.persons", "DateNaissance", c => c.DateTime(nullable: false));
            AlterColumn("dbo.adresses", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.adresses", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
