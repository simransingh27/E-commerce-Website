using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
  public class CartLine
    {
        [Key]
        public int CartLineId { get; set; }
        public int CartId { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "The Product is required")]
        public int ProductId { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "The Quantity is required")]
        public int QTY { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "The Price is required")]
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
