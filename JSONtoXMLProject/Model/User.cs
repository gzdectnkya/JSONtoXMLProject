using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONtoXMLProject.Model
{
    public class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }

        public List<Address> Address { get; set; }
    }
}
