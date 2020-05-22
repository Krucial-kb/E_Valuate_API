using System;
using System.Collections.Generic;

namespace E_ValuateAPI.Entities
{
    public partial class Posts
    {
        public Posts()
        {
            Friends = new HashSet<Friends>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public byte[] Media { get; set; }
        public string Comment { get; set; }
        public double? Rating { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Friends> Friends { get; set; }
    }
}
