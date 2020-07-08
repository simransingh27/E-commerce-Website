using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "The Product is required")]
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
