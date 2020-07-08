using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class ServiceCategory
    {
        [Key]
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
