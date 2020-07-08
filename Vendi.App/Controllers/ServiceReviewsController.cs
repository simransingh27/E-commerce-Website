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
    public class ServiceReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: ServiceReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceReviews.ToListAsync());
        }

        // GET: ServiceReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceReview = await _context.ServiceReviews
                .FirstOrDefaultAsync(m => m.ServiceReviewId == id);
            if (serviceReview == null)
            {
                return NotFound();
            }

            return View(serviceReview);
        }

        // GET: ServiceReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceReviewId,UserId,Rating,ServiceId,Description,CreateDate,UpdateTime")] ServiceReview serviceReview)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            ServiceReview _Servicereview = new ServiceReview();
            if (ModelState.IsValid)
            {
                _Servicereview.ServiceId = serviceReview.ServiceId;
                _Servicereview.Rating = serviceReview.Rating;
                _Servicereview.UserId = currentUserId;
                _Servicereview.Description = serviceReview.Description;
                _Servicereview.CreateDate = DateTime.Now;
                _Servicereview.UpdateTime = DateTime.Now;

                await  _context.AddAsync(_Servicereview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_Servicereview);
        }

        // GET: ServiceReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceReview = await _context.ServiceReviews.FindAsync(id);
            if (serviceReview == null)
            {
                return NotFound();
            }
            return View(serviceReview);
        }

        // POST: ServiceReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceReviewId,UserId,Rating,ServiceId,Description,CreateDate,UpdateTime")] ServiceReview serviceReview)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (id != serviceReview.ServiceReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _Servicereview = await _context.ServiceReviews.FindAsync(id);
                    _Servicereview.ServiceId = serviceReview.ServiceId;
                    _Servicereview.Rating = serviceReview.Rating;
                    _Servicereview.UserId = currentUserId;
                    _Servicereview.Description = serviceReview.Description;
                    _Servicereview.CreateDate = serviceReview.CreateDate;
                    _Servicereview.UpdateTime = DateTime.Now;


                    _context.Update(_Servicereview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceReviewExists(serviceReview.ServiceReviewId))
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
            return View(serviceReview);
        }

        // GET: ServiceReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceReview = await _context.ServiceReviews
                .FirstOrDefaultAsync(m => m.ServiceReviewId == id);
            if (serviceReview == null)
            {
                return NotFound();
            }

            return View(serviceReview);
        }

        // POST: ServiceReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceReview = await _context.ServiceReviews.FindAsync(id);
            _context.ServiceReviews.Remove(serviceReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceReviewExists(int id)
        {
            return _context.ServiceReviews.Any(e => e.ServiceReviewId == id);
        }

        //My APIs

        [HttpPost("/ServiceReviews/SubmitServiceReview")]
        public async Task<IActionResult> SubmitServiceReview([FromBody] ServiceReview Servicereview)
        {
            POJOMsgs model = new POJOMsgs();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            ServiceReview _Servicereview = new ServiceReview();
            try
            {
                _Servicereview.Rating = Servicereview.Rating;
                _Servicereview.UserId = currentUserId;
                _Servicereview.Description = Servicereview.Description;
                _Servicereview.ServiceId = Servicereview.ServiceId;
                _Servicereview.CreateDate = DateTime.Now;
                _Servicereview.UpdateTime = DateTime.Now;
                await _context.ServiceReviews.AddAsync(_Servicereview);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Have Been Added";

                //Calc it with the last rate value avg.(Future Method)
                IQueryable<ServiceReview> OldValueRating =  _context.ServiceReviews.Where(r =>r.ServiceId== Servicereview.ServiceId);
                double TotalServiceRating = await OldValueRating.AverageAsync(m => m.Rating);
                Service _service =await _context.Services.FindAsync(Servicereview.ServiceId);
                _service.ServiceRating = TotalServiceRating;
                _context.Services.Update(_service);
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


        [HttpGet("ServiceReviews/{id}")]
        public IActionResult ServiceReviews([FromBody] int id)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                IEnumerable<ServiceReview> _Servicereviews = _context.ServiceReviews.Where(i => i.ServiceId == id);
                return Json(_Servicereviews);
            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }
        [HttpGet("CheckCustomerServiceReview/{id}")]
        public IActionResult CheckCustomerServiceReview(int id)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            POJOMsgs model = new POJOMsgs();

            ServiceReview _Serivereviews = _context.ServiceReviews.FirstOrDefault(m => m.ServiceId == id && m.UserId == currentUserId);
            if (_Serivereviews != null)
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
