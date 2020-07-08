using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class FeaturedProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeaturedProductsController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: FeaturedProducts
        public IActionResult Index()
        {
           
            var model = _context.FeaturedProducts;

            var result = from e in model
                         join p in _context.Products on e.ProductId equals p.ProductId
                         select new FeaturedProductsModelView
                         {
                             FeatureId = e.FeatureId,
                             ProductId = e.ProductId,
                           
                             FeaturedFrom = e.FeaturedFrom,
                             FeaturedTo = e.FeaturedTo,
                             CreatedDate = e.CreatedDate,
                             UpdateDate = e.UpdateDate,
                             ProductName = p.ProductName
                         };





            //return View(await _context.FeaturedProducts.ToListAsync());
            return View(result);
        }

        // GET: FeaturedProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }


            var model = _context.FeaturedProducts.Where(n => n.FeatureId ==id);
           
            IQueryable<FeaturedProductsModelView> result = from e in model
                         join p in _context.Products on e.ProductId equals p.ProductId
                         select new FeaturedProductsModelView
                         {
                             FeatureId = e.FeatureId,
                             ProductId = e.ProductId,
                             UserId = e.UserId,
                             FeaturedFrom = e.FeaturedFrom,
                             FeaturedTo = e.FeaturedTo,
                             CreatedDate = e.CreatedDate,
                             UpdateDate = e.UpdateDate,
                             ProductName = p.ProductName
                         };

            var FR_result =await result.FirstOrDefaultAsync();
            return View(FR_result);
        }

        // GET: FeaturedProducts/Create
        public IActionResult Create(int id)
        {
            if(id.Equals(0))
            { 
            return RedirectToAction("Error", "Home");
            }
            
            FeaturedProduct model = new FeaturedProduct();
            model.ProductId = id;
            return View(model);
        }

        // POST: FeaturedProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeatureId,ProductId,UserId,FeaturedFrom,FeaturedTo,CreatedDate,UpdateDate")] FeaturedProduct featuredProduct)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (ModelState.IsValid)
            {
                FeaturedProduct _featuredProduct = new FeaturedProduct();
                _featuredProduct.ProductId = featuredProduct.ProductId;
                _featuredProduct.UserId = currentUserId;
                _featuredProduct.FeaturedFrom = featuredProduct.FeaturedFrom;
                _featuredProduct.FeaturedTo = featuredProduct.FeaturedTo;
                _featuredProduct.CreatedDate = DateTime.Now;
                _featuredProduct.UpdateDate = DateTime.Now;

                _context.Add(_featuredProduct);
                await _context.SaveChangesAsync();

                int Id = featuredProduct.ProductId;
                return RedirectToAction("AddProductImage", "ProductImage", new { id = Id });
            }
            return View(featuredProduct);
        }

        // GET: FeaturedProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var featuredProduct = await _context.FeaturedProducts.FindAsync(id);
            if (featuredProduct == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(featuredProduct);
        }

        // POST: FeaturedProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeatureId,ProductId,UserId,FeaturedFrom,FeaturedTo,CreatedDate,UpdateDate")] FeaturedProduct featuredProduct)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (id != featuredProduct.FeatureId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _featuredProduct = await _context.FeaturedProducts.FindAsync(id);

                    _featuredProduct.ProductId = featuredProduct.ProductId;
                    _featuredProduct.UserId = currentUserId;
                    _featuredProduct.FeaturedFrom = featuredProduct.FeaturedFrom;
                    _featuredProduct.FeaturedTo = featuredProduct.FeaturedTo;
                    _featuredProduct.CreatedDate = featuredProduct.CreatedDate;
                    _featuredProduct.UpdateDate = DateTime.Now;

                    _context.Update(_featuredProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturedProductExists(featuredProduct.FeatureId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(featuredProduct);
        }

        // GET: FeaturedProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var featuredProduct = await _context.FeaturedProducts
                .FirstOrDefaultAsync(m => m.FeatureId == id);
            if (featuredProduct == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(featuredProduct);
        }

        // POST: FeaturedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {


            if (id==null)
            {
                return RedirectToAction("Error", "Home");
            }
            var featuredProduct = await _context.FeaturedProducts.FindAsync(id);
            _context.FeaturedProducts.Remove(featuredProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturedProductExists(int id)
        {
            return _context.FeaturedProducts.Any(e => e.FeatureId == id);
        }

        [HttpGet("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            POJOMsgs model = new POJOMsgs();
            FeaturedProduct _product = new FeaturedProduct();

            try
            {
                FeaturedProduct featuredProduct = _context.FeaturedProducts.FirstOrDefault(m => m.FeatureId == id);
                _context.FeaturedProducts.Remove(featuredProduct);
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
