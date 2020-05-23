using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class Posts
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public byte[] Media { get; set; }
        public string Comment { get; set; }

        public Users Users { get; set; }
    }
}
