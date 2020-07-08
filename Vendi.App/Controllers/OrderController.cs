using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //press checkout to create the order
        [HttpPost("/Order/CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderValueModelView _CartOrder)
        {
            POJOMsgs model = new POJOMsgs();
            try { 
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
        //    Vendi.Data.Order _IsOrderAvailable = _context.Orders.FirstOrDefault(o => o.UserId == currentUserId && o.IsPaid == false);
            Vendi.Data.Order _Ordersave = new Vendi.Data.Order();
                string _OrderId = "";
                string _OrderString = "ORD";
                //   if (_IsOrderAvailable == null)
                //   {
                _Ordersave.UserId = currentUserId;
                _Ordersave.OrderDate = DateTime.Now;
                _Ordersave.IsPaid = false;//Not Paid yet.          
                _Ordersave.Total = _CartOrder.Total;
                _Ordersave.CreateDate = DateTime.Now;
                _Ordersave.UpdateTime = DateTime.Now;

                //to get the last order has been added
                //Order _LastOrder = _context.Orders.LastOrDefault();
                Order _LastOrder =await _context.Orders.OrderByDescending(t => t.OrderId).FirstOrDefaultAsync();//return the last order only
                if (_LastOrder == null)
                {
                    _Ordersave.OrderId = _OrderString + 1;
                }
                else
                {
                    //send 
                    _Ordersave.OrderId = CreateOrderID(_LastOrder.OrderId);
                }

                await _context.Orders.AddAsync(_Ordersave);
                await _context.SaveChangesAsync();
                _OrderId = _Ordersave.OrderId;

                IQueryable<CartLine> _CartLineOrder = _context.CartLines.Where(x => x.CartId == _CartOrder.CartId);

                OrderModelView _OrderModelView = new OrderModelView();

                IList<OrderLine> _OrderLinelst = new List<OrderLine>();

                foreach (var item in _CartLineOrder)
                {
                    OrderLine _OrderLine = new OrderLine();
                    _OrderLine.OrderId = _Ordersave.OrderId;
                    _OrderLine.ProductId = item.ProductId;
                    _OrderLine.Qty = item.QTY;
                    _OrderLine.price = item.Price;
                    _OrderLine.CreateDate = DateTime.Now;
                    _OrderLine.UpdateTime = DateTime.Now;
                    _OrderLinelst.Add(_OrderLine);
                }
                
                await _context.OrderLines.AddRangeAsync(_OrderLinelst);
                await _context.SaveChangesAsync();

                //closing the cart 
                Cart _Cart =await _context.Carts.FindAsync(_CartOrder.CartId);
                _Cart.Status = false;//To close the Cart
                _context.Carts.Update(_Cart);
                await _context.SaveChangesAsync();

                model.Flag = true;
                model.Msg = _OrderId.ToString();




               
                               
            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
               
            }
         //   }
         //  model.Flag = false;
         //  model.Msg = "You have an issue contact the Support Teams" ;
         return Json(model);
        }
        //after create the order
       
        public IActionResult OrderConfirmation(string id)
        {
            if (id==null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }
            Order _Order =new Order();
            _Order.OrderId = id;
                return View(_Order);
        }

        public IActionResult MyOrderHistory()
        {
            //need to change open and closed orders
            string currentUserId = _userManager.GetUserId(HttpContext.User);
                IQueryable<Vendi.Data.Order> result = _context.Orders.Where(o => o.UserId == currentUserId);  
            return View(result);
        }

        public IActionResult OrderDetails(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }

            IQueryable<OrderModelView> result = from ord in _context.Orders.Where(ord => ord.OrderId==id)
                                                    join o in _context.OrderLines on ord.OrderId equals o.OrderId
                                                    join p in _context.Products on o.ProductId equals p.ProductId                                                    
                                                    //Need Image Path
                                                    select new OrderModelView
                                                    {
                                                        ProductName = p.ProductName,                                                        
                                                        Quantity = o.Qty,
                                                        Price = o.price,
                                                        ProductId = p.ProductId,
                                                        OrderId = ord.OrderId,                                                        
                                                        Total = ord.Total,
                                                        ImagePath=p.ImageThumbnail
                                                    };
                return View(result);
        }




       


        private bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
        //to cearte order string ord00001
        private string CreateOrderID(string id)
        {

            string _OrderString = "ORD";
            string[] _OderSplit;
           // Order _LastOrder = _context.Orders.OrderByDescending(t => t.OrderId).First();//return the last order only
            _OderSplit = id.Split('D');
            int i = Int32.Parse(_OderSplit[1]);
            i += 1;
            id = _OrderString + i;

            bool IsExist = OrderExists(id);
            if (IsExist)
            {
              id=  CreateOrderID(id);
            }


            return id;
        }


    }
}