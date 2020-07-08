using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        [Display(Name = "Product Type Name")]
        [Required(ErrorMessage = "The Product Type Name is required")]
        public string ProductTypeName { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
