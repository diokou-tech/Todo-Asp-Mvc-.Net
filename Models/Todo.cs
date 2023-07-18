using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo_Asp_Mvc.Net.Models
{
    [Table("todos")]
    public class Todo : CommonModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DateExecution { get; set; }
    }
}