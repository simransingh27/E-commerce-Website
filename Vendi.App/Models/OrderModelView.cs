using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class OrderModelView
    {
        public string OrderId { get; set; }
        public int OrderLineId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
    }
}
