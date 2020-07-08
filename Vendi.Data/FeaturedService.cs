using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class FeaturedService
    {
        [Key]
        public int FeatureServiceId { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "The Product is required")]
        public int ServiceId { get; set; }
        public string UserId { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "The From is required")]
        public DateTime FeaturedFrom { get; set; }
        [Display(Name = "To")]
        [Required(ErrorMessage = "The To is required")]
        public DateTime FeaturedTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
