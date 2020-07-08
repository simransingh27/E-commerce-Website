using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class CartsModelView
    {
        public int CartId { get; set; }
        public int CartLineId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
    }
}
