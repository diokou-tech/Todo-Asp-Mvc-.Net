using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;   

namespace Todo_Asp_Mvc.Net.Models
{
    public class TimeStampCustom
    {
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}