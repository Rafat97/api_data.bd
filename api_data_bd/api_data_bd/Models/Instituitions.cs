using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace api_data_bd.Models
{
    public class Instituitions
    {
        [Key]
        [Display(Name = "Instituition Id")]
        public int InstituitionId { get; set; }

        [Required]
        [Display(Name = "Instituition Name")]
        public string InstituitionName { get; set; }

        [Required]
        [Display(Name = "Instituition Establishment")]
        public string InstituitionEstablishment { get; set; }

        [Required]
        [Display(Name = "Instituition Type")]
        public string InstituitionType { get; set; }

        [Required]
        [Display(Name = "Instituition EIIN")]
        public int InstituitionEiin { get; set; }

        [Display(Name = "Instituition Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string InstituitionPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Instituition Management Type")]
        public string InstituitionManagementType { get; set; }


        [Required]
        [Display(Name = "Instituition EducationLevel")]
        public string InstituitionEducationLevel { get; set; }

        [Display(Name = "Instituition Address")]
        public int ? InstituitionAddressId { get; set; }
        [Display(Name = "Instituition Address")]
        public virtual InstituitionsAddress InstituitionAddress { get; set; }


        //[JsonIgnore]
        //[XmlIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<BoardResult> BoardResult { get; set; }


        public Instituitions()
        {
            InstituitionPhoneNumber = null;
        }

    }
}