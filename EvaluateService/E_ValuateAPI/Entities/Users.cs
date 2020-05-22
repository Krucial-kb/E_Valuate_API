using System;
using System.Collections.Generic;

namespace E_ValuateAPI.Entities
{
    public partial class Users
    {
        public Users()
        {
            FriendsNavigation = new HashSet<Friends>();
            PostsNavigation = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public int? Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Platform { get; set; }
        public int? Friends { get; set; }
        public int? Posts { get; set; }

        public virtual ICollection<Friends> FriendsNavigation { get; set; }
        public virtual ICollection<Posts> PostsNavigation { get; set; }
    }
}
