using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Data of Birth")]
        [Required(ErrorMessage = "The Data of Birth is required")]
        public DateTime DOB { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The last Name is required")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int Gender { get; set; }


         
        [Display(Name = "Personl Image")]
        public string Image { get; set; }
    }
}
