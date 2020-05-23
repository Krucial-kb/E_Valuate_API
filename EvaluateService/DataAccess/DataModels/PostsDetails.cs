using System;
using System.Collections.Generic;

namespace E_ValuateAPI.DataModels
{
    public partial class PostsDetails
    {
        public int DetailsId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PostDate { get; set; }

        public virtual PostsData Post { get; set; }
        public virtual Users User { get; set; }
    }
}
