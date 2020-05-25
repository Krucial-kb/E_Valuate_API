using System;
using System.Collections.Generic;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class PostsDetails
    {
        public int DetailsID { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PostDate { get; set; }

    }
}
