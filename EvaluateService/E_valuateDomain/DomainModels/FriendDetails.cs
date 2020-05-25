using System;
using System.Collections.Generic;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class FriendsDetails
    {
        public int DetailsID { get; set; }
        public int UserID { get; set; }
        public int FriendID { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateAdded { get; set; }

    }
}
