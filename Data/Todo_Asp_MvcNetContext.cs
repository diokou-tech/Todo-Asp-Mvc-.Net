using System;
using System.Data.Entity;
using Todo_Asp_Mvc.Net.Models;

namespace Todo_Asp_Mvc.Net.Data
{
    public class Todo_Asp_MvcNetContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Todo_Asp_MvcNetContext() : base("name=Todo_Asp_MvcNetContext")
        {
        }   

        public DbSet<Todo> Todoes { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
