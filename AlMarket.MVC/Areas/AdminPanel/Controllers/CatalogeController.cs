using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlMarket.DAL.DataContext;
using AlMarket.DAL.Entities;
using AlMarket.MVC.Areas.AdminPanel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Constants = AlMarket.MVC.Areas.AdminPanel.Data.Constants;
using Files = System.IO.File;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlMarket.MVC.Areas.AdminPanel.Controllers
{
    [Authorize]

    public class CatalogeController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public CatalogeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var cataloges = await _dbContext.Catalogs.ToListAsync();

            return View(cataloges);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var cataloges = await _dbContext.Catalogs.FindAsync(id);

            if (cataloges == null)
            {
                return NotFound();
            }

            return View(cataloges);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Catalog cataloge)
        {
            if (!ModelState.IsValid)

                return View();

            if (!cataloge.Photo.IsImage())
            {
                ModelState.AddModelError("photo", "Sekil secmelisiniz");
                return View();
            }

            var fileName = await cataloge.Photo.GenerateFile(Constants.ImagePath);

            cataloge.ImageUrl = fileName;

            await _dbContext.Catalogs.AddAsync(cataloge);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cataloge = await _dbContext.Catalogs.FindAsync(id);

            if (cataloge == null) return NotFound();

            var path = Path.Combine(Data.Constants.ImagePath, cataloge.ImageUrl);

            if (Files.Exists(path))
            {
                Files.Delete(path);
            }

            _dbContext.Catalogs.Remove(cataloge);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var cataloge = await _dbContext.Catalogs.FindAsync(id);

            if (cataloge == null) return NotFound();

            return View(cataloge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Catalog catalog)
        {
            if (id == null) return NotFound();

            if (id != catalog.Id) return BadRequest();


            var existCatalog = await _dbContext.Catalogs.FindAsync(id);

            var trimmedName = existCatalog.ImageUrl.Remove(0, 4);
            var pathForDelete = Path.Combine(Constants.ImagePath, trimmedName);

            if (Files.Exists(pathForDelete))
            {
                Files.Delete(pathForDelete);
            }

            var path = Path.Combine(Constants.ImagePath);
            var fileName = await catalog.Photo.GenerateFile(path);
            existCatalog.ImageUrl = fileName;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

