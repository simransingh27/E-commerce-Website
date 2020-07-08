using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class ServiceCheckOutModelView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Mobile { get; set; }
        public string Comment { get; set; }
        public double TotalOrder { get; set; }
        public string ServiceOrderId { get; set; }
        public string Token { get; set; }
        public bool Reusable { get; set; }
        public WorldPayPaymentMethod PaymentMethod { get; set; }

    }
        

        
     
}
