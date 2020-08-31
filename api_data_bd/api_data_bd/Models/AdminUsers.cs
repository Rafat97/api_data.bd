using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using api_data_bd.Utiles.Validation;

namespace api_data_bd.Models
{
    public class AdminUsers
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Unique { get; set; }

        [Key]
        public int AdminUsersId { get; set; }

        [Required]
        public string AdminUsersName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [Index(IsUnique = true)]
        [Remote("IsUserExists", "Validation", ErrorMessage= "Email already in use")]  
        [EmailUnique]
        public string AdminUsersEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string AdminUsersPassword { get; set; }


    }

    //fluentvalidation
    public class PlaceValidator : AbstractValidator<AdminUsers>
    {
        public PlaceValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Place Name is required").Length(0, 100);
            //RuleFor(x => x.Url).Must(BeUniqueUrl).WithMessage("Url already exists");
        }

        private bool BeUniqueUrl(string url)
        {
            //return new DataContext().Places.FirstOrDefault(x => x.Url == url) == null
            return false;
        }
    }
}