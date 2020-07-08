using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class AddressModelView
    {
        public int AddressId { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }     
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
         
        public double Longitute { get; set; }
        public double Latitue { get; set; }
        
        
    }
}
