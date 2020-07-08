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
    public class ServiceFavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceFavoritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //return View(await _context.ServiceFavorites.ToListAsync());
            return View();
        }


        [HttpGet("/ServiceFavorites/GetServiceFavoriteCheck/{id}")]
        public async Task<IActionResult> GetServiceFavoriteCheck(int id)
        {
            POJOMsgs model = new POJOMsgs();
            string currentUserId = _userManager.GetUserId(HttpContext.User);
            ServiceFavorite service = new ServiceFavorite();
            ServiceFavorite _service = await _context.ServiceFavorites.FirstOrDefaultAsync(m => m.ServiceId == id && m.UserId == currentUserId);
            if (_service != null)
            {
                model.Flag = true;
                model.Msg = "available in db";

            }
            else
            {
                model.Flag = false;
                model.Msg = "not available in db";
            }
            return Json(model);
        }

        [HttpGet("/ServiceFavorites/AddToServiceWishList/{id}")]
        public async Task<IActionResult> AddToServiceWishList(int id)
        {
            POJOMsgs model = new POJOMsgs();

            string currentUserId = _userManager.GetUserId(HttpContext.User);
            ServiceFavorite service = new ServiceFavorite();

            ServiceFavorite _service = await _context.ServiceFavorites.FirstOrDefaultAsync(m => m.ServiceId == id && m.UserId == currentUserId);
            if (_service != null)
            {
                model.Flag = true;
                model.Msg = " avaailable in db and we deleted it.";
                _context.ServiceFavorites.Remove(_service);
            }
            else
            {
                model.Flag = false;
                model.Msg = "not available in db and we added it.";
                service.ServiceId = id;
                service.UserId = currentUserId;
                service.CreateDate = DateTime.Now;
                service.UpdateDate = DateTime.Now;
                await _context.ServiceFavorites.AddAsync(service);

            }
            await _context.SaveChangesAsync();
            return Json(model);
        }
        public IActionResult ServiceUserFavorite()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);

            IQueryable<ServiceFavoriteModelView> result = from fav in _context.ServiceFavorites.Where(i => i.UserId == currentUserId)
                                                          join p in _context.Services on fav.ServiceId equals p.ServiceId

                                                          select new ServiceFavoriteModelView
                                                          {
                                                              ServiceName = p.ServiceName,
                                                              ServiceId = p.ServiceId,
                                                              ServiceFavoriteId = fav.ServiceFavoriteId,
                                                              CreateDate = fav.CreateDate
                                                          };
            return View(result);
        }

        [HttpGet("/ServiceFavorites/DeleteServiceFaV/{id}")]
        public async Task<IActionResult> DeleteServiceFaV(int id)
        {
            POJOMsgs model = new POJOMsgs();
            ServiceFavorite favorite = new ServiceFavorite();
            try
            {
                ServiceFavorite fav = await _context.ServiceFavorites.FirstOrDefaultAsync(m => m.ServiceFavoriteId == id);
                _context.ServiceFavorites.Remove(fav);
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