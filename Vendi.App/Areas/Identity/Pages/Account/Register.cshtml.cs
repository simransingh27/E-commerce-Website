using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Vendi.App.Models;

namespace Vendi.App.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _RoleManager = roleManager;
           
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        

        public class InputModel
        {
            [Required]             
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]           
            [Display(Name = "Last Name")]
            public string LastName { get; set; }               
            [Display(Name = "Gender")]
            public int Gender { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date Of Birth")]
            public DateTime DOB { get; set; }
            public string Image { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var DefaultImageMale = "/Image/Vendi/Vendi_male_avatar.png";
            var DefaultImageFemale = "/Image/Vendi/Vendi_female_avatar.png";
            var DefaultImageNA = "/Image/Vendi/Vendi_NA_avatar.png";
            if (Input.Gender == 1)
            {
                Input.Image = DefaultImageMale;
            }
            if (Input.Gender == 2)
            {
                Input.Image = DefaultImageFemale;
            }
            if (Input.Gender == 3)
            {
                Input.Image = DefaultImageNA;
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {FirstName=Input.FirstName,
                                                LastName =Input.LastName,
                    Gender =Convert.ToInt32(Input.Gender),
                    DOB =Convert.ToDateTime(Input.DOB),
                    UserName = Input.Email,
                    Email = Input.Email,
                    Image=Input.Image};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);
                    //Temp Code//
                    if (!await _RoleManager.RoleExistsAsync("Admin"))
                    {
                        var _Admin = new IdentityRole("Admin");
                        await _RoleManager.CreateAsync(_Admin);
                    }
                    if (!await _RoleManager.RoleExistsAsync("User"))
                    {
                        var _User = new IdentityRole("User");
                        await _RoleManager.CreateAsync(_User);
                    }
                    if (!await _RoleManager.RoleExistsAsync("Vendor"))
                    {
                        var _Vendor = new IdentityRole("Vendor");
                        await _RoleManager.CreateAsync(_Vendor);
                    }
                    //Temp End
                    await _userManager.AddToRoleAsync(user, "User");//Alaeddin User  will be on User Role after regester
                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);


                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
