using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Review
    {
        [Key]
        public int RevieweId { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Rating")]
        public int Rating { get; set; }
        public  int ProductId { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
