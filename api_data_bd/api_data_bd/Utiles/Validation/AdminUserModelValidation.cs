using api_data_bd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace api_data_bd.Utiles.Validation
{
    public class AdminUserModelValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new ApplicationDbContext();

            if(value != null)
            {
                System.Diagnostics.Debug.WriteLine(validationContext.ToString());
                var className = validationContext.ObjectType.Name.Split('.').Last();
                var propertyName = validationContext.MemberName;
                var parameterName = string.Format("@{0}", propertyName);

                var result = db.Database.SqlQuery<int>(
                    string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2}", className, propertyName, parameterName),
                    new System.Data.SqlClient.SqlParameter(parameterName, value));
                if (result.ToList()[0] > 0)
                {
                    return new ValidationResult(string.Format("The '{0}' already exist", propertyName),
                                new List<string>() { propertyName });
                }
            }

            return null;
        }
       
    }

    
}