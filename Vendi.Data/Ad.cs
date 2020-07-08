using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Ad
    {
        [Key]
        public int AdsId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name is required")]
        public string AdsName { get; set; }
        [Display(Name = "Ads")]
        [Required(ErrorMessage = "The Ads is required")]
        public string AdsContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Display(Name = "User")]    
        public string UserId { get; set; }
        
    }
}
