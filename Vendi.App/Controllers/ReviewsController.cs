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
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.RevieweId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RevieweId,UserId,Rating,ProductId,Description,CreateDate,UpdateTime")] Review review)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Review _review = new Review();
            if (ModelState.IsValid)
            {
                _review.ProductId = review.ProductId;
                _review.Rating = review.Rating;
                _review.UserId = currentUserId;
                _review.Description = review.Description;
                _review.CreateDate = DateTime.Now;
                _review.UpdateTime = DateTime.Now;

                _context.Add(_review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RevieweId,UserId,Rating,ProductId,Description,CreateDate,UpdateTime")] Review review)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (id != review.RevieweId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _review = await _context.Reviews.FindAsync(id);
                    _review.ProductId = review.ProductId;
                    _review.Rating = review.Rating;
                    _review.UserId = currentUserId;
                    _review.Description = review.Description;
                    _review.CreateDate = review.CreateDate;
                    _review.UpdateTime = DateTime.Now;


                    _context.Update(_review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.RevieweId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.RevieweId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.RevieweId == id);
        }




        [HttpPost("SubmitReview")]
        public async Task<IActionResult> SubmitReview([FromBody] Review review)
        {
            POJOMsgs model = new POJOMsgs();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Review _review = new Review();             
                try { 
                _review.Rating = review.Rating;
                _review.UserId = currentUserId;
                _review.Description = review.Description;
                _review.ProductId = review.ProductId;
                _review.CreateDate = DateTime.Now;
                _review.UpdateTime = DateTime.Now;           
                await   _context.AddAsync(_review);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Have Been Added";
                //Calc it with the last rate value avg.(Future Method)
                IQueryable<Review> OldValueRating = _context.Reviews.Where(r => r.ProductId == review.ProductId);
                double TotalRating = await OldValueRating.AverageAsync(m => m.Rating);
                Product _Product = await _context.Products.FindAsync(review.ProductId);
                _Product.ProductRating = TotalRating;
                _context.Products.Update(_Product);
                await _context.SaveChangesAsync();
                //Calc it with the last rate value avg.

            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }    
            return Json(model);
        }


        [HttpGet("ProductReviews/{id}")]
        public  IActionResult ProductReviews([FromBody] int id)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                IEnumerable<Review> _reviews =  _context.Reviews.Where(i => i.ProductId == id);
                return Json(_reviews);
            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }
        [HttpGet("CheckCustomerReview/{id}")]
        public IActionResult CheckCustomerReview( int id)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            POJOMsgs model = new POJOMsgs();

            Review _reviews = _context.Reviews.FirstOrDefault(m => m.ProductId == id && m.UserId == currentUserId);
            if (_reviews != null)
            {
                model.Flag = true;
                model.Msg = "You have already reviewed this product.";
                return Json(model);
            }
            else
            {
                model.Flag = false;
                model.Msg = "You dont have reviewe for this product.";

                return Json(model);
            }

        }

        
    }
}
