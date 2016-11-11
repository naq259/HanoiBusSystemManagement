using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HanoiBusSystemManagement.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Mời nhập tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage= "Mời nhập mật khẩu")]
        public string Password { get; set; }
        public int DeptID { get; set; }
    }
}