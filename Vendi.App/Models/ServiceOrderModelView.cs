using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class ServiceOrderModelView
    {
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string ServiceOrderId { get; set; }
        public int PaymentMethod { get; set; }
    }
}
