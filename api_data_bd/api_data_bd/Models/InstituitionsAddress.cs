using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_data_bd.Models
{
    public class InstituitionsAddress
    {
        [Key]
        [Display(Name = "Instituition Address Id")]
        public int InstituitionAddressId { get; set; }

        [Required]
        [Display(Name = "Instituition Address Union")]
        public string InstituitionAddressUnion { get; set; }

        [Required]
        [Display(Name = "Instituition Address Thana")]
        public string InstituitionAddressThana { get; set; }

        [Required]
        [Display(Name = "Instituition Address Division")]
        public string InstituitionAddressDivision { get; set; }

        [Required]
        [Display(Name = "Instituition Address District")]
        public string InstituitionAddressDistrict { get; set; }



    }
}