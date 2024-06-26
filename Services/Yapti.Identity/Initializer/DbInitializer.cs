﻿using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Yapti.Services.Identity.DbContexts;
using Yapti.Services.Identity.Models;
using System.Security.Claims;

namespace Yapti.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void Initialize()
        {
            if (_roleManager.FindByIdAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "88005553535",
                FirstName = "Pyk",
                LastName = "Admin"
            };
            var password = new SqlConnectionStringBuilder()
            {
                UserID = "...",
                Password = "...",
            };
            var item = _userManager.CreateAsync(adminUser, "Admin" + 123).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
               {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName+" "+ adminUser.FirstName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Admin),
               }).GetAwaiter().GetResult();

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer1@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "88005553535",
                FirstName = "Pyks",
                LastName = "customer"
            };

            _userManager.CreateAsync(customerUser, "Customer123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
               {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName+" "+ adminUser.FirstName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Customer),
               }).GetAwaiter().GetResult();

        }
    }
}
