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
    public class KaryeraController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public KaryeraController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var karyera = _dbcontext.Karyeras.ToList();

            KaryeraViewModel viewModel = new KaryeraViewModel
            {
                Karyeras = karyera,
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var karyera = _dbcontext.Karyeras.Find(id);

            if (karyera == null) return NotFound();

            return View(karyera);
        }

        public IActionResult Search( string searchedWork)
        {
            if (string.IsNullOrEmpty(searchedWork)) return NoContent();

            var works = _dbcontext.Karyeras
                .Where(x => x.Heading.ToLower().Contains(searchedWork))
                .ToList();

            return PartialView("_SearchedWork", works);
        }
    }
}
