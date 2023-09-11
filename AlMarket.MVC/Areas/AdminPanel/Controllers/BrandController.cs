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

    public class BrandController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public BrandController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var brands = await _dbContext.Brands.ToListAsync();

            return View(brands);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var brands = await _dbContext.Brands.FindAsync(id);

            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            ModelState.Clear();

            if (!ModelState.IsValid)
                return View();

            if (!brand.Photo.IsImage())
            {
                ModelState.AddModelError("photo", "Sekil secmelisiniz");
                return View();
            }

            var fileName = await brand.Photo.GenerateFile(Constants.ImagePath);

            brand.ImageUrl = fileName;

            await _dbContext.Brands.AddAsync(brand);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var brand = await _dbContext.Brands.FindAsync(id);

            if (brand == null) return NotFound();

            var path = Path.Combine(Data.Constants.ImagePath, brand.ImageUrl);

            if (Files.Exists(path))
            {
                Files.Delete(path);
            }

            _dbContext.Brands.Remove(brand);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var brand = await _dbContext.Brands.FindAsync(id);

            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand)
        {
            if (id == null) return NotFound();

            if (id != brand.Id) return BadRequest();


            var existBrand = await _dbContext.Brands.FindAsync(id);

            var trimmedName = existBrand.ImageUrl.Remove(0, 4);
            var pathForDelete = Path.Combine(Constants.ImagePath, trimmedName);

            if (Files.Exists(pathForDelete))
            {
                Files.Delete(pathForDelete);
            }

            var path = Path.Combine(Constants.ImagePath);
            var fileName = await brand.Photo.GenerateFile(path);
            existBrand.ImageUrl = fileName;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

