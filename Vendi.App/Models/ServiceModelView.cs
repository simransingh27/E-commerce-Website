using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vendi.Data;

namespace Vendi.App.Models
{
    public class ServiceModelView
    {
        [Key]
        public int ServiceId { get; set; }
        public bool IsImageUpdate { get; set; }

        [Display(Name = "Name")]
        public string ServiceName { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "IsFeatured")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Rating")]
        public double ServiceRating { get; set; }
        public int CategoryId { get; set; }


        public IEnumerable<ServiceReview> ServiceReviews { get; set; }
        public virtual IEnumerable<ServiceCategory> ServiceCategories { get; set; }

    }
}
