using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlMarket.DAL.DataContext;
using AlMarket.MVC.Data;
using AlMarket.MVC.Services;
using AlMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace AlMarket.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _dbcontext;
        private readonly IMailService _mailServie;

        public HomeController(AppDbContext appdbContext, IMailService mailServie)
        {
            _dbcontext = appdbContext;
            _mailServie = mailServie;
        }

        public IActionResult Index()
        {
            Response.Cookies.Append("a", "test1");
            Response.Cookies.Append("b", "test2");

            _mailServie.SendEmailAsync(new RequestEmail
            {
                ToEmail = "Aligm@code.edu.az",
                Subject = "Lesson",
                Body = "Hello from lesson"
            });

            var slider = _dbcontext.SliderImages.ToList();

            var product = _dbcontext.Products.ToList();

            var catalog = _dbcontext.Catalogs.ToList();

            var brand = _dbcontext.Brands.ToList();

            HomeViewModel viewModel = new HomeViewModel
            {
                SliderImages = slider,
                Products=product,
                Catalogs=catalog,
                Brands=brand
            };

            return View(viewModel);
        }
    }
}

