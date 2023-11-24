using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.MVVM.Model.ResponseModel
{
    public class LoginResponseModel
    {

        public bool? IsSuccess { get; set; }

        public string? Token { get; set; }

        public string? Role { get; set; }

        public string? UserName { get; set; }

        public string? UserId { get; set; }
    }
}
