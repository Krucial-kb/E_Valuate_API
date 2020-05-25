using System;
using System.Collections.Generic;
using System.Text;

namespace E_valuateDomain.DomainModels
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
