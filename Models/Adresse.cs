using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Todo_Asp_Mvc.Net.Models
{
    [Table("adresses")]
    public class Adresse : CommonModel
    {
        public string Name { get; set; }
        public int Rue { get; set; }
        public int Angle { get; set; }
    }
}