using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.UpdatePassword
{
    public class UpdatePassword
    {
        public string email { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }
}
