using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Display(Name = "User")]
      
        public string UserId { get; set; }
        [Display(Name = "Status")]
 
        public bool Status { get; set; }
        public double Total { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
