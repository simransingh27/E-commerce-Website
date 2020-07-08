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
    public class CPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CPController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }
        public IActionResult Index()
        {
            CPModelView model = new CPModelView();
            model.NumberOfUsers = _context.Users.Count();
            model.NumberOfProducts = _context.Products.Count();
            model.NumberOfServices = _context.Services.Count();
            model.NumberOfPendingProducts = _context.Products.Where(p => p.IsStatus == true).Count();
            model.NumberOfPendingServices = _context.Services.Where(s => s.IsStatus == true).Count();
            model.NumberOfOrders = _context.Orders.Count();
            model.Last10Orders = (from p in _context.Orders orderby p.CreateDate descending select p).Take(10);
            model.Top10Services= (from s in _context.Services orderby s.CreateDate descending select s).Take(10);

            return View(model);
        }


        public async Task<IActionResult> BankTransactions()
        {
            return View(await _context.BankTransactions.ToListAsync());
        }

        [HttpGet("/CP/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            POJOMsgs model = new POJOMsgs();
            try
            {
                ApplicationUser _User = await _context.Users.FindAsync(id);
                _context.Users.Remove(_User);
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

        public IActionResult AllUsers()
        {
            IQueryable<ApplicationUser> model = _context.Users;
            return View(model);
        }

        public IActionResult ServiceAdminIndex()
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
                                                      IsFeatured = e.IsFeatured
                                                  };
            return View(result);
        }

        public IActionResult AdminProductPending()
        {
            var product = _context.Products.Where(m => m.IsStatus == false);

            if (product == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(product);
        }

        //for Email Settings
        public async Task<IActionResult> WebsiteEmailSettings()
        {
            EmailSetting _EmailSetting = await _context.EmailSettings.FirstOrDefaultAsync();
            return View(_EmailSetting);
        }

        [HttpPost]
        public async Task<IActionResult> WebsiteEmailSettings(EmailSetting _EmailSettingData)
        {
            if (_EmailSettingData == null)
            {
                return RedirectToAction("Error", "Home");
            }
            string currentUserId = _userManager.GetUserId(HttpContext.User); //Get UserId
            EmailSetting _EmailSettingCheck = await _context.EmailSettings.FirstOrDefaultAsync();

            if (_EmailSettingCheck == null)
            {
                EmailSetting _EmailSetting = new EmailSetting();
                _EmailSetting.FromEmail = _EmailSettingData.FromEmail;
                _EmailSetting.UserName = _EmailSettingData.UserName;
                _EmailSetting.Password = _EmailSettingData.Password;
                _EmailSetting.Smtp = _EmailSettingData.Smtp;
                _EmailSetting.Port = _EmailSettingData.Port;
                _EmailSetting.Ssl = _EmailSettingData.Ssl;
                _EmailSetting.UserId = currentUserId;
                _EmailSetting.CreateDate = DateTime.Now;
                _EmailSetting.UpdateDate = DateTime.Now;
                await _context.EmailSettings.AddAsync(_EmailSetting);
                await _context.SaveChangesAsync();
                return View(_EmailSetting);
            }
            else
            {
                _EmailSettingCheck.FromEmail = _EmailSettingData.FromEmail;
                _EmailSettingCheck.UserName = _EmailSettingData.UserName;
                _EmailSettingCheck.Password = _EmailSettingData.Password;
                _EmailSettingCheck.Smtp = _EmailSettingData.Smtp;
                _EmailSettingCheck.Port = _EmailSettingData.Port;
                _EmailSettingCheck.Ssl = _EmailSettingData.Ssl;
                _EmailSettingCheck.UpdateDate = DateTime.Now;
                _EmailSettingCheck.UserId = currentUserId;
                _context.EmailSettings.Update(_EmailSettingCheck);
                await _context.SaveChangesAsync();
                return View(_EmailSettingCheck);
            }
        }

        public async Task<IActionResult> AdminSettings()
        {
            Setting _Setting = await _context.Settings.FirstOrDefaultAsync();
            return View(_Setting);
        }

        //for settings
        [HttpPost]
        public async Task<IActionResult> AdminSettings(Setting _settingdata)
        {
            if (_settingdata == null)
            {
                return RedirectToAction("Error", "Home");
            }

            string currentUserId = _userManager.GetUserId(HttpContext.User); //Get UserId
            Setting _SettingCheck = await _context.Settings.FirstOrDefaultAsync();

            if (_SettingCheck == null)
            {
                Setting _settingAdd = new Setting();
                _settingAdd.AddressAPI = _settingdata.AddressAPI;
                _settingAdd.GoogleAPI = _settingdata.GoogleAPI;
                _settingAdd.PaymentAPI = _settingdata.PaymentAPI;
                _settingAdd.MobileApiKey = _settingdata.MobileApiKey;
                _settingAdd.MobileApiSecret = _settingdata.MobileApiSecret;
                _settingAdd.MobileWebsiteName = _settingdata.MobileWebsiteName;
                _settingAdd.UserId = currentUserId;
                _settingAdd.CreateDate = DateTime.Now;
                _settingAdd.UpdateDate = DateTime.Now;
                await _context.Settings.AddAsync(_settingAdd);
                await _context.SaveChangesAsync();
                return View(_settingAdd);
            }
            else
            {
                _SettingCheck.SettingId = _settingdata.SettingId;
                _SettingCheck.AddressAPI = _settingdata.AddressAPI;
                _SettingCheck.GoogleAPI = _settingdata.GoogleAPI;
                _SettingCheck.PaymentAPI = _settingdata.PaymentAPI;
                _SettingCheck.MobileApiKey = _settingdata.MobileApiKey;
                _SettingCheck.MobileApiSecret = _settingdata.MobileApiSecret;
                _SettingCheck.MobileWebsiteName = _settingdata.MobileWebsiteName;
                _SettingCheck.UserId = currentUserId;
                _context.Settings.Update(_SettingCheck);
                await _context.SaveChangesAsync();
                return View(_SettingCheck);
            }
        }
    }
}