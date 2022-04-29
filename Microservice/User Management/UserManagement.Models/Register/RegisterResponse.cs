using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.Register
{
    public class RegisterResponse
    {
        public Users users { get; set; }
        public string message { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Projectid { get; set; }
        public string Contactno { get; set; }
        public string Address { get; set; }
    }
}
