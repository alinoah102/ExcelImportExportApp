using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class RegistrationViewModel {

        [Required]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "User Name Length Must Between 6 and 14 Characters")]
        public string UserName { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "Password Length Must Between 8 and 14 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Sorry, both Passwords Must Match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Sorry, Invalid Email Pattern")]
        public string EmailAddress { get; set; }

        [Required]
        [Compare("EmailAddress", ErrorMessage = "Sorry, both Emails Must Match")]
        public string ConfirmEmailAddress { get; set; }

    }
}
