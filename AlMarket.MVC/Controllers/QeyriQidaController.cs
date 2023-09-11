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
    public class QeyriQidaController : Controller
    {
        private readonly AppDbContext _dbcontext;

        private readonly int _qeyriqidaCount;

        public QeyriQidaController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
            _qeyriqidaCount = _dbcontext.QeyriQidas.Count();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.QeyriQidaCount = _qeyriqidaCount;

            var qeyriQidas = _dbcontext.QeyriQidas.Take(8).ToList();

            QeyriQidaViewModel viewModel = new QeyriQidaViewModel
            {
                QeyriQidas = qeyriQidas,
            };
            return View(viewModel);
        }

        public IActionResult LoadQeyriQida(int skip)
        {

            var qeyriqida = _dbcontext.QeyriQidas.Skip(skip).Take(8).ToList();

            return PartialView("_QeyriQidaPartial", qeyriqida);
        }

    }
}

