using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.MVVM.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        public string UserName { get ; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }    
    }
}
