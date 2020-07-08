using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class ServiceOrder
    {
        [Key]
        public string ServiceOrderId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string VendorId { get; set; }

        [Required]
        public string TimeTaken { get; set; }
        public string Description { get; set; }

        [Required]
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int PaymentMethod { get; set; }
    }
}
