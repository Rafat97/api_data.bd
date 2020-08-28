using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace api_data_bd.Models
{
    public class InstituteStatistics
    {


        [Key]
        public int InstituteStatisticsId { get; set; }

        [Required]
        public string InstituteStatisticsMaleTeacher { get; set; }


        [Required]
        public string InstituteStatisticsFemaleTeacher { get; set; }


        [Required]
        public string InstituteStatisticsYear { get; set; }

        
        public string InstituteStatisticsBoysStudent { get; set; }


        
        public string InstituteStatisticsGirlsStudent { get; set; }


        public virtual ICollection<Instituitions> Instituition { get; set; }


        public InstituteStatistics()
        {
            InstituteStatisticsBoysStudent = null;
            InstituteStatisticsGirlsStudent = null;
        }

    }
}