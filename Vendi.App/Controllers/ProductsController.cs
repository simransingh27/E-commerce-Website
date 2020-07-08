using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkPaginate;
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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: Products       
        public IActionResult Index()
        {

            //var result = from e in _context.Products.Where(status => status.IsStatus == true)
            //                                      join d in _context.Brands on e.BrandId equals d.BrandId
            //                                      join pt in _context.ProductTypes on e.ProductTypeId equals pt.ProductTypeId
            //                                      join ct in _context.Categories on e.CategoryId equals ct.CategoryId

            //                                      select new ProductModelView
            //                                      {
            //                                          ProductName = e.ProductName,
            //                                          BrandName = d.BrandName,
            //                                          ProductTypeName = pt.ProductTypeName,
            //                                          ProductId = e.ProductId,
            //                                          CategoryName = ct.CategoryName,
            //                                          Price = e.Price,
            //                                          ProductRating=e.ProductRating,
            //                                          Image=e.ImageThumbnail

            //                                      };       
            //return View(result);
            return View();
        }
        public IActionResult GetProducts(int pageSize, int currentPage)
        {
            Page<ProductModelView> _ProductModelView;
            var result = from e in _context.Products.Where(status => status.IsStatus == true)
                         join d in _context.Brands on e.BrandId equals d.BrandId
                         join pt in _context.ProductTypes on e.ProductTypeId equals pt.ProductTypeId
                         join ct in _context.Categories on e.CategoryId equals ct.CategoryId

                         select new ProductModelView
                         {
                             ProductName = e.ProductName,
                             BrandName = d.BrandName,
                             ProductTypeName = pt.ProductTypeName,
                             ProductId = e.ProductId,
                             CategoryName = ct.CategoryName,
                             Price = e.Price,
                             ProductRating = e.ProductRating,
                             Image = e.ImageThumbnail

                         };




            _ProductModelView = result.Paginate(currentPage, pageSize);

            return Json(_ProductModelView);
        }

        public IActionResult GetProductByCategory(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }
            var result = from e in _context.Products.Where(i => i.CategoryId == Id && i.IsStatus==true)
                         join d in _context.Brands on e.BrandId equals d.BrandId
                         join pt in _context.ProductTypes on e.ProductTypeId equals pt.ProductTypeId
                         join ct in _context.Categories on e.CategoryId equals ct.CategoryId
                         join img in _context.ProductImage on e.ProductId equals img.ProductId
                         select new ProductModelView
                         {
                             ProductName = e.ProductName,
                             BrandName = d.BrandName,
                             ProductTypeName = pt.ProductTypeName,
                             ProductId = e.ProductId,
                             CategoryName = ct.CategoryName,
                             Condition = e.Condition,
                             Quantity = e.Quantity,
                             BarCode = e.BarCode,
                             Price = e.Price,
                             Description = e.Description,
                             Tags = e.Tags,
                             ProductRating=e.ProductRating,
                             Image = e.ImageThumbnail

                         };

            //send it to index 
           // return RedirectToAction("Index","Products",result);
             return View("Index",result);
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }
            // var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            var result = from e in _context.Products.Where(i  => i.ProductId==id)
                                                  join d in _context.Brands on e.BrandId equals d.BrandId
                                                  join pt in _context.ProductTypes on e.ProductTypeId equals pt.ProductTypeId
                                                  join ct in _context.Categories on e.CategoryId equals ct.CategoryId                                                 
                                                  select new ProductModelView
                                                  {
                                                      ProductName = e.ProductName,
                                                      BrandName = d.BrandName,
                                                      ProductTypeName = pt.ProductTypeName,
                                                      ProductId = e.ProductId,
                                                      CategoryName = ct.CategoryName,
                                                      Condition=e.Condition,
                                                      Quantity=e.Quantity,
                                                      BarCode=e.BarCode,
                                                      Price=e.Price,
                                                      Description=e.Description,
                                                      Tags=e.Tags,
                                                      ProductRating=e.ProductRating  
                                                  };

          var F_Result=  result.FirstOrDefault();

            if (F_Result == null)
            {
                return RedirectToAction("Error", "Home");
            }

            F_Result.Images =  _context.ProductImage.Where(i => i.ProductId == id);
            
            F_Result.ProductReviews = _context.Reviews.Where(p => p.ProductId == id);
           // IQueryable<Review> Rating = _context.Reviews.Where(p => p.ProductId == id);           
          //  if (Rating.Count() !=0)
          //  {
          //      var Ratings = Rating.Average(i => i.Rating);
         //F_Result.ProductRating = Ratings;
        //    }
           


            // Below logic has been implemeneted to insert data to user visited products.
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (currentUserId != null)//maybe user not reg, just pass without save to db
            {
                UserVisitedProduct _UserVisitedProduct = new UserVisitedProduct();
                UserVisitedProduct _IsUserVisitedProduct = _context.UserVisitedProducts.FirstOrDefault(m => m.ProductId == F_Result.ProductId && m.UserId == currentUserId);
                if (_IsUserVisitedProduct == null)
                {
                    _UserVisitedProduct.ProductId = F_Result.ProductId;
                    _UserVisitedProduct.UserId = currentUserId;
                    _UserVisitedProduct.CreatedDate = DateTime.Now;
                    _UserVisitedProduct.UpdateDate = DateTime.Now;
                    _UserVisitedProduct.Frequency = 1;
                    await _context.UserVisitedProducts.AddAsync(_UserVisitedProduct);
                }
                else
                {
                    _IsUserVisitedProduct.ProductId = F_Result.ProductId;
                    _IsUserVisitedProduct.UserId = currentUserId;
                    _IsUserVisitedProduct.CreatedDate = _IsUserVisitedProduct.CreatedDate;
                    _IsUserVisitedProduct.UpdateDate = DateTime.Now;
                    _IsUserVisitedProduct.Frequency += 1;
                    _context.UserVisitedProducts.Update(_IsUserVisitedProduct);
                }
                await _context.SaveChangesAsync();
            }

            return View(F_Result);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            Product _product = new Product();
            _product.Categories = _context.Categories;
            _product.ProductTypes = _context.ProductTypes;
            _product.Brands = _context.Brands;
                 if(_product.Categories==null && _product.ProductTypes==null && _product.Brands == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }
            return View(_product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Condition,Quantity,BarCode,BrandId,ProductTypeId,ProductName,UserId,Price,CategoryId,Description,Tags,IsFeatured,CreateDate,UpdateTime")] Product product)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Product _Product = new Product();
            if (ModelState.IsValid)
            {
                _Product.Condition = product.Condition;
                _Product.Quantity = product.Quantity;
                _Product.BarCode = product.BarCode;
                _Product.BrandId = product.BrandId;
                _Product.UserId = currentUserId;
                _Product.ProductTypeId = product.ProductTypeId;
                _Product.ProductName = product.ProductName;
                
                _Product.Price = product.Price;
                _Product.CategoryId = product.CategoryId;
                _Product.Description = product.Description;
                _Product.Tags = product.Tags;
                _Product.IsFeatured = product.IsFeatured;
                _Product.IsStatus = false;
                _Product.UpdateTime = DateTime.Now;
                _Product.CreateDate = DateTime.Now;
                 await _context.AddAsync(_Product);
                await _context.SaveChangesAsync();
                int Id = _Product.ProductId;
                // return RedirectToAction(nameof(Index));
                //Write following in Controller1  
                if (_Product.IsFeatured.Equals(true)) { 
                return RedirectToAction("Create", "FeaturedProducts", new { id =Id });
                }
                return RedirectToAction("AddProductImage", "ProductImage", new { id = Id }); //if its not Featudre no need to go to fareatre page
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {

                return RedirectToAction("Error", "Home");//error message 
            }
            product.Categories = _context.Categories;
            product.ProductTypes = _context.ProductTypes;
            product.Brands = _context.Brands;

            if (product.Categories == null && product.ProductTypes == null && product.Brands == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }

            return View(product);          
            
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Condition,Quantity,BarCode,BrandId,ProductTypeId,ProductName,UserId,Price,CategoryId,Description,Tags,IsFeatured,CreateDate,UpdateTime")] Product product)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (id != product.ProductId)
            {
                return RedirectToAction("Error", "Home");//error message 
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _Product = await _context.Products.FindAsync(id);
                    _Product.Condition = product.Condition;
                    _Product.Quantity = product.Quantity;
                    _Product.BarCode = product.BarCode;
                    _Product.BrandId = product.BrandId;
                    _Product.UserId = currentUserId;
                    _Product.ProductTypeId = product.ProductTypeId;
                    _Product.ProductName = product.ProductName;
                    _Product.Price = product.Price;
                    _Product.CategoryId = product.CategoryId;
                    _Product.Description = product.Description;
                    _Product.Tags = product.Tags;
                    _Product.IsStatus = false;
                    _Product.IsFeatured = product.IsFeatured;
                   
                    _Product.CreateDate = product.CreateDate;
                    _Product.UpdateTime = DateTime.Now;

                    _context.Update(_Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return RedirectToAction("Error", "Home");//error message 
                    }
                    
                }

                //  return RedirectToAction("Details", " Products", new { id  });
                return RedirectToAction(nameof(Details),new {id=product.ProductId });
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id.Equals(0))
            {
                return RedirectToAction("Error", "Home");//error message 
            }
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }


        public IActionResult AdminIndex()
        {
            IQueryable<ProductModelView> result = from e in _context.Products.Where(status => status.IsStatus==true)
                                                  join d in _context.Brands on e.BrandId equals d.BrandId
                                                  join pt in _context.ProductTypes on e.ProductTypeId equals pt.ProductTypeId
                                                  join ct in _context.Categories on e.CategoryId equals ct.CategoryId
                                                  select new ProductModelView
                                                  {
                                                      ProductName = e.ProductName,
                                                      BrandName = d.BrandName,
                                                      ProductTypeName = pt.ProductTypeName,
                                                      ProductId = e.ProductId,
                                                      CategoryName = ct.CategoryName,
                                                      Price = e.Price
                                                  };
            return View(result);
        }


        [HttpGet("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            POJOMsgs model = new POJOMsgs();
            Product product = new Product();

            try
            {
                Product _product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
                _context.Products.Remove(_product);
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
       

        [HttpGet("ApproveProduct/{id}")]
        public async Task<IActionResult> ApproveProduct(int id)
        {
            POJOMsgs model = new POJOMsgs();

            try
            {
                Product _product = _context.Products.FirstOrDefault(m => m.ProductId == id);
                _product.IsStatus = true;
                _context.Products.Update(_product);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Has Been Updated";
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
