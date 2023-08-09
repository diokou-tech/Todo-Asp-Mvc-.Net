namespace Todo_Asp_Mvc.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_properties_tables_constraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.persons", "Prenom", c => c.String(nullable: false));
            AlterColumn("dbo.persons", "Nom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.persons", "Nom", c => c.String());
            AlterColumn("dbo.persons", "Prenom", c => c.String());
        }
    }
}
