using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class BusinessAddress
    {
        [Key]
        public int BusinessAddressId { get; set; }     
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string UserId { get; set; }
        public double Longitute { get; set; }
        public double Latitue { get; set; }
        public int ServiceCategoryId { get; set; }
        public int ServiceId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
