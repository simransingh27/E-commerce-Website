using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class FeaturedServiceModelView
    {
        [Key]
        public int FeatureServiceId { get; set; }
        [Display(Name = "Service")]
        [Required(ErrorMessage = "The Service is required")]
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
        public string ServiceName { get; set; }

    }
}
