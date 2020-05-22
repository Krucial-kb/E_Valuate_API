using System;
using System.Collections.Generic;

namespace E_ValuateAPI.Entities
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public byte[] Media { get; set; }
        public string Comment { get; set; }
        public double? Rating { get; set; }
    }
}
