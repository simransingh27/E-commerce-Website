using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexmo.Api;
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;
using Worldpay.Sdk;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;


namespace Vendi.App.Controllers
{
    public class PaymentController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
      

        public PaymentController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Payment/PayProductByCash")]
        public async Task<IActionResult> PayProductByCash([FromBody] CheckoutValueModelView _CheckOut)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                Order _Order = await _context.Orders.FindAsync(_CheckOut.OrderId);
                _Order.IsPaid = true;
                _Order.PaymentMethod = 1;///1 COD 2 online
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = _Order.OrderId.ToString();//to confirm page
            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            return Json(model);
        }

        //Will get the ordId
        [HttpPost("/Payment/PayProductByCard")]
        public async Task<IActionResult> PayProductByCard([FromBody] CheckOutModelView data)
        {
            POJOMsgs POJOModel = new POJOMsgs();
           
                //string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
                //var _User = _userManager.FindByIdAsync(currentUserId);
                //string _Email = _User.Result.Email;
                //string _Phone = _User.Result.PhoneNumber;
                //string _FirstName = _User.Result.FirstName;
                //string _LastName = _User.Result.LastName;

               
                //Address _Address = await _context.Addresses.FirstOrDefaultAsync(i => i.UserId == currentUserId);
                //CheckOutModelView model = new CheckOutModelView();

                //model.FirstName = _FirstName;
                //model.LastName = _LastName;
                //model.Email = _Email;
                //model.Street = _Address.HouseNumber + ", " + _Address.Street + " " + _Address.Country + ", " + _Address.County;
                //model.Country = _Address.Country;
                //model.County = _Address.County;
                //model.City = _Address.City;
                //model.PostCode = _Address.PostCode;
                //model.Mobile = _Phone;
                //model.OrderId = data.OrderId;
                //model.TotalOrder = _Order.Total;

                WorldpayRestClient restClient = new WorldpayRestClient("https://api.worldpay.com/v1", "T_S_bad143a9-6c5d-4cc5-944a-d182f911acc0");
            //Converting to duoble
            int? _amount = 0;
            if (!string.IsNullOrEmpty(data.TotalOrder.ToString()))
            {
                double n;
                bool isNumeric = double.TryParse(data.TotalOrder.ToString(), out n);
                _amount = isNumeric ? (int)(Convert.ToDecimal(data.TotalOrder.ToString()) * 100) : -1;
            }

            OrderRequest orderRequest = new OrderRequest()
            {
                    token = data.Token,
                    amount = _amount,
                   // currencyCode = Enum.Parse(typeof(CurrencyCode), "GBP").ToString(),
                    currencyCode = "GBP",
                    name = data.FirstName + data.LastName,
                    orderDescription = string.IsNullOrEmpty(data.Comment) ? "No Comment" : data.Comment,
                    customerOrderCode = data.OrderId.ToString(),
                    shopperEmailAddress=data.Email                     
                };

                Worldpay.Sdk.Models.Address address = new Worldpay.Sdk.Models.Address()
                {
                    address1 = data.Street,
                    address2 = data.Country,
                    city = data.City,
                   // countryCode = Enum.Parse(typeof(CountryCode), "GB").ToString(),
                    countryCode = "GB",
                    postalCode = data.PostCode,
                    telephoneNumber=data.Mobile,
                    state=data.County      
                };
                orderRequest.billingAddress = address;
                try
                {
                 OrderResponse orderResponse = restClient.GetOrderService().Create(orderRequest);
                 
                 Order _Order = await _context.Orders.FindAsync(data.OrderId);

                try { 
                _Order.IsPaid = true;
                _Order.PaymentMethod = 2;//paid by card
                _Order.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                }catch(Exception e)
                {
                    POJOModel.Flag = false;
                    POJOModel.Msg = e.ToString();
                }
                POJOModel.Flag = true;
                POJOModel.Msg =_Order.OrderId.ToString();
                //Create Trans Record
                string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
                BankTransaction _BankTransaction = new BankTransaction();
                _BankTransaction.TransactionId = orderResponse.orderCode;
                _BankTransaction.UserId = currentUserId;
                _BankTransaction.OrderId = orderResponse.customerOrderCode;
                _BankTransaction.Amount = data.TotalOrder;
                _BankTransaction.Status = orderResponse.paymentStatus.ToString();
                _BankTransaction.Date = DateTime.Now;
                _BankTransaction.FullName = orderResponse.paymentResponse.name;
                await _context.AddAsync(_BankTransaction);
                await _context.SaveChangesAsync();


            }
                catch (WorldpayException e)
                {
                POJOModel.Flag = false;
                POJOModel.Msg = " Error code:" + e.apiError.customCode +" Error description: " + e.apiError.description+ " Error message: " + e.apiError.message;
                
               }
            return Json(POJOModel);             
                //after change the  order Ispaid method of payment 2 online   
        }



        /// <summary>
        /// Services part
        /// </summary>
        /// <returns></returns>
        public IActionResult PendingServicePayments()
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId

            if (currentUserId == null)
            {
                return RedirectToAction("Error", "Home");
            }
            IQueryable<ServiceOrderModelView> _ServiceOrder = from e in _context.ServiceOrders.Where(p => p.IsPaid == false && p.UserId == currentUserId)
                                                              join s in _context.Services on e.ServiceId equals s.ServiceId
                                                              select new ServiceOrderModelView
                                                              {
                                                                  ServiceName = s.ServiceName,
                                                                  ServiceId = e.ServiceId,
                                                                  TotalAmount = e.TotalAmount,
                                                                  CreateDate = e.CreateDate,
                                                                  ServiceOrderId = e.ServiceOrderId
                                                              };
            return View(_ServiceOrder);
        }

        public async Task<IActionResult> ServiceMakePayment(string id)
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
            //Customer Details
            var _User = _userManager.FindByIdAsync(currentUserId);
            string _Email = _User.Result.Email;
            string _Phone = _User.Result.PhoneNumber;
            string _FirstName = _User.Result.FirstName;
            string _LastName = _User.Result.LastName;



            ServiceOrder _ServiceOrder = await _context.ServiceOrders.FindAsync(id);
            Vendi.Data.Address _Address = await _context.Addresses.FirstOrDefaultAsync(i => i.UserId == currentUserId);
            ServiceCheckOutModelView model = new ServiceCheckOutModelView();

            Service _ServiceProvider =await _context.Services.FindAsync(_ServiceOrder.ServiceId);
           


            model.FirstName = _FirstName;
            model.LastName = _LastName;
            model.Email = _Email;
            model.Street = _Address.HouseNumber + ", " + _Address.Street + " " + _Address.Country + ", " + _Address.County;
            model.Country = _Address.Country;
            model.County = _Address.County;
            model.City = _Address.City;
            model.PostCode = _Address.PostCode;
            model.Mobile = _Phone;
            model.ServiceOrderId = id;
            model.TotalOrder = _ServiceOrder.TotalAmount;
            model.Comment ="Payment goes  to "+ _ServiceProvider.ServiceName;

            return View(model);
            //IQueryable<ServiceOrderModelView> _ServiceOrder = from e in _context.ServiceOrders.Where(i => i.ServiceOrderId == id)
            //                                                  join s in _context.Services on e.ServiceId equals s.ServiceId
            //                                                  select new ServiceOrderModelView
            //                                                  {
            //                                                      ServiceName = s.ServiceName,
            //                                                      ServiceId = e.ServiceId,
            //                                                      TotalAmount = e.TotalAmount,
            //                                                      CreateDate = e.CreateDate,
            //                                                      ServiceOrderId = e.ServiceOrderId
            //                                                  };
            //ServiceOrderModelView _ServiceOrderById = await _ServiceOrder.FirstOrDefaultAsync();
            // return View(_ServiceOrderById);




        }



        //payment cod service
        [HttpPost("/Payment/PayServiceByCash")]
        public async Task<IActionResult> PayServiceByCash([FromBody]ServicePaymentModelView data)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                ServiceOrder _ServiceOrder = await _context.ServiceOrders.FindAsync(data.ServiceOrderId);

                _ServiceOrder.IsPaid = true;//Means Payed
               _ServiceOrder.PaymentMethod = 1; // Cash Payement
                _ServiceOrder.UpdateDate = DateTime.Now;
                _context.ServiceOrders.Update(_ServiceOrder);
                await _context.SaveChangesAsync();
                model.Flag = true;
                model.Msg = _ServiceOrder.ServiceOrderId.ToString();
                //Send Email and SMS to Vendor Confirmating the payment made by the client for the service
                var _ProverderService = _context.Services.Where(i => i.ServiceId == _ServiceOrder.ServiceId).FirstOrDefault();
                var _Provider_User = _userManager.FindByIdAsync(_ProverderService.UserId);
                string Provider_email = _Provider_User.Result.Email;
                string Provider_Phone = _Provider_User.Result.PhoneNumber;
                StringBuilder SB_Body = new StringBuilder();
                SB_Body.Append("<p>Your Payment Has Been Made</p>");
                POJOMsgs modelemail = await SendEmail(SB_Body.ToString(), Provider_email);
                string textmsg = "Your Payment Has Been Made";
                SendSMS(Provider_Phone, textmsg);
            }
            catch (Exception e)
            {
                model.Flag = false;
                model.Msg = e.ToString();
            }
            //send email pass been paid to Vendor....
            return Json(model);
        }
        //Pay Serivvce By Card
        [HttpPost("/Payment/PayServiceByCard")]
        public async Task<IActionResult> PayServiceByCard([FromBody] ServiceCheckOutModelView data)
        {
            POJOMsgs POJOModel = new POJOMsgs();


            WorldpayRestClient restClient = new WorldpayRestClient("https://api.worldpay.com/v1", "T_S_bad143a9-6c5d-4cc5-944a-d182f911acc0");
            //Converting to duoble
            int? _amount = 0;
            if (!string.IsNullOrEmpty(data.TotalOrder.ToString()))
            {
                double n;
                bool isNumeric = double.TryParse(data.TotalOrder.ToString(), out n);
                _amount = isNumeric ? (int)(Convert.ToDecimal(data.TotalOrder.ToString()) * 100) : -1;
            }

            OrderRequest orderRequest = new OrderRequest()
            {
                token = data.Token,
                amount = _amount,
                // currencyCode = Enum.Parse(typeof(CurrencyCode), "GBP").ToString(),
                currencyCode = "GBP",
                name = data.FirstName + data.LastName,
                orderDescription = string.IsNullOrEmpty(data.Comment) ? "No Comment" : data.Comment,
                customerOrderCode = data.ServiceOrderId.ToString(),
                shopperEmailAddress = data.Email
            };

            Worldpay.Sdk.Models.Address address = new Worldpay.Sdk.Models.Address()
            {
                address1 = data.Street,
                address2 = data.Country,
                city = data.City,
                // countryCode = Enum.Parse(typeof(CountryCode), "GB").ToString(),
                countryCode = "GB",
                postalCode = data.PostCode,
                telephoneNumber = data.Mobile,
                state = data.County
            };
            orderRequest.billingAddress = address;
            try
            {
                OrderResponse orderResponse = restClient.GetOrderService().Create(orderRequest);

                ServiceOrder _ServiceOrder = await _context.ServiceOrders.FindAsync(data.ServiceOrderId);

                try
                {
                    _ServiceOrder.IsPaid = true;
                    _ServiceOrder.PaymentMethod = 2;//paid by card
                    _ServiceOrder.UpdateDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    POJOModel.Flag = false;
                    POJOModel.Msg = e.ToString();
                }
                POJOModel.Flag = true;
                POJOModel.Msg = _ServiceOrder.ServiceOrderId.ToString();


                //Create Trans Record
                string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
                BankTransaction _BankTransaction = new BankTransaction();
                _BankTransaction.TransactionId = orderResponse.orderCode;
                _BankTransaction.UserId = currentUserId;
                _BankTransaction.OrderId = orderResponse.customerOrderCode;
                _BankTransaction.Amount = data.TotalOrder;
                _BankTransaction.Status = orderResponse.paymentStatus.ToString();
                _BankTransaction.Date = DateTime.Now;
                _BankTransaction.FullName = orderResponse.paymentResponse.name;
                await _context.AddAsync(_BankTransaction);
                await _context.SaveChangesAsync();



            }
            catch (WorldpayException e)
            {
                POJOModel.Flag = false;
                POJOModel.Msg = " Error code:" + e.apiError.customCode + " Error description: " + e.apiError.description + " Error message: " + e.apiError.message;

            }
            return Json(POJOModel);

            
        }
        //Emaill

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



    }


}