using System;
using System.Collections.Generic;

namespace E_ValuateAPI.DataModels
{
    public partial class PostsData
    {
        public PostsData()
        {
            PostsDetails = new HashSet<PostsDetails>();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public byte[] Media { get; set; }
        public string Comment { get; set; }
        public double? Rating { get; set; }

        public virtual ICollection<PostsDetails> PostsDetails { get; set; }
    }
}
