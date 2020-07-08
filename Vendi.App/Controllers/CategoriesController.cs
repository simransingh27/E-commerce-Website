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
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;
        [TempData]
        public string StatusMessage { get; set; }
        public CategoriesController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager, IHostingEnvironment env)
        {
            _context = context;
            _userManager = _UserManager;
            _env = env;
        }

        // GET: Categories for users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        //just admin
        public async Task<IActionResult> IndexAdmin()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,UserId,CreateDate,UpdateTime")] Category category)
        {
            Category _category = new Category();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (ModelState.IsValid)
            {
                _category.CategoryName = category.CategoryName;
                _category.UserId = currentUserId;
                _category.CreateDate = DateTime.Now;
                _category.UpdateTime = DateTime.Now;
                _context.Add(_category);
                await _context.SaveChangesAsync();
                int Id = _category.CategoryId;
                //Diricate to IMage Upload
                return RedirectToAction("UploadImageCategory", "Categories", new { id = Id });
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }
            CategoryModelView _CategoryModelView = new CategoryModelView();
            _CategoryModelView.CategoryId = category.CategoryId;
            _CategoryModelView.CategoryName = category.CategoryName;
            _CategoryModelView.ImagePath = category.ImagePath;


            return View(_CategoryModelView);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,UserId,CreateDate,UpdateTime,IsImageUpdate")] CategoryModelView category)
        {
            Category _category = new Category();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            if (id != category.CategoryId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Category __category = await _context.Categories.FindAsync(id);
                    __category.CategoryName = category.CategoryName;
                    __category.UserId = currentUserId;
                    __category.UpdateTime = DateTime.Now;
                    _context.Categories.Update(__category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                int Id = category.CategoryId;
                if (category.IsImageUpdate)
                {
                    //Diricate to IMage Upload
                    return RedirectToAction("UploadImageCategory", "Categories", new { id = Id });
                }
                return RedirectToAction("Details", "Categories", new { id = Id });
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

        public IActionResult UploadImageCategory(int Id)
        {
            Category model = new Category();
            model.CategoryId = Id;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UploadImageCategory(IFormCollection form, Category _Categoy)
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

            Category model = await _context.Categories.FindAsync(_Categoy.CategoryId);
            model.ImagePath = "/Image/" + filename;
            _context.Categories.Update(model);
            await _context.SaveChangesAsync();
            return Json(filename);
        }

        [HttpGet("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            POJOMsgs model = new POJOMsgs();
            Category category = new Category();

            try
            {
                Category _category = _context.Categories.FirstOrDefault(m => m.CategoryId == id);
                _context.Categories.Remove(_category);
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