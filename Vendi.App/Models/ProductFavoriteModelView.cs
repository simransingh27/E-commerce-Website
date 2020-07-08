using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class ProductFavoriteModelView
    {
        public int FavoriteId { get; set; }
        public  string Product { get; set; }
        public int ProductId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
