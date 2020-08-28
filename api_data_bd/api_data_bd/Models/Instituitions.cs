using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api_data_bd.Models
{
    public class Instituitions
    {
        [Key]
        public int InstituitionId { get; set; }

        [Required]
        public string InstituitionName { get; set; }

        [Required]
        public string InstituitionEstablishment { get; set; }

        [Required]
        public string InstituitionType { get; set; }

        [Required]
        public int InstituitionEiin { get; set; }

        public string InstituitionPhoneNumber { get; set; }

        [Required]
        public string InstituitionManagementType { get; set; }


        [Required]
        public string InstituitionEducationLevel { get; set; }


        public virtual InstituitionsAddress InstituitionAddress { get; set; }
        public int InstituitionAddressId { get; set; }


        public Instituitions()
        {
            InstituitionPhoneNumber = null;
        }

    }
}