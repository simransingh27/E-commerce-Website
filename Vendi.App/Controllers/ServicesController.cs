using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPaginate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexmo.Api;
 
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;

        public ServicesController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager, IHostingEnvironment env)
        {
            _context = context;
            _userManager = _UserManager;
            _env = env;
        }

        // GET: Services
        public IActionResult Index()
        {
            IQueryable<ServiceModelView> result = from e in _context.Services.Where(s => s.IsStatus == true)
                                                  join ct in _context.ServiceCategories on e.CategoryId equals ct.ServiceCategoryId
                                                  select new ServiceModelView
                                                  {
                                                      ServiceName = e.ServiceName,
                                                      ServiceId = e.ServiceId,
                                                      CategoryName = ct.CategoryName,
                                                      Price = e.Price,
                                                      ImagePath = e.ImagePath,
                                                      IsFeatured = e.IsFeatured,
                                                      Description = e.Description,
                                                      ServiceRating = e.ServiceRating

                                                  };

            return View(result);
        }

        [HttpGet("/Services/ServiceById/{id}")]
        public async Task<IActionResult> ServiceById(int? id)
        {
            //added error message if ID doesnt exist.
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Service _Service = await _context.Services.FindAsync(id);
            return Json(_Service);
        }


        //MyWork
        public IActionResult MyWork(int? id)
        {
            //added error message if ID doesnt exist.
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(id);
        }





        public IActionResult ServiceMap()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Address MyAddress = _context.Addresses.FirstOrDefault(s => s.UserId == currentUserId);
            if (MyAddress == null)
            {
                return RedirectToAction("Error", "Home");
            }



            string markers = "[";
            IQueryable<MapAddressModelView> AllUsersAddress = from ba in _context.BusinessAddresses
                                                              join se in _context.Services on ba.ServiceId equals se.ServiceId
                                                              join ca in _context.ServiceCategories on ba.ServiceCategoryId equals ca.ServiceCategoryId
                                                              select new MapAddressModelView
                                                              {
                                                                  Longitute = ba.Longitute,
                                                                  Latitue = ba.Latitue,
                                                                  ServiceRating = se.ServiceRating,
                                                                  ImagePath = se.ImagePath,
                                                                  ServiceId = se.ServiceId,
                                                                  ServiceName = se.ServiceName,
                                                                  CategoryName = ca.CategoryName
                                                              };


            foreach (var item in AllUsersAddress)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div id=content><div id=siteNotice><h3>");
                sb.Append(item.ServiceName);
                sb.Append("</h3></div><img class=img-thumbnail style= width:150px; src=");
                sb.Append(item.ImagePath);
                sb.Append(" /><p>");
                sb.Append(item.CategoryName);
                sb.Append("</p><div id=bodyContent><p><a type=button class=btn-primary href=/Services/Details/");
                sb.Append(item.ServiceId);
                sb.Append(">Offer</a></p></div></div>");


                double rs = distance(MyAddress.Latitue, MyAddress.Longitute, item.Latitue, item.Longitute);
                if (rs < 10000)
                {
                    markers += "{";
                    markers += string.Format("'lat': '{0}',", item.Latitue);
                    markers += string.Format("'lng': '{0}',", item.Longitute);
                    markers += string.Format("'text': '{0}',", sb);
                    markers += "},";
                }
            }

            markers += "];";
            MapModelView _Marker = new MapModelView();
            _Marker.Marker = markers;
            return View(_Marker);
        }



        //CompleteServiceOffer
        [HttpPost("/Services/CompleteServiceOffer")]
        public async Task<IActionResult> CompleteServiceOffer([FromBody] ServiceOrder _serviceOrder)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            ServiceOrder serviceOrder = new ServiceOrder();
            ServiceOffer serviceOffer = new ServiceOffer();


            //Getting the Customer UserId
            ServiceOffer _Service = await _context.ServiceOffers.FirstOrDefaultAsync(u => u.ServiceId == _serviceOrder.ServiceId);
            var _User = _userManager.FindByIdAsync(_Service.UserId);
            string User_id = _User.Result.Id;

            serviceOrder.VendorId = currentUserId;
            serviceOrder.TimeTaken = _serviceOrder.TimeTaken;
            serviceOrder.UserId = User_id;
            serviceOrder.ServiceId = _serviceOrder.ServiceId;
            serviceOrder.TotalAmount = _serviceOrder.TotalAmount;
            serviceOrder.Description = _serviceOrder.Description;
            serviceOrder.IsPaid = false;
            serviceOrder.PaymentMethod = 0;//0 means no payment 1 is cash 2 is online
            serviceOrder.CreateDate = DateTime.Now;
            serviceOrder.UpdateDate = DateTime.Now;
            string _ServiceOrderString = "SORD";
            ServiceOrder _LastServiceOrder = _context.ServiceOrders.OrderByDescending(t => t.ServiceOrderId).FirstOrDefault();//return the last order only
            if (_LastServiceOrder == null)
            {
                serviceOrder.ServiceOrderId = _ServiceOrderString + 1;
            }
            else
            {
                serviceOrder.ServiceOrderId = CreatServiceOrderID(_LastServiceOrder.ServiceOrderId);
            }



            await _context.ServiceOrders.AddAsync(serviceOrder);
            await _context.SaveChangesAsync();

            ServiceOffer _ServiceOffer = new ServiceOffer();
            ServiceOffer _service = await _context.ServiceOffers.FirstOrDefaultAsync(u => u.ServiceId == _serviceOrder.ServiceId);
            if (_service != null)
            {
                _service.IsStatus = false;
                _context.ServiceOffers.Update(_service);
                await _context.SaveChangesAsync();
            }

            return Json(serviceOrder);
        }

        public IActionResult GetServiceByCategory(int id)
        {

            if (id.Equals(0))
            {
                return RedirectToAction("Error", "Home");
            }


            //IQueryable<ServiceModelView> result = from e in _context.Services.Where(i => i.CategoryId == id && i.IsStatus == true)
            //                                      join ct in _context.ServiceCategories on e.CategoryId equals ct.ServiceCategoryId

            //                                      select new ServiceModelView
            //                                      {
            //                                          ServiceName = e.ServiceName,
            //                                          ServiceId = e.ServiceId,
            //                                          CategoryName = ct.CategoryName,
            //                                          Price = e.Price,
            //                                          ImagePath = e.ImagePath,
            //                                          IsFeatured = e.IsFeatured,
            //                                          ServiceRating = e.ServiceRating,
            //                                      };
            //return View("Index", result);
            ServiceModelView model = new ServiceModelView();
            model.CategoryId = id;
            return View("Index", model);
        }




        [HttpGet("/Servcies/GetServices")]
        public IActionResult GetServices(int pageSize, int currentPage,int id)
        {


            IQueryable<ServiceModelView> result = from e in _context.Services.Where(i => i.CategoryId == id && i.IsStatus == true)
                                                  join ct in _context.ServiceCategories on e.CategoryId equals ct.ServiceCategoryId

                                                  select new ServiceModelView
                                                  {
                                                      ServiceName = e.ServiceName,
                                                      ServiceId = e.ServiceId,
                                                      CategoryName = ct.CategoryName,
                                                      Price = e.Price,
                                                      ImagePath = e.ImagePath,
                                                      IsFeatured = e.IsFeatured,
                                                      ServiceRating = e.ServiceRating,
                                                  };
            Page<ServiceModelView> _ServiceModelView;





            _ServiceModelView = result.Paginate(currentPage, pageSize);

            return Json(_ServiceModelView);
        }








        // GET: Services/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var result = from e in _context.Services.Where(i => i.ServiceId == id)
                         join ct in _context.ServiceCategories on e.CategoryId equals ct.ServiceCategoryId

                         select new ServiceModelView
                         {
                             ServiceName = e.ServiceName,
                             ServiceId = e.ServiceId,
                             CategoryName = ct.CategoryName,
                             Tags = e.Tags,
                             Description = e.Description,
                             Price = e.Price,
                             ImagePath = e.ImagePath,
                             ServiceRating = e.ServiceRating

                         };

            var F_result = result.FirstOrDefault();


            if (F_result == null)
            {
                return RedirectToAction("Error", "Home");
            }
            F_result.ServiceReviews = _context.ServiceReviews.Where(s => s.ServiceId == id);

            //IQueryable<ServiceReview> Rating = _context.ServiceReviews.Where(s => s.ServiceId == id);

            //if (Rating.Count() != 0)
            //{
            //    var Ratings = Rating.Average(i => i.Rating);
            //    F_result.ServiceRating = Ratings;
            //}

            return View(F_result);
        }

        // GET: Services/Create
        public async Task<IActionResult> Create()
        {
            Service _service = new Service();
            _service.ServiceCategories = await _context.ServiceCategories.ToListAsync();
            if (_service.ServiceCategories == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(_service);
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,ServiceName,UserId,Price,CategoryId,Description,Tags,IsFeatured,ImagePath,CreateDate,UpdateTime")] Service service)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Service _service = new Service();
            if (ModelState.IsValid)
            {
                _service.ServiceName = service.ServiceName;
                _service.UserId = currentUserId;
                _service.Price = service.Price;
                _service.CategoryId = service.CategoryId;
                _service.Description = service.Description;
                _service.Tags = service.Tags;
                _service.IsFeatured = service.IsFeatured;
                _service.ImagePath = "/Image/Vendi/Vendi-Service.png";
                _service.ServiceRating = 0;
                _service.IsStatus = false;
                _service.CreateDate = DateTime.Now;
                _service.UpdateTime = DateTime.Now;
                await _context.AddAsync(_service);
                await _context.SaveChangesAsync();
                int Id = _service.ServiceId;
                //Diricate to IMage Upload
                if (_service.IsFeatured.Equals(true))
                {
                    return RedirectToAction("Create", "FeaturedServices", new { id = Id });
                } else
                {
                    return RedirectToAction("BusinessAddresses", "Services", new { id = Id });
                }

                //   return RedirectToAction("UploadServiceImage", "Services", new { id = Id });
                // return RedirectToAction(nameof(Index));
                //   return RedirectToAction("Index", "Services");
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //added error message if ID doesnt exist.
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var service = await _context.Services.FindAsync(id);
            //added error page in case its null
            if (service == null)
            {
                return RedirectToAction("Error", "Home");
            }

            ServiceModelView _ServiceModelView = new ServiceModelView();

            _ServiceModelView.ServiceId = service.ServiceId;
            _ServiceModelView.ServiceName = service.ServiceName;
            _ServiceModelView.ImagePath = service.ImagePath;
            _ServiceModelView.Price = service.Price;
            _ServiceModelView.Description = service.Description;
            _ServiceModelView.Tags = service.Tags;           
            _ServiceModelView.ServiceCategories =  await _context.ServiceCategories.ToListAsync();
            return View(_ServiceModelView);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,ServiceName,UserId,Price,CategoryId,Description,Tags,IsFeatured,ImagePath,CreateDate,UpdateTime,IsImageUpdate")] ServiceModelView service)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            //added error message if ServiceID doesnt exist.

            if (id != service.ServiceId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Service _service = await _context.Services.FindAsync(id);
                    _service.ServiceName = service.ServiceName;
                    _service.UserId = currentUserId;
                    _service.Price = service.Price;
                    _service.CategoryId = service.CategoryId;
                    _service.Description = service.Description;
                    _service.Tags = service.Tags;
                    _service.IsFeatured = service.IsFeatured;
                    _service.IsStatus = false;
                    // _service.ImagePath = service.ImagePath;
                    _service.ServiceRating = service.ServiceRating;                  
                    _service.UpdateTime = DateTime.Now;

                    _context.Update(_service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                int Id = service.ServiceId;
                if (service.IsImageUpdate)
                {
                    return RedirectToAction("UploadServiceImage", "Services", new { id = Id });
                }
                return RedirectToAction(nameof(Details), new { id = service.ServiceId });
            }
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }


            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }

        public IActionResult UploadServiceImage(int id)
        {
            if (id.Equals(0))
            {
                return RedirectToAction("Error", "Home");
            }

            Service model = new Service();
            model.ServiceId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadServiceImage(IFormCollection form, Service _Service)
        {
            string _imgname = Guid.NewGuid().ToString();
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            var webRoot = _env.WebRootPath;
            string storePath = webRoot + "/Image/";
            if (form.Files == null || form.Files[0].Length == 0)
                return RedirectToAction("Index");

            var filename = _imgname + form.Files[0].FileName;
            var name = form.Files[0].Name;
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), storePath,
                        filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await form.Files[0].CopyToAsync(stream);
            }

            Service model = await _context.Services.FindAsync(_Service.ServiceId);
            model.ImagePath = "/Image/" + filename;
            _context.Services.Update(model);
            await _context.SaveChangesAsync();

            return Json(filename);
        }

        [HttpGet("DeleteService/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            POJOMsgs model = new POJOMsgs();
            Service service = new Service();

            try
            {
                Service _services = _context.Services.FirstOrDefault(m => m.ServiceId == id);
                _context.Services.Remove(_services);
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


        //BusinessAddress
        public async Task<IActionResult> BusinessAddresses(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var model = await _context.Services.FindAsync(Id);
            BusinessAddress _BusinessAddress = new BusinessAddress();
            _BusinessAddress.ServiceCategoryId = model.CategoryId;
            _BusinessAddress.ServiceId = model.ServiceId;
            return View(_BusinessAddress);
        }
        [HttpPost]
        public async Task<IActionResult> BusinessAddresses(BusinessAddress _BusinessAddress)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            BusinessAddress _businessAddress = new BusinessAddress();

            if (ModelState.IsValid)
            {

                _businessAddress.PostCode = _BusinessAddress.PostCode;
                _businessAddress.HouseNumber = _BusinessAddress.HouseNumber;
                _businessAddress.Street = _BusinessAddress.Street;
                _businessAddress.City = _BusinessAddress.City;
                _businessAddress.Country = _BusinessAddress.Country;
                _businessAddress.County = _BusinessAddress.County;
                _businessAddress.UserId = currentUserId;
                _businessAddress.Longitute = _BusinessAddress.Longitute;
                _businessAddress.Latitue = _BusinessAddress.Latitue;
                _businessAddress.ServiceCategoryId = _BusinessAddress.ServiceCategoryId;
                _businessAddress.ServiceId = _BusinessAddress.ServiceId;
                _businessAddress.CreateDate = DateTime.Now;
                _businessAddress.UpdateTime = DateTime.Now;

                await _context.AddAsync(_businessAddress);
                await _context.SaveChangesAsync();


                return RedirectToAction("UploadServiceImage", "Services", new { id = _BusinessAddress.ServiceId });
            }
            return View(_BusinessAddress);
        }


        public IActionResult AdminServicePending()
        {
            var _Services = _context.Services.Where(m => m.IsStatus == false);
 

            return View(_Services);
        }

        [HttpGet("ApproveService/{id}")]
        public async Task<IActionResult> ApproveService(int id)
        {
             

            POJOMsgs model = new POJOMsgs();
            try
            {
                Service _service = _context.Services.FirstOrDefault(u => u.ServiceId == id);
                _service.IsStatus = true;
                _context.Services.Update(_service);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = "Has updated services provided by vendor";

            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }


        //Pending Service Offers       
        public IActionResult PendingServiceOffers()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId   

            var result = from e in _context.ServiceOffers.Where(i => i.IsDeleted == false && i.IsStatus == false && i.IsAccepted == false)
                         join ct in _context.Services on e.ServiceId equals ct.ServiceId
                         where (ct.UserId == currentUserId)

                         select new ServiceOffer
                         {
                             Date = e.Date + e.Time,
                             Price = e.Price,
                             Hours = e.Hours,
                             Description = e.Description,
                             ServiceOfferId = e.ServiceOfferId,

                         };

            return View(result);
        }


        // Service Appointments
        public IActionResult MyAppointments()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId  

            if (currentUserId == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var result = from e in _context.ServiceOffers.Where(i => i.IsAccepted == true && i.IsDeleted == false && i.IsStatus == true)
                         join ct in _context.Services on e.ServiceId equals ct.ServiceId
                         where (ct.UserId == currentUserId)

                         select new ServiceOffer
                         {
                             Date = e.Date + e.Time,
                             Price = e.Price,
                             Hours = e.Hours,
                             Description = e.Description,
                             ServiceOfferId = e.ServiceOfferId,
                             ServiceId = e.ServiceId
                         };

            return View(result);
        }


        //Offer
        [HttpPost("/Services/AddServiceOffer")]
        public async Task<IActionResult> AddServiceOffer([FromBody] ServiceOffer _serviceOffer)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId            
            ServiceOffer _service = new ServiceOffer();
            POJOMsgs model = new POJOMsgs();

            if (ModelState.IsValid)
            {
                try
                {
                    _service.ServiceId = _serviceOffer.ServiceId;
                    _service.UserId = currentUserId;
                    _service.Price = _serviceOffer.Price;
                    _service.Hours = _serviceOffer.Hours;
                    _service.Description = _serviceOffer.Description;
                    _service.Date = _serviceOffer.Date;
                    _service.IsAccepted = false;
                    _service.IsDeleted = false;
                    _service.IsStatus = false;
                    _service.Time = _serviceOffer.Time;
                    await _context.ServiceOffers.AddAsync(_service);
                    await _context.SaveChangesAsync();
                    model.Flag = true;
                    model.Msg = "Has been add  service offer";
                }
                catch (Exception e)
                {
                    model.Flag = false;
                    model.Msg = e.ToString();

                }
            }

            // Provider Email
            var _ProverderService = await _context.Services.FindAsync(_serviceOffer.ServiceId);
            var _Provider_User = _userManager.FindByIdAsync(_ProverderService.UserId);
            string Provider_email = _Provider_User.Result.Email;
            string Provider_Phone = _Provider_User.Result.PhoneNumber;

            //Getting the address of the user who has requested service
            var User_Address = _context.Addresses.FirstOrDefault(u => u.UserId == currentUserId);

            var WebSiteName = Request.Host.Value;
            StringBuilder SB_Body = new StringBuilder();
            SB_Body.Append("<p>Offer:</p><p>Description:</p><p>");
            SB_Body.Append(_serviceOffer.Description);
            SB_Body.Append("</p><p>Expected Hours : ");
            SB_Body.Append(_serviceOffer.Hours);
            SB_Body.Append("</p> <p>Appointment DATE and Time :");
            SB_Body.Append(_serviceOffer.Date + _serviceOffer.Time);
            SB_Body.Append("</p> <p>Service Location :");
            SB_Body.Append(User_Address.PostCode);
            SB_Body.Append("</p><p><a  href=//" + WebSiteName + "/Services/AcceptOffer/");
            SB_Body.Append(_service.ServiceOfferId);
            SB_Body.Append("> Accept Offer");
            SB_Body.Append("</p><p><a  href=//" + WebSiteName + "/Services/DeclineServiceOffer/");
            SB_Body.Append(_service.ServiceOfferId);
            SB_Body.Append("> Decline Offer");

            //Send Email
            POJOMsgs modelemail = await SendEmail(SB_Body.ToString(), Provider_email);
            //Send SMS
            string textmsg = "You have Service offer From Vendi, Please check your mail";
            SendSMS(Provider_Phone, textmsg);



            return Json(model);
        }
        //Send SMSMSMSMSMSMSMSM
        public void SendSMS(string ClientMobileNumber, string textmsg)
        {
            var _Setting = _context.Settings.FirstOrDefault();
            string key = _Setting.MobileApiKey;
            string secret = _Setting.MobileApiSecret;
            string name = _Setting.MobileWebsiteName;

            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = key,
                ApiSecret = secret
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = name,
                to = ClientMobileNumber,
                text = textmsg
            });
        }


        [HttpGet("/Services/AcceptOffer/{id}")]
        public async Task<IActionResult> AcceptOffer(int id)
        {
            POJOMsgs model = new POJOMsgs();
            ServiceOffer _serviceOffer = await _context.ServiceOffers.FindAsync(id);
            _serviceOffer.IsAccepted = true;
            _serviceOffer.IsStatus = true;
            _serviceOffer.UpdateTime = DateTime.Now;
            _context.ServiceOffers.Update(_serviceOffer);
            await _context.SaveChangesAsync();

            //Send Email to the User accepted appointed
            ServiceOffer _serviceAccepted = await _context.ServiceOffers.FirstOrDefaultAsync(u => u.ServiceOfferId == id);
            var _User = _userManager.FindByIdAsync(_serviceAccepted.UserId);
            string User_email = _User.Result.Email;
            string User_Phone = _User.Result.PhoneNumber;

            StringBuilder SB_Body = new StringBuilder();
            SB_Body.Append("<p>Your Offer Has Been Accepted</p>");

            POJOMsgs modelemail = await SendEmail(SB_Body.ToString(), User_email);
            model.Msg = "<b style=color:blue;>Your Offer Has Been Accepted</b>";
            model.Flag = true;

            //Send SMS to Client/User
            string textmsg = "Your Offer Has Been Accepted";
            SendSMS(User_Phone, textmsg);

            return Content("<html><body>" + model.Msg + "</body></html>", "text/html");
        }

        //Send to the User Who ask for the service .... Decline Email
        [HttpGet("/Services/DeclineServiceOffer/{id}")]
        public async Task<IActionResult> DeclineServiceOffer(int id)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                ServiceOffer _serviceOffer = await _context.ServiceOffers.FirstOrDefaultAsync(u => u.ServiceOfferId == id);
                var _User = _userManager.FindByIdAsync(_serviceOffer.UserId);
                string User_email = _User.Result.Email;
                string User_Phone = _User.Result.PhoneNumber;
                model.Flag = true;
                model.Msg = "Has updated services provided by vendor";
                StringBuilder SB_Body = new StringBuilder();
                SB_Body.Append("<p>Your Offer Has Been Declined</p>");
                POJOMsgs modelemail = await SendEmail(SB_Body.ToString(), User_email);
                model.Msg = "<b style=color:red;>Your Offer Has Been  Decline</b>";
                model.Flag = true;
                //Update service offer to Isdeleted
                ServiceOffer _ServiceOfferIsDeleted = await _context.ServiceOffers.FindAsync(id);
                _ServiceOfferIsDeleted.IsDeleted = true;
                _serviceOffer.IsStatus = true;
                _ServiceOfferIsDeleted.UpdateTime = DateTime.Now;
                _context.ServiceOffers.Update(_serviceOffer);
                await _context.SaveChangesAsync();
                //Send SMS to Client/User
                string textmsg = "Your Offer Has Been  Declined";
                SendSMS(User_Phone, textmsg);

            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Content("<html><body>" + model.Msg + "</body></html>", "text/html");
        }


        //Email Code
        private async Task<POJOMsgs> SendEmail(string Body, string email)
        {
            POJOMsgs model = new POJOMsgs();
            var Email_Settings = await _context.EmailSettings.FirstOrDefaultAsync();
            string FromEmail = Email_Settings.FromEmail;
            string _UserName = Email_Settings.UserName;
            string _PassWord = Email_Settings.Password;
            string _SMTP = Email_Settings.Smtp;
            int _Port = Email_Settings.Port;
            bool _SSL = Email_Settings.Ssl;         

            try
            {
                SmtpClient client = new SmtpClient(_SMTP);
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(_UserName, _PassWord);
                client.EnableSsl = _SSL;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmail);
                mailMessage.To.Add(email);
                mailMessage.Body = Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Service Offer From Vendi";
                client.Send(mailMessage);
                model.Flag = true;
                model.Msg = "has Been send.";

            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return model; 
        }


       
      



        private string CreatServiceOrderID(string id)
        {

            string _OrderString = "SORD";
            string[] _OderSplit;
            // Order _LastOrder = _context.Orders.OrderByDescending(t => t.OrderId).First();//return the last order only
            _OderSplit = id.Split('D');
            int i = Int32.Parse(_OderSplit[1]);
            i += 1;
            id = _OrderString + i;

            bool IsExist = ServiceOrderExists(id);
            if (IsExist)
            {
                id = CreatServiceOrderID(id);
            }


            return id;
        }
        private bool ServiceOrderExists(string id)
        {
            return _context.ServiceOrders.Any(e => e.ServiceOrderId == id);
        }


         
        public IActionResult ServiceOrderConfirmation(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");//error message 
            }
            ServiceOrder _ServiceOrder = new ServiceOrder();
            _ServiceOrder.ServiceOrderId = id;
            return View(_ServiceOrder);
        }



        //map code 

        private double distance(double lat1, double lon1, double lat2, double lon2)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                dist = dist * 1.609344;
                dist = dist * 1000;
                return (dist);
            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        public double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        public double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        //end map code


        

    }
}
