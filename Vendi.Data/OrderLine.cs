using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        public string OrderId { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "The Product is required")]
        public int ProductId { get; set; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "The Quantity is required")]
        public int Qty { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "The Price is required")]
        public double price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
