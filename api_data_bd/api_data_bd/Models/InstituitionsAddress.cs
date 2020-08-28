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
        public int InstituitionAddressId { get; set; }

        [Required]
        public string InstituitionAddressUnion { get; set; }

        [Required]
        public string InstituitionAddressThana { get; set; }

        [Required]
        public string InstituitionAddressDivision { get; set; }

        [Required]
        public string InstituitionAddressDistrict { get; set; }



    }
}