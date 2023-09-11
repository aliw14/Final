using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlMarket.DAL.DataContext;
using AlMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlMarket.MVC.Controllers
{
    public class KimikController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public KimikController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var kimik = _dbcontext.Kimiks.ToList();

            KimikViewModel viewModel = new KimikViewModel
            {
                Kimiks = kimik
            };
            return View(viewModel);
        }
    }
}

