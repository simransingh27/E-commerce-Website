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
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoritesController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Favorites.ToListAsync());
        }


         

        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.FavoriteId == id);
        }

        public IActionResult UserFavorites()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);
          //  var model = _context.Favorites.Where(i => i.UserId == currentUserId);

            IQueryable<ProductFavoriteModelView> _ProductFavorite = from Productfav in _context.Favorites.Where(i => i.UserId == currentUserId)
                                                  join p in _context.Products on Productfav.ProductId equals p.ProductId
                                                  
                                                  select new ProductFavoriteModelView
                                                  {
                                                      Product = p.ProductName,                                                     
                                                      ProductId = p.ProductId,
                                                      FavoriteId = Productfav.FavoriteId,
                                                      CreateDate= Productfav.CreateDate
                                                  };

            if (_ProductFavorite == null)
            {
                return RedirectToAction("Error", "Home");
            }
            IQueryable<ServiceFavoriteModelView> _ServiceFavorite = from ServiceFav in _context.ServiceFavorites.Where(i => i.UserId == currentUserId)
                                                          join p in _context.Services on ServiceFav.ServiceId equals p.ServiceId

                                                          select new ServiceFavoriteModelView
                                                          {
                                                              ServiceName = p.ServiceName,
                                                              ServiceId = p.ServiceId,
                                                              ServiceFavoriteId = ServiceFav.ServiceFavoriteId,
                                                              CreateDate = ServiceFav.CreateDate
                                                          };
            if (_ServiceFavorite == null)
            {
                return RedirectToAction("Error", "Home");
            }
            FavoritesModelView model = new FavoritesModelView();
            model.FavoriteProduct = _ProductFavorite;
            model.FavoriteService = _ServiceFavorite;
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddToProductWishList( int id)
        {
                               
            POJOMsgs model = new POJOMsgs();
            try { 
            string currentUserId = _userManager.GetUserId(HttpContext.User);
            Favorite favorite = new Favorite();
            Favorite fav =await _context.Favorites.FirstOrDefaultAsync(m => m.ProductId == id && m.UserId == currentUserId);

            if (fav != null)
            {
                model.Flag = true;
                model.Msg = " available in db and we deleted it.";
                 _context.Favorites.Remove(fav);
            }
            else
            {
                model.Flag = false;
                model.Msg = "not available in db and we added it.";
                favorite.ProductId = id;
                favorite.UserId = currentUserId;
                favorite.CreateDate = DateTime.Now;
                favorite.UpdateDate = DateTime.Now;
                await  _context.AddAsync(favorite);
               
            }
                await  _context.SaveChangesAsync();

            }catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductFavoriteCheck( int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            POJOMsgs model = new POJOMsgs();
           
            string currentUserId = _userManager.GetUserId(HttpContext.User);
            Favorite favorite = new Favorite();
            Favorite fav =await _context.Favorites.FirstOrDefaultAsync(m => m.ProductId == id && m.UserId == currentUserId);
            if (fav != null)
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


        [HttpGet("DeleteUserFaV/{id}")]
        public async Task<IActionResult> DeleteUserFaV(int? id)
        {
            POJOMsgs model = new POJOMsgs();          
            Favorite favorite = new Favorite();
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            try { 
            Favorite fav =await _context.Favorites.FirstOrDefaultAsync(m => m.FavoriteId==id);
             _context.Favorites.Remove(fav);
             await  _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Has Been Deleted it";
            }catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }


    }
}