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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Controllers
{
    [Authorize]
    public class ServiceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;
       
        public ServiceCategoriesController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager, IHostingEnvironment env)
        {
            _context = context;
            _userManager = _UserManager;
            _env = env;
        }

        // GET: ServiceCategories for users(services)
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceCategories.ToListAsync());
        }

        //just admin
        public async Task<IActionResult> IndexAdmin()
        {
            return View(await _context.ServiceCategories.ToListAsync());
        }


        // GET: ServiceCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCategory = await _context.ServiceCategories
                .FirstOrDefaultAsync(m => m.ServiceCategoryId == id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            return View(serviceCategory);
        }

        // GET: ServiceCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceCategoryId,CategoryName,UserId,ImagePath,CreateDate,UpdateTime")] ServiceCategory serviceCategory)
        {

            ServiceCategory _ServiceCategory = new ServiceCategory();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (ModelState.IsValid)
            {
                _ServiceCategory.CategoryName = serviceCategory.CategoryName;
                _ServiceCategory.UserId = currentUserId;
                _ServiceCategory.CreateDate = DateTime.Now;
                _ServiceCategory.UpdateTime = DateTime.Now;
              await   _context.AddAsync(_ServiceCategory);
                await _context.SaveChangesAsync();
                int Id = _ServiceCategory.ServiceCategoryId;
                //Direct to Image Upload

                return RedirectToAction("UploadImageServiceCategory", "ServiceCategories", new { id = Id });
            }
            return View(serviceCategory);
        }

        // GET: ServiceCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //error message 
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var serviceCategory = await _context.ServiceCategories.FindAsync(id);
            if (serviceCategory == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ServiceCategoryModelView _ServiceCategoryModelView = new ServiceCategoryModelView();
            _ServiceCategoryModelView.ServiceCategoryId = serviceCategory.ServiceCategoryId;
            _ServiceCategoryModelView.CategoryName = serviceCategory.CategoryName;
            _ServiceCategoryModelView.ImagePath = serviceCategory.ImagePath;
            return View(_ServiceCategoryModelView);
        }

        // POST: ServiceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceCategoryId,CategoryName,UserId,ImagePath,CreateDate,UpdateTime,IsImageUpdate")] ServiceCategoryModelView serviceCategory)
        {
            ServiceCategory _ServiceCategory = new ServiceCategory();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            if (id != serviceCategory.ServiceCategoryId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ServiceCategory __ServiceCategory = await _context.ServiceCategories.FindAsync(id);
                    __ServiceCategory.CategoryName = serviceCategory.CategoryName;
                    __ServiceCategory.UserId = currentUserId;
                    __ServiceCategory.CreateDate = serviceCategory.CreateDate;
                    __ServiceCategory.UpdateTime = DateTime.Now;
                    _context.ServiceCategories.Update(__ServiceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceCategoryExists(serviceCategory.ServiceCategoryId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    

                }

                int Id = serviceCategory.ServiceCategoryId;
                if (serviceCategory.IsImageUpdate)
                {
                    return RedirectToAction("UploadImageServiceCategory", "ServiceCategories", new { id = Id });
                }
                return RedirectToAction("Details", "ServiceCategories", new { id = Id });
            }
            return View(serviceCategory);
        }

        // GET: ServiceCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCategory = await _context.ServiceCategories
                .FirstOrDefaultAsync(m => m.ServiceCategoryId == id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            return View(serviceCategory);
        }

        // POST: ServiceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceCategory = await _context.ServiceCategories.FindAsync(id);
            _context.ServiceCategories.Remove(serviceCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAdmin));
        }

        private bool ServiceCategoryExists(int id)
        {
            return _context.ServiceCategories.Any(e => e.ServiceCategoryId == id);
        }
        public IActionResult UploadImageServiceCategory(int Id)
        {
            ServiceCategory model = new ServiceCategory();
            model.ServiceCategoryId = Id;
            return View(model);
        }
       

        [HttpPost]
        public async Task<IActionResult> UploadImageServiceCategory(IFormCollection form, ServiceCategory _ServiceCategoy)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            var webRoot = _env.WebRootPath;
            string storePath = webRoot + "/Image/";
            if (form.Files == null || form.Files[0].Length == 0)
                return RedirectToAction("Index");

            var filename = form.Files[0].FileName;
            var name = form.Files[0].Name;
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), storePath,
                        form.Files[0].FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await form.Files[0].CopyToAsync(stream);
            }

            ServiceCategory model = await _context.ServiceCategories.FindAsync(_ServiceCategoy.ServiceCategoryId);
            model.ImagePath = "/Image/" + filename;
            _context.ServiceCategories.Update(model);
            await _context.SaveChangesAsync();
            return Json(filename);

        }

        [HttpGet("DeleteSericesCategory/{id}")]
        public async Task<IActionResult> DeleteSericesCategory(int id)
        {
            POJOMsgs model = new POJOMsgs();
            Category category = new Category();

            try
            {
                ServiceCategory _ServiceCategory = _context.ServiceCategories.FirstOrDefault(m => m.ServiceCategoryId == id);
                _context.ServiceCategories.Remove(_ServiceCategory);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Has Been Deleted it";
            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }


    }
}
