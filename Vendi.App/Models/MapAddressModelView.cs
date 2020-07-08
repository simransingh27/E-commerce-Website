using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class MapAddressModelView
    {
        public double Longitute { get; set; }
        public double Latitue { get; set; }
        public string ImagePath { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public double ServiceRating { get; set; }
        public string CategoryName { get; set; }

    }
}
