using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Controllers
{
    [Authorize]
    public class ProductImageController : Controller
    {
        private IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductImageController(IHostingEnvironment env, UserManager<ApplicationUser> _UserManager, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
            _userManager = _UserManager;

        }
        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult AddProductImage(int id)
        {
            ProductImage model = new ProductImage();
            model.ProductId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDropzoneJsUploadedFiles(IFormCollection form, ProductImage productImage)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
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
            ProductImage model = new ProductImage();
            model.ProductId = productImage.ProductId;
            model.ImagePath = "/Image/" + filename;
            model.UserId = currentUserId;
            model.CreateDate = DateTime.Now;
            model.UpdateTime = DateTime.Now;
          
              await  _context.ProductImage.AddAsync(model);
              await   _context.SaveChangesAsync();

            //Give  ImageThumbnail for Prodcut
            Product _ProductImageThumbnail =await _context.Products.FindAsync(productImage.ProductId);
            _ProductImageThumbnail.ImageThumbnail = "/Image/" + filename;
            await _context.SaveChangesAsync();


            return Json(filename);

        }

         

        public IActionResult LoadProductImage(int id)
        {
           IQueryable<ProductImage> res = _context.ProductImage.Where(i => i.ProductId == id);

            return PartialView("_LoadProductImage", res);
        }

    }
}