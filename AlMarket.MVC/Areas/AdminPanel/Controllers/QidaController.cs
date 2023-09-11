using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AlMarket.DAL.DataContext;
using AlMarket.DAL.Entities;
using AlMarket.MVC.Areas.AdminPanel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Constants = AlMarket.MVC.Areas.AdminPanel.Data.Constants;
using Files = System.IO.File;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlMarket.MVC.Areas.AdminPanel.Controllers
{
    [Authorize]

    public class QidaController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public QidaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var qidas = await _dbContext.Qidas.ToListAsync();

            return View(qidas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var qida = await _dbContext.Qidas.FindAsync(id);

            if (qida == null)
            {
                return NotFound();
            }

            return View(qida);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Qida qida)
        {
            if (!ModelState.IsValid)

                return View();

            if (!qida.Photo.IsImage())
            {
                ModelState.AddModelError("photo", "Sekil secmelisiniz");
                return View();
            }

            var fileName = await qida.Photo.GenerateFile(Constants.ImagePath);
            qida.ImageUrl = fileName;

            await _dbContext.Qidas.AddAsync(qida);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var qida = await _dbContext.Qidas.FindAsync(id);

            if (qida == null) return NotFound();

            var path = Path.Combine(Data.Constants.ImagePath, qida.ImageUrl);

            if (Files.Exists(path))
            {
                Files.Delete(path);
            }

            _dbContext.Qidas.Remove(qida);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var qida = await _dbContext.Qidas.FindAsync(id);

            if (qida == null) return NotFound();

            return View(qida);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Qida qida)
        {
            if (id == null) return NotFound();

            if (id != qida.Id) return BadRequest();


            var existQida = await _dbContext.Qidas.FindAsync(id);

            existQida.Description = qida.Description;

            var trimmedName = existQida.ImageUrl.Remove(0, 4);
            var pathForDelete = Path.Combine(Constants.ImagePath, trimmedName);

            if (Files.Exists(pathForDelete))
            {
                Files.Delete(pathForDelete);
            }

            var isExist = await _dbContext.Qidas.AnyAsync(x => x.Description.ToUpper() == qida.Description.ToUpper() && x.Id != id);

            if (isExist)
            {
                ModelState.AddModelError("Description", "Bu qida Artıq Mövcuddur");
                return View();
            }

            var path = Path.Combine(Constants.ImagePath);
            var fileName = await qida.Photo.GenerateFile(path);
            existQida.ImageUrl = fileName;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}

