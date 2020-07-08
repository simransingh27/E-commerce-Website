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
    public class AdsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdsController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: Ads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ads.ToListAsync());
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.AdsId == id);
            if (ad == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdsId,AdsContent,CreateDate,UpdateDate,AdsName,UserId")] Ad ad)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Ad _Ad = new Ad();
            if (ModelState.IsValid)
            {
                _Ad.AdsContent = ad.AdsContent;
                _Ad.AdsName = ad.AdsName;
                _Ad.UserId = currentUserId;
                _Ad.CreateDate = DateTime.Now;
                _Ad.UpdateDate = DateTime.Now;
                _context.Add(_Ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdsId,AdsContent,CreateDate,UpdateDate,AdsName,UserId")] Ad ad)
        {

            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (id != ad.AdsId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _Ads = await _context.Ads.FindAsync(id);
                    _Ads.AdsName = ad.AdsName;
                    _Ads.UserId = currentUserId;
                    _Ads.AdsContent = ad.AdsContent;
                    _Ads.CreateDate = ad.CreateDate;
                    _Ads.UpdateDate = DateTime.Now;
                    _context.Update(_Ads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.AdsId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
            }
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.AdsId == id);
            if (ad == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.AdsId == id);
        }

        [HttpGet("DeleteAds/{id}")]
        public async Task<IActionResult> DeleteAds(int id)
        {
            POJOMsgs model = new POJOMsgs();
            Ad ads = new Ad();
            try
            {
                Ad _Ad = _context.Ads.FirstOrDefault(m => m.AdsId == id);
                _context.Ads.Remove(_Ad);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Deleted from Ads db";
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