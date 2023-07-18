namespace Todo_Asp_Mvc.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Todo_Asp_Mvc.Net.Data.Todo_Asp_MvcNetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Todo_Asp_Mvc.Net.Data.Todo_Asp_MvcNetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Adresses.AddOrUpdate(
            //    new Models.Adresse
            //    {
            //        Angle = 30,
            //        Name = "Yeumbeul",
            //        Rue = 12,
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    }
            //    );
            //context.Adresses.AddOrUpdate(
            //    new Models.Adresse
            //    {
            //        Angle = 40,
            //        Name = "Malika",
            //        Rue = 10,
            //        CreatedAt = DateTime.UtcNow.AddMinutes(1),
            //        UpdatedAt = DateTime.UtcNow.AddMinutes(1)
            //    }
            //    );

            // add persons
            for(int i =0; i < 3; i++)
            {
                context.Persons.Add(
                    new Models.Person
                    {
                        Nom = "Cheikhou",
                        Prenom = "Diokou",
                        AdresseId = i == 2 ? 1 : 2 ,
                        DateNaissance = DateTime.Now,
                        CreatedAt = DateTime.UtcNow.AddMinutes(1),
                        UpdatedAt = DateTime.UtcNow.AddMinutes(1)
                    }
                    ); 
            context.Persons.Add(
                new Models.Person
                {
                    Nom = "Dabo",
                    Prenom = "Bassirou Serigne",
                    AdresseId = i == 2 ? 1 : 2  ,
                    DateNaissance = DateTime.Now,
                    CreatedAt = DateTime.UtcNow.AddMinutes(1),
                    UpdatedAt = DateTime.UtcNow.AddMinutes(1)
                }
                );
            }
        }
    }
}
