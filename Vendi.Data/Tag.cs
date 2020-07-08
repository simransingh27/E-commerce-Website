using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Display(Name = "Tag")]
        [Required(ErrorMessage = "The Tag is required")]
        public string TagName { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
