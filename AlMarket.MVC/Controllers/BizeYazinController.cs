using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlMarket.DAL.DataContext;
using AlMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlMarket.MVC.Controllers
{
    public class BizeYazinController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public BizeYazinController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var yazin = _dbcontext.BizeYazins.Include(x=>x.Links).Include(x=>x.SocialNetworks).FirstOrDefault();

            return View(yazin);
        }
    }
}

