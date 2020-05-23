using System;
using System.Collections.Generic;

namespace E_ValuateAPI.DataModels
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<Users>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
