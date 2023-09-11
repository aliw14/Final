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
    public class QidaController : Controller
    {
        private readonly AppDbContext _dbcontext;

        private readonly int _qidaCount;

        public QidaController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
            _qidaCount = _dbcontext.Qidas.Count();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.QidaCount = _qidaCount;

            var qidas = _dbcontext.Qidas.Take(8).ToList();

            QidaViewModel viewModel = new QidaViewModel
            {
                Qidas = qidas,
            };
            return View(viewModel);
        }

        public IActionResult LoadQida(int skip)
        {
            var qida = _dbcontext.Qidas.Skip(skip).Take(8).ToList();
            return PartialView("_QidaPartial", qida);
        }


    }
}

