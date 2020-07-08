using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Areas.Identity.Pages.Account.Manage
{
    public class AddressDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;

        public AddressDataModel(
            UserManager<ApplicationUser> userManager,
            ILogger<PersonalDataModel> logger,
            IHostingEnvironment env,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _env = env;
            _context = context;
        }
        [BindProperty]
        public Address _address { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ImagePath { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Address address = _context.Addresses.Where(add => add.UserId == user.Id).FirstOrDefault();

            _address = address;

            return Page();
        }

        
       


    }
}