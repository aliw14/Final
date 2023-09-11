using System;
using AlMarket.DAL.DataContext;
using AlMarket.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlMarket.MVC.Data
{
	public class DataInitializer
	{
		private UserManager<AppUser> _userManager;
		private RoleManager<IdentityRole> _roleManager;
		private AppDbContext _dbContext;

        public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task SeeData()
        {
            await _dbContext.Database.MigrateAsync();

            var roles = new List<string> { RoleConstants.AdminRole, RoleConstants.ModeratorRole };

            foreach (var role in roles)
            {
                var existRole = await _roleManager.FindByNameAsync(role);

                if (existRole != null)
                    continue;

                var roleResult = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = role

                });

                if (roleResult.Succeeded)
                {
                    //logging
                }

            }
            var existUser = await _userManager.FindByNameAsync("Admin");

            if (existUser != null)
            {
                return;
            }
            var user = new AppUser
            {
                UserName = "Admin",
                Email = "Admin@code"
            };

            var result = await _userManager.CreateAsync(user, "123456");

            if (!result.Succeeded)
            {
                //logging
            }

            result = await _userManager.AddToRoleAsync(user, RoleConstants.AdminRole);

            if (!result.Succeeded)
            {
                //logging
            }
        }
    }
}

