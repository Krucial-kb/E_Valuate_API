using System;
using System.Collections.Generic;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class Users
    {
        public int UserID { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Platform { get; set; }


        public List<Friends> Friends { get; set; } = new List<Friends>();
        public List<Posts> Posts { get; set; } = new List<Posts>();
    }
}
