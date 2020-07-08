using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class OrderValueModelView
    {
        public int CartId { get; set; }
        public double Total { get; set; }
         public int PaymentMethod { get; set; }
    }
}
