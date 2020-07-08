using System;
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
using Vendi.App.Models;

namespace Vendi.App.Areas.Identity.Pages.Account.Manage
{
    public class ImageUploaderDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly IHostingEnvironment _env;

        public ImageUploaderDataModel(
            UserManager<ApplicationUser> userManager,
            ILogger<PersonalDataModel> logger,
            IHostingEnvironment env)
        {
            _userManager = userManager;
            _logger = logger;
            _env = env;
        }

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

            return Page();
        }

        
       


        public async Task<IActionResult> OnPostAsync(IFormCollection form )
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            string _imgname = Guid.NewGuid().ToString();
            var webRoot = _env.WebRootPath;
            string storePath = webRoot + "/Image/";
            if (form.Files == null || form.Files[0].Length == 0)
                return RedirectToAction("Index");

            var filename = _imgname + form.Files[0].FileName;
            var name = form.Files[0].Name;
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), storePath,
                        filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await form.Files[0].CopyToAsync(stream);
            }
           
          user.Image = "/Image/" + filename;

            await _userManager.UpdateAsync(user);

            //  return new FileContentResult(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(filename)), "text/json");
            ImagePath = user.Image;
            StatusMessage = "Image has been Uploaded.";
            return RedirectToPage();
        }


    }
}