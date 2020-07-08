using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class CheckOutModelView
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
        public string OrderId { get; set; }
        public string Token { get; set; }
        public bool Reusable { get; set; }
        public WorldPayPaymentMethod PaymentMethod { get; set; }


    }


    public class WorldPayPaymentMethod
    {
        public string CardClass { get; set; }
        public string CardIssuer { get; set; }
        public string CardProductTypeDescContactless { get; set; }
        public string CardProductTypeDescNonContactless { get; set; }
        public string CardSchemeName { get; set; }
        public string CardSchemeType { get; set; }
        public string CardType { get; set; }
        public string CountryCode { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string MaskedCardNumber { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }


    }

}
