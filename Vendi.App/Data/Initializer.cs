using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendi.App.Data
{
    public  class Initializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public Initializer(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        //Alaeddin 
        //Add the main roles to the db
        public   async Task Initial ()
        {
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                var _Admin = new IdentityRole("Admin");
               await _roleManager.CreateAsync(_Admin);
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var _User = new IdentityRole("User");
                await _roleManager.CreateAsync(_User);
            }
            if (!await _roleManager.RoleExistsAsync("Vendor"))
            {
                var _Vendor = new IdentityRole("Vendor");
                await _roleManager.CreateAsync(_Vendor);
            }
        }
    }
}
