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
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public double TotalCarts { get; set; }

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Cart/AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] Vendi.Data.Product value)
        {
            POJOMsgs pjmodel = new POJOMsgs();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            Cart _IsCartOpen = await _context.Carts.FirstOrDefaultAsync(m => m.UserId == currentUserId && m.Status == true);
            CartsModelView model01 = new CartsModelView();
            if (_IsCartOpen == null)
            {
                Cart _Cart = new Cart();

                _Cart.UserId = currentUserId;
                _Cart.Status = true;
                _Cart.CreateDate = DateTime.Now;
                _Cart.UpdateDate = DateTime.Now;
                _Cart.Total = _Cart.Total + (value.Price * value.Quantity);


                await _context.Carts.AddAsync(_Cart);
                await _context.SaveChangesAsync();
                model01.CartId = _Cart.CartId;
                model01.ProductId = value.ProductId;
                model01.Quantity = value.Quantity;
                model01.Price = value.Price;



            }
            else if (_IsCartOpen != null)
            {

                _IsCartOpen.Total = _IsCartOpen.Total + (value.Price * value.Quantity);
                _context.Carts.Update(_IsCartOpen);
                await _context.SaveChangesAsync();
                model01.CartId = _IsCartOpen.CartId;
                model01.ProductId = value.ProductId;
                model01.Quantity = value.Quantity;
                model01.Price = value.Price;
                //return await AddToCartLines(model01);


            }
            var QtyModel = await AddToCartLines(model01);
            //var QtyModel = _context.Carts.Where(c => c.CartId == _IsCartOpen.CartId);
            return Json(QtyModel);
        }



        public async Task<int> AddToCartLines(CartsModelView _CartModalView)
        {
            CartLine _CartLineCheck = await _context.CartLines.FirstOrDefaultAsync(m => m.CartId == _CartModalView.CartId && m.ProductId == _CartModalView.ProductId);
            if (_CartLineCheck == null)
            {
                CartLine _CartLine = new CartLine();
                _CartLine.CartId = _CartModalView.CartId;
                _CartLine.ProductId = _CartModalView.ProductId;
                _CartLine.Price = _CartModalView.Price;
                _CartLine.QTY = _CartModalView.Quantity;
                _CartLine.CreateDate = DateTime.Now;
                _CartLine.UpdateDate = DateTime.Now;
                await _context.CartLines.AddAsync(_CartLine);
                await _context.SaveChangesAsync();

            }
            else if (_CartLineCheck != null)
            {

                _CartLineCheck.QTY = _CartLineCheck.QTY + _CartModalView.Quantity;
                _CartLineCheck.UpdateDate = DateTime.Now;
                _context.CartLines.Update(_CartLineCheck);
                await _context.SaveChangesAsync();
            }
            var _CartLineQty = _context.CartLines.Where(x => x.CartId == _CartModalView.CartId).Sum(n => n.QTY);

            return _CartLineQty;
        }

        [HttpGet("CheckCartTotal")]
        public async Task<int> CheckCartTotal()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Cart _CartCheck = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == currentUserId && c.Status == true);
            int _cartline = 0;
            if (_CartCheck != null)
            {
                _cartline = _context.CartLines.Where(ca => ca.CartId == _CartCheck.CartId).Sum(qt => qt.QTY);
                return _cartline;
            }
            return _cartline;
        }

        [HttpGet("GetCartTotal")]
        public async Task<double> GetCartTotal()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Cart _CartCheck = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == currentUserId && c.Status == true);
            double _cartline = 0;
            if (_CartCheck != null)
            {
                _cartline = _context.Carts.Find(_CartCheck.CartId).Total;
                return _cartline;
            }
            return _cartline;
        }
         
        //From Cart, Press Checkout will create order after forword you to Check Out Page
        [HttpGet("/Cart/Checkout/{id}")]
        public async Task<IActionResult> Checkout(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            if (currentUserId == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var _User = _userManager.FindByIdAsync(currentUserId);
            string _Email = _User.Result.Email;
            string _Phone = _User.Result.PhoneNumber;
            string _FirstName = _User.Result.FirstName;
            string _LastName = _User.Result.LastName;



            Order _Order =await _context.Orders.FindAsync(id);
            Address _Address =await _context.Addresses.FirstOrDefaultAsync(i => i.UserId == currentUserId);
            CheckOutModelView model = new CheckOutModelView();

            model.FirstName = _FirstName;
            model.LastName = _LastName;
            model.Email = _Email;
            model.Street = _Address.HouseNumber + ", " + _Address.Street+" "+_Address.Country+", "+_Address.County;
            model.Country = _Address.Country;
            model.County = _Address.County;
            model.City = _Address.City;
            model.PostCode = _Address.PostCode;
            model.Mobile = _Phone;
            model.OrderId = id;
            model.TotalOrder = _Order.Total;


            return View(model);
        }
       

     
            //Will update the order to Ispaid true  
            public async Task<IActionResult> UserCart()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);
            Cart _CartCheck = await _context.Carts.FirstOrDefaultAsync(u => u.UserId == currentUserId && u.Status == true);
            

            if (_CartCheck != null)
            {     
                IQueryable<CartsModelView> res = from c in _context.CartLines.Where(m => m.CartId == _CartCheck.CartId)
                                                 join p in _context.Products on c.ProductId equals p.ProductId
                                               
                                                 join ca in _context.Carts on c.CartId equals ca.CartId
                                                 select new CartsModelView
                                                 {
                                                     ProductName = p.ProductName,
                                                     ImagePath = p.ImageThumbnail,
                                                     Quantity = c.QTY,
                                                     Price = c.Price,
                                                     ProductId = p.ProductId,
                                                     CartId = c.CartId,
                                                     Total = ca.Total,
                                                     CartLineId=c.CartLineId
                                                 };
                return View(res);
            }

            return View();

        }

        [HttpGet("DeleteCartLine/{id}")]
        public async Task<IActionResult> DeleteCartLine(int id)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                CartLine _CartLine = await _context.CartLines.FirstOrDefaultAsync(m => m.CartLineId == id);
                if (_CartLine != null)
                {
                    Cart _Cart = await _context.Carts.FirstOrDefaultAsync(u => u.CartId == _CartLine.CartId);
                    _context.CartLines.Remove(_CartLine);
                    await _context.SaveChangesAsync();


                    _Cart.Total = _Cart.Total - (_CartLine.Price * _CartLine.QTY);
                    _context.Carts.Update(_Cart);
                    await _context.SaveChangesAsync();

                    model.Flag = true;
                    model.Msg = "Has Been Deleted ";

                }

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