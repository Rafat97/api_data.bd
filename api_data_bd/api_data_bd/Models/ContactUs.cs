using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_data_bd.Models
{
    public class ContactUs
    {
        [Key]
        [Display(Name = "Contact Us Id")]
        public int ContactUsId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ContactUsName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string ContactUsEmail { get; set; }


        [Required]
        [Display(Name = "Subject")]
        public string ContactUsSubject { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string ContactUsMessage { get; set; }

       
    }
}