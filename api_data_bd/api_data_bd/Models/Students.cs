using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_data_bd.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
    }
}