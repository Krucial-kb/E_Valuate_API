﻿using System;
using System.Collections.Generic;

namespace E_ValuateAPI.Entities
{
    public partial class Friends
    {
        public int FriendId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}