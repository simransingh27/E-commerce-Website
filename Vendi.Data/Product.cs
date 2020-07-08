
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }       
        [Display(Name = "Condition")]
        [Required(ErrorMessage = "The Condition is required")]
        public int Condition { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "The Quanitity is required")]
        public int Quantity { get; set; }
        [Display(Name = "Barcode")]        
        public int BarCode { get; set; }        
        public int BrandId { get; set; }
        [Display(Name = "Product Type")]
        [Required(ErrorMessage = "The Data of Birth is required")]
        public int ProductTypeId { get; set; }        
        [Display(Name = "ProductName")]
        [Required(ErrorMessage = "The Name is required")]
        public string ProductName { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "The Price is required")]
        public double Price { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "The Category is required")]
        public int CategoryId { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }
        [Display(Name = "Tag")]
        [Required(ErrorMessage = "The Tag is required")]
        public string Tags { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsStatus { get; set; }
        public string ImageThumbnail { get; set; }
        public double ProductRating { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }


        public virtual IEnumerable<Category> Categories { get; set; }
        public virtual IEnumerable<ProductType> ProductTypes { get; set; }
        public virtual IEnumerable<Brand> Brands { get; set; }

        public virtual  Brand BrandDetails { get; set; }

    }
}
