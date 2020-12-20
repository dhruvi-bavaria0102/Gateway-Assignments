using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ValidationExample.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50, ErrorMessage = "Limit exceeded")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "password Not Matched")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]

        [Range(18, 60, ErrorMessage = "Please enter between 18 to 60")]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
    }
}