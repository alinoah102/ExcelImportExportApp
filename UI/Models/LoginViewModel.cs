using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UI.Models {
    public class LoginViewModel {
        [Required]
        [Display(Description = "Please Enter User Name Here")]
        public string UserName { get; set; }

        [Required]
        [Display(Description = "Please Enter Password Here")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        
        public string Login { get; set; }
    }
}
