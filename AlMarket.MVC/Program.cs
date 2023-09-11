using AlMarket.DAL.DataContext;
using AlMarket.DAL.Entities;
using AlMarket.MVC.Areas.AdminPanel.Data;
using AlMarket.MVC.Data;
using AlMarket.MVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace AlMarket.MVC;

public class Program
{


    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Constants.ImagePath = Path.Combine(builder.Environment.WebRootPath, "images");

        builder.Services.AddMvc();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("AlMarket.MVC");
                });
        });

        builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("MailSettings"));

        builder.Services.AddTransient<IMailService, GmailManager>();

        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;

            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddErrorDescriber<LocalizeIdentityError>();

        builder.Services.AddAuthentication()
        .AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = builder.Configuration["Google:ClientId"];
            googleOptions.ClientSecret = builder.Configuration["Google:ClientSecret"];
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var dataInitializer = new DataInitializer(userManager, roleManager, dbContext);
            await dataInitializer.SeeData();
        };

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{Id?}"
        );
            endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
        });


        await app.RunAsync();
    }
}