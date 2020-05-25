using System;
using System.Collections.Generic;

namespace E_ValuateDataAccess.DataModels
{
    public partial class FriendsDetails
    {
        public int DetailsId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual FriendData Friend { get; set; }
        public virtual Users User { get; set; }
    }
}
