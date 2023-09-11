using System.Linq;
using AlMarket.DAL.DataContext;
using AlMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlMarket.MVC.Controllers
{
    public class MehsullarController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MehsullarController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var brands = _dbContext.Brands.ToList();
            var viewModel = new MehsularViewModel
            {
                Brands = brands,
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var products = _dbContext.Products.Where(x => x.BrandId == id).ToList();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return View(products);
        }
    }
}
