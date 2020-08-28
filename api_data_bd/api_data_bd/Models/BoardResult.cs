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
        public string BoardResultId { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string ResultType { get; set; }

        [Required]
        public string ExamAttendence { get; set; }

        [Required]
        public string GpaFiveStudentNumber { get; set; }

        [Required]
        public string FailStudentNumber { get; set; }

        public virtual ICollection<Instituitions> Instituition { get; set; }


        public BoardResult()
        {

        }

    }
}