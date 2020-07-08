using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendi.Data;

namespace Vendi.App.Models
{
    public class CPModelView
    {
        public int NumberOfUsers { get; set; }
        public int NumberOfOrders { get; set; }
        public  int NumberOfProducts { get; set; }
        public int NumberOfServices { get; set; }
        public int NumberOfPendingServiceOffersForUser { get; set; }
        public int NumberOfPendingServices { get; set; }
        public int NumberOfPendingProducts { get; set; }
        public IQueryable<Order> Last10Orders { get; set; }
        public IQueryable<Service> Top10Services { get; set; }
    }
}
