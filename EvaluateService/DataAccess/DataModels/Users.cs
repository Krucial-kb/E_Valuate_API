using System;
using System.Collections.Generic;

namespace E_ValuateDataAccess.DataModels
{
    public partial class Users
    {
        public Users()
        {
            FriendData = new HashSet<FriendData>();
            FriendsDetails = new HashSet<FriendsDetails>();
            PostsDetails = new HashSet<PostsDetails>();
        }

        public int UserId { get; set; }
        public int? ProfilePicture { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int? Address { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Platform { get; set; }

        public virtual Address AddressNavigation { get; set; }
        public virtual PictureData ProfilePictureNavigation { get; set; }
        public virtual ICollection<FriendData> FriendData { get; set; }
        public virtual ICollection<FriendsDetails> FriendsDetails { get; set; }
        public virtual ICollection<PostsDetails> PostsDetails { get; set; }
    }
}
