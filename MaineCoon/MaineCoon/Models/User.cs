using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    public class User {
        public enum role {
            Student,
            SchoolAdmin,
            Developer,
            WebsiteAdmin
        }
        public enum status {
            Disable,
            Valid,
        }
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "email")]
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Display(Name = "SHA2.HMAC(SALT,SHA2.HMAC(email,pwd))")]
        [DataType(DataType.Password)]
        [Required]
        public byte[] password {
            get; set; 
        }
        [Display(Name ="SALT")]
        public byte[] SALT { get; set; }
        [Display(Name = "Role")]
        [Required]
        public role sysRole { get; set; }
        [Display(Name = "Registed at"), DataType(DataType.DateTime)]
        public DateTime registionTime { get; set; }
        [Display(Name = "Account Status")]
        public status accountStatus { get; set; }
    }
}
