using api_data_bd.Utiles.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_data_bd.Models
{
    public class AdminUsersRegisterBindingModel
    {
        [Required]
        [Display(Name = "Admin User Name")]
        public string UsersName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        //[StringLength(100)]
        [Display(Name = "Admin User Email")]
        [EmailUnique("AdminUsers")]
        public string AdminUsersEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Admin User Password")]
        public string AdminUsersPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("AdminUsersPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public AdminUsers getAdminUser()
        {
            AdminUsers adminUsers = new AdminUsers();
            adminUsers.AdminUsersEmail = this.AdminUsersEmail;
            adminUsers.AdminUsersName = this.UsersName;
            adminUsers.AdminUsersPassword = this.AdminUsersPassword;
            return adminUsers;
        }
    }
}