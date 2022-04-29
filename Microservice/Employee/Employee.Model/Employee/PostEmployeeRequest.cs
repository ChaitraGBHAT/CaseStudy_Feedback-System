using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Model.Employee
{
    public class PostEmployeeRequest
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Projectid { get; set; }
        public string Contactno { get; set; }
        public string Address { get; set; }
    }
}
