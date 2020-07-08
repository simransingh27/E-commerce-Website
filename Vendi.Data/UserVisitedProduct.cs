using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class UserVisitedProduct
    {
        [Key]
        public int UserVisitedProductId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Frequency { get; set; }
        [Required(ErrorMessage = "The Frequency is required")]
 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
