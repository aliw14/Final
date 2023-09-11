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
    public class MediaController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public MediaController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var media = _dbcontext.Medias.ToList();

            MediaViewModel viewModel = new MediaViewModel
            {
                Medias = media,
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var media = _dbcontext.Medias.Find(id);

            if (media == null) return NotFound();

            return View(media);
        }
    }
}

