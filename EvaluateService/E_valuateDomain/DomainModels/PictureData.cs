using System;
using System.Collections.Generic;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class PictureData
    {
        public int PictureID { get; set; }
        public string imageName { get; set; }
        public byte[] imageSource { get; set; }
        public DateTime? imageDate { get; set; }
    }
}
