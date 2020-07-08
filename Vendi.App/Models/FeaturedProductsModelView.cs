﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class FeaturedProductsModelView
    {
        [Key]
        public int FeatureId { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "The Product is required")]
        public int ProductId { get; set; }
        public string UserId { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "The From is required")]
        public DateTime FeaturedFrom { get; set; }
        [Display(Name = "To")]
        [Required(ErrorMessage = "The To is required")]
        public DateTime FeaturedTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string ProductName { get; set; }
    }
}
