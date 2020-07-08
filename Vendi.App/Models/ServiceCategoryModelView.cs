using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class ServiceCategoryModelView
    {
        public bool IsImageUpdate { get; set; }
        public int ServiceCategoryId { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "The Category is required")]
        public string CategoryName { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
