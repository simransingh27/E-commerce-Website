using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using getAddress.Sdk;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vendi.App.Data;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Controllers
{  // [Authorize(Roles ="Admin")]
    [Authorize]
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [TempData]
        public string StatusMessage { get; set; }

        public AddressesController(ApplicationDbContext context, UserManager<ApplicationUser> _UserManager)
        {
            _context = context;
            _userManager = _UserManager;
        }

        // GET: Addresses
        public IActionResult Index()
        {
            return View();
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(address);
        }

        // GET: Addresses/Create

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,PostCode,HouseNumber,Street,City,Country,County,UserId,CreateDate,UpdateTime")]  Vendi.Data.Address address)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (ModelState.IsValid)
            {
                Vendi.Data.Address _Address = new Vendi.Data.Address();
                _Address.PostCode = address.PostCode;
                _Address.HouseNumber = address.HouseNumber;
                _Address.Street = address.Street;
                _Address.City = address.City;
                _Address.Country = address.Country;
                _Address.County = address.County;
                _Address.UserId = currentUserId;
                _Address.Longitute = address.Longitute;
                _Address.Latitue = address.Latitue;
                _Address.CreateDate = DateTime.Now;
                _Address.UpdateTime = DateTime.Now;
                _context.Add(_Address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,PostCode,HouseNumber,Street,City,Country,County,UserId,CreateDate,UpdateTime")] Vendi.Data.Address address)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            if (id != address.AddressId)
            {
                return RedirectToAction("Error", "Home");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var _Address = await _context.Addresses.FindAsync(id);
                    _Address.PostCode = address.PostCode;
                    _Address.HouseNumber = address.HouseNumber;
                    _Address.Street = address.Street;
                    _Address.City = address.City;
                    _Address.Country = address.Country;
                    _Address.County = address.County;
                    _Address.UserId = currentUserId;
                    _Address.Longitute = address.Longitute;
                    _Address.Latitue = address.Latitue;
                    _Address.CreateDate = address.CreateDate;
                    _Address.UpdateTime = DateTime.Now;
                    _context.Update(_Address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressId))
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressId == id);
        }

        [HttpPost("/Addresses/GetAddressFromAPI")]
        public async Task<IActionResult> GetAddressFromAPI([FromBody] AddressModelView value)
        {
            //DY8ohx8VvEWX32Fn7P6CWg17324
            Vendi.Data.Address Myaddress = new Vendi.Data.Address();
            var WebsiteSetting = _context.Settings.FirstOrDefault();
            var apiKey = new ApiKey(WebsiteSetting.AddressAPI);

            using (var api = new GetAddesssApi(apiKey))
            {
                var result = await api.Address.Get(new GetAddressRequest(value.PostCode, value.HouseNumber));

                if (result.IsSuccess)
                {
                    var successfulResult = (GetAddressResponse.Success)result;

                    var latitude = successfulResult.Latitude;

                    var Longitude = successfulResult.Longitude;

                    foreach (var address in successfulResult.Addresses)
                    {
                        Myaddress.Street = address.Line1 + " " + address.Line2 + " " + address.Line3 + " " + address.Line4;
                        Myaddress.City = address.TownOrCity;
                        Myaddress.County = address.County;
                        Myaddress.PostCode = value.PostCode;
                        Myaddress.HouseNumber = value.HouseNumber;
                        Myaddress.Country = "UK";
                        Myaddress.Longitute = Longitude;
                        Myaddress.Latitue = latitude;
                    }
                    return Json(Myaddress);
                }
                POJOMsgs model = new POJOMsgs();
                model.Flag = false;
                model.Msg = result.FailedResult.ToString();
                return Json(model);
            }
        }

        [Produces("application/json")]
        [HttpPost("/Addresses/SaveAddress")]
        public async Task<IActionResult> SaveAddress([FromBody] AddressModelView AddressnObj)
        {
            string currentUserId = _userManager.GetUserId(HttpContext.User);//Get UserId
            Vendi.Data.Address _IsUserId = await _context.Addresses.FirstOrDefaultAsync(u => u.UserId == currentUserId);
            POJOMsgs model = new POJOMsgs();
            if (_IsUserId == null)
            {
                Vendi.Data.Address _Address = new Vendi.Data.Address();
                _Address.PostCode = AddressnObj.PostCode;
                _Address.HouseNumber = AddressnObj.HouseNumber;
                _Address.Street = AddressnObj.Street;
                _Address.City = AddressnObj.City;
                _Address.County = AddressnObj.County;
                _Address.Country = AddressnObj.Country;
                _Address.UserId = currentUserId;
                _Address.CreateDate = DateTime.Now;
                _Address.UpdateTime = DateTime.Now;
                _Address.Latitue = AddressnObj.Latitue;
                _Address.Longitute = AddressnObj.Longitute;
                await _context.AddAsync(_Address);
                model.Flag = true;
                model.Msg = "Your Address has been Inserted in database";
                StatusMessage = "Your Address has been Added successfully";
            }
            else
            {
                _IsUserId.PostCode = AddressnObj.PostCode;
                _IsUserId.HouseNumber = AddressnObj.HouseNumber;
                _IsUserId.Street = AddressnObj.Street;
                _IsUserId.City = AddressnObj.City;
                _IsUserId.County = AddressnObj.County;
                _IsUserId.Country = AddressnObj.Country;
                _IsUserId.UserId = currentUserId;
                // _IsUserId.CreateDate = AddressnObj.CreateDate; CheckDB
                _IsUserId.UpdateTime = DateTime.Now;
                _IsUserId.Latitue = AddressnObj.Latitue;
                _IsUserId.Longitute = AddressnObj.Longitute;
                _context.Update(_IsUserId);
                model.Flag = false;
                model.Msg = "Your Address has been updated in database";
                StatusMessage = "Your Address has been Updated successfully";
            }
            await _context.SaveChangesAsync();
            return Json(currentUserId);
        }
    }
}