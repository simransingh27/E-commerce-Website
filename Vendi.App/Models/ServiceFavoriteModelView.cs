using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class ServiceFavoriteModelView
    {
        public int ServiceFavoriteId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
