namespace Todo_Asp_Mvc.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_others_properties_on_tables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.persons", "Prenom", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.persons", "Nom", c => c.String(nullable: false, maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.persons", "Nom", c => c.String());
            AlterColumn("dbo.persons", "Prenom", c => c.String());
        }
    }
}
