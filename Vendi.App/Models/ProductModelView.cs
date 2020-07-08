using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vendi.Data;

namespace Vendi.App.Models
{
    public class ProductModelView
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Display(Name = "Product Type Name")]
        public string ProductTypeName { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Condition")]
        public int Condition { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "BarCode")]
        public int BarCode { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }
        [Display(Name = "Rating")]
        public double ProductRating { get; set; }

        public string Image { get; set; }
        public IEnumerable<ProductImage> Images { get; set; }
        public IEnumerable<Review> ProductReviews { get; set; }

    }
}
