using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
   public class Service
    {
        [Key]
        public int ServiceId { get; set; }       
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name is required")]
        public string ServiceName { get; set; }
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
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public double ServiceRating { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }


        public virtual IEnumerable<ServiceCategory> ServiceCategories { get; set; }
    }
}
