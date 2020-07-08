using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "The Brand is required")]
        public string BrandName { get; set; }
       
        [Display(Name = "Image")]
       
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
