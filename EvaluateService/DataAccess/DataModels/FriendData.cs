using System;
using System.Collections.Generic;

namespace E_ValuateAPI.DataModels
{
    public partial class FriendData
    {
        public FriendData()
        {
            FriendsDetails = new HashSet<FriendsDetails>();
        }

        public int FriendId { get; set; }
        public int FriendInfo { get; set; }

        public virtual Users FriendInfoNavigation { get; set; }
        public virtual ICollection<FriendsDetails> FriendsDetails { get; set; }
    }
}
