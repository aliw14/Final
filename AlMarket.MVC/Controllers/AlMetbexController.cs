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
    public class AlMetbexController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public AlMetbexController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var foods = _dbcontext.Foods.ToList();

            AlMetbexViewModel viewModel = new AlMetbexViewModel
            {
                Foods = foods,
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var foods = _dbcontext.Foods.Find(id);

            if (foods == null) return NotFound();

            return View(foods);
        }

        public IActionResult Search(string searchedFood)
        {
            if (string.IsNullOrEmpty(searchedFood)) return NoContent();

            var food = _dbcontext.Foods
                .Where(x => x.Name.ToLower().Contains(searchedFood))
                .ToList();

            return PartialView("_SearchedFood", food);
        }
    }
}

