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
        [Display(Name = "InstituteStatistics Id")]
        public int InstituteStatisticsId { get; set; }

        [Required]
        [Display(Name = "InstituteStatistics Male Teacher")]
        public string InstituteStatisticsMaleTeacher { get; set; }


        [Required]
        [Display(Name = "InstituteStatistics FemaleTeacher")]
        public string InstituteStatisticsFemaleTeacher { get; set; }


        [Required]
        [Display(Name = "InstituteStatistics Year")]
        public string InstituteStatisticsYear { get; set; }

        [Display(Name = "InstituteStatistics Boys Student")]
        public string InstituteStatisticsBoysStudent { get; set; }


        [Display(Name = "InstituteStatistics Girls Student")]
        public string InstituteStatisticsGirlsStudent { get; set; }

        [Display(Name = "Instituition")]
        public int ? InstituitionId { get; set; }
        public virtual Instituitions Instituitions { get; set; }


        //public virtual ICollection<Instituitions> Instituition { get; set; }


        public InstituteStatistics()
        {
            InstituteStatisticsBoysStudent = null;
            InstituteStatisticsGirlsStudent = null;
        }

    }
}