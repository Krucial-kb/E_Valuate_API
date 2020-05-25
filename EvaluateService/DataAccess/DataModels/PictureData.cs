using System;
using System.Collections.Generic;

namespace E_ValuateDataAccess.DataModels
{
    public partial class PictureData
    {
        public PictureData()
        {
            Users = new HashSet<Users>();
        }

        public int PictureId { get; set; }
        public string ImgName { get; set; }
        public byte[] ImgSource { get; set; }
        public DateTime? ImgDate { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
