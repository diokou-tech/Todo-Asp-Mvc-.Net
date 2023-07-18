using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo_Asp_Mvc.Net.Models
{
    public class TimeStampCustom
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}