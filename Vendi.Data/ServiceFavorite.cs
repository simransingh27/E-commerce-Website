using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class ServiceFavorite
    {
        [Key]
        public int ServiceFavoriteId { get; set; }
        [Display(Name = "Service")]
        [Required(ErrorMessage = "The Service is required")]
        public int ServiceId { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
