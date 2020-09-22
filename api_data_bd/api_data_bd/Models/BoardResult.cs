using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_data_bd.Models
{
    public class BoardResult
    {
        [Key]
        [Display(Name = "BoardResult Id")]
        public int BoardResultId { get; set; }

        [Required]
        [Display(Name = "BoardResult Year")]
        public string Year { get; set; }

        [Required]
        [Display(Name = "BoardResult ResultType")]
        public string ResultType { get; set; }

        [Required]
        [Display(Name = "BoardResult ExamAttendence")]
        public string ExamAttendence { get; set; }

        [Required]
        [Display(Name = "BoardResult GpaFiveStudentNumber")]
        public string GpaFiveStudentNumber { get; set; }

        [Required]
        [Display(Name = "BoardResult FailStudentNumber")]
        public string FailStudentNumber { get; set; }

        [Display(Name = "BoardResult Instituitions")]
        public int ? InstituitionId { get; set; }
        public virtual Instituitions Instituitions { get; set; }


        //public virtual ICollection<Instituitions> Instituition { get; set; }


        public BoardResult()
        {

        }

    }
}