using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Display(Name = "PostCode")]
        [Required(ErrorMessage = "The PostCode is required")]
        public string PostCode { get; set; }
        [Display(Name = "House Number")]
        [Required(ErrorMessage = "The House Number is required")]
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string UserId { get; set; }
        public double Longitute { get; set; }
        public double Latitue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
