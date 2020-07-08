using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class FavoritesModelView
    {
        public IQueryable<ProductFavoriteModelView> FavoriteProduct { get; set; }
        public IQueryable<ServiceFavoriteModelView> FavoriteService { get; set; }

    }
}
