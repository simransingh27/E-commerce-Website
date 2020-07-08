using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class MostViewedProduct
    {
        [Key]        
        public int MostViewedId { get; set; }
        [Display(Name = "Product")]       
        public int ProductId { get; set; }
        [Display(Name = "Frequency")]         
        public int Frequency { get; set; }
    }
}
