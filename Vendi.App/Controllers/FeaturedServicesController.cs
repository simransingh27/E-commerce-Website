using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 
using Microsoft.EntityFrameworkCore;
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Controllers
{
    [Authorize]
    public class FeaturedServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeaturedServicesController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: FeaturedServices
        public IActionResult Index()
        {

            var model = _context.FeaturedServices;

            var result = from e in model
                         join p in _context.Services on e.ServiceId equals p.ServiceId
                         select new FeaturedServiceModelView
                         {
                             FeatureServiceId = e.FeatureServiceId,
                             ServiceId = e.ServiceId,
                            
                             FeaturedFrom = e.FeaturedFrom,
                             FeaturedTo = e.FeaturedTo,
                             CreatedDate = e.CreatedDate,
                             UpdateDate = e.UpdateDate,
                             ServiceName = p.ServiceName
                         };

            return View(result);
        }

        // GET: FeaturedServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var featuredService = await _context.FeaturedServices
                .FirstOrDefaultAsync(m => m.FeatureServiceId == id);

            var model = _context.FeaturedServices.Where(n => n.FeatureServiceId == id);
            if (featuredService == null)
            {
                return RedirectToAction("Error", "Home");
            }

            IQueryable<FeaturedServiceModelView> result = from e in model
                                                          join p in _context.Services on e.ServiceId equals p.ServiceId

                                                          select new FeaturedServiceModelView
                                                          {
                                                              FeatureServiceId = e.FeatureServiceId,
                                                              ServiceId = e.ServiceId,
                                                              UserId = e.UserId,
                                                              FeaturedFrom = e.FeaturedFrom,
                                                              FeaturedTo = e.FeaturedTo,
                                                              CreatedDate = e.CreatedDate,
                                                              UpdateDate = e.UpdateDate,
                                                              ServiceName = p.ServiceName
                                                          };

            var FS_result = await result.FirstOrDefaultAsync();
            return View(FS_result);
        }

        // GET: FeaturedServices/Create
        public IActionResult Create(int id)
        {
            if (id.Equals(0))
            {
                return RedirectToAction("Error", "Home");
            }
            FeaturedService model = new FeaturedService();
            model.ServiceId = id;
            return View(model);
        }

        // POST: FeaturedServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeatureServiceId,ServiceId,UserId,FeaturedFrom,FeaturedTo,CreatedDate,UpdateDate")] FeaturedService featuredService)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FeaturedService _featuredService = new FeaturedService();
                    _featuredService.ServiceId = featuredService.ServiceId;
                    _featuredService.UserId = featuredService.UserId;
                    _featuredService.FeaturedFrom = featuredService.FeaturedFrom;
                    _featuredService.FeaturedTo = featuredService.FeaturedTo;
                    _featuredService.CreatedDate = DateTime.Now;
                    _featuredService.UpdateDate = DateTime.Now;
                    await _context.AddAsync(_featuredService);
                    await _context.SaveChangesAsync();
                    int Id = featuredService.ServiceId;
                    return RedirectToAction("BusinessAddresses", "Services", new { id = Id });
                }
                catch (Exception )
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return View(featuredService);
        }

        // GET: FeaturedServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var featuredService = await _context.FeaturedServices.FindAsync(id);
            if (featuredService == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(featuredService);
        }

        // POST: FeaturedServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeatureServiceId,ServiceId,UserId,FeaturedFrom,FeaturedTo,CreatedDate,UpdateDate")] FeaturedService featuredService)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            if (id != featuredService.FeatureServiceId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _featuredService = await _context.FeaturedServices.FindAsync(id);

                    _featuredService.ServiceId = featuredService.ServiceId;
                    _featuredService.UserId = currentUserId;

                    _featuredService.FeaturedFrom = featuredService.FeaturedFrom;
                    _featuredService.FeaturedTo = featuredService.FeaturedTo;
                    _featuredService.CreatedDate = featuredService.CreatedDate;
                    _featuredService.UpdateDate = DateTime.Now;

                    _context.Update(_featuredService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturedServiceExists(featuredService.FeatureServiceId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(featuredService);
        }

        // GET: FeaturedServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var featuredService = await _context.FeaturedServices
                .FirstOrDefaultAsync(m => m.FeatureServiceId == id);
            if (featuredService == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(featuredService);
        }

        // POST: FeaturedServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id.Equals(0))
            {
                return RedirectToAction("Error", "Home");
            }
            var featuredService = await _context.FeaturedServices.FindAsync(id);
            _context.FeaturedServices.Remove(featuredService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturedServiceExists(int id)
        {
            return _context.FeaturedServices.Any(e => e.FeatureServiceId == id);
        }

        [HttpGet("DeleteServiceFeature/{id}")]
        public async Task<IActionResult> DeleteServiceFeature(int id)
        {
            POJOMsgs model = new POJOMsgs();
            FeaturedService _service = new FeaturedService();

            try
            {
                FeaturedService _featuredService = _context.FeaturedServices.FirstOrDefault(m => m.FeatureServiceId == id);
                _context.FeaturedServices.Remove(_featuredService);
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
