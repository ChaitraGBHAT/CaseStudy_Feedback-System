using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.Models.Login
{
    public class Login
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
    public class UserDetails
    {
        public bool result { get; set; }
        public string message { get; set; }
      
    }
}
