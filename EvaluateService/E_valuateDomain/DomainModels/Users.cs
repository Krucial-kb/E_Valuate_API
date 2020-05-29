using System;
using System.Collections.Generic;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class Users
    {
        public int UserID { get; set; }
        public string fullName { get; set; }
        public byte[] ProfPicID { get; set; }
        public string userName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Platform { get; set; }
        public Address AddressNavigation { get; set; }
        public List<FriendsDetails> ListFriendsDetails { get; set; }
        public List<FriendData> listFriendsData { get; set; } = new List<FriendData>();
        public List<PostsDetails> listPosDetails { get; set; } = new List<PostsDetails>();
    }
}
