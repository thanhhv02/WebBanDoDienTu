using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanDoDienTu.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Phải nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phải nhập Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
