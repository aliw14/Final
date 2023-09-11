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

    public class MediaController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public MediaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var medias = await _dbContext.Medias.ToListAsync();

            return View(medias);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var media = await _dbContext.Medias.FindAsync(id);

            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Media media)
        {
            if (!ModelState.IsValid)

                return View();

            if (!media.Photo.IsImage()) 
            {
                ModelState.AddModelError("photo", "Sekil secmelisiniz");
                return View();
            }

            var fileName = await media.Photo.GenerateFile(Constants.ImagePath);

            media.ImageUrl = fileName;

            await _dbContext.Medias.AddAsync(media);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var media = await _dbContext.Medias.FindAsync(id);

            if (media == null) return NotFound();

            var path = Path.Combine(Data.Constants.ImagePath, media.ImageUrl);

            if (Files.Exists(path))
            {
                Files.Delete(path);
            }

            _dbContext.Medias.Remove(media);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var media = await _dbContext.Medias.FindAsync(id);

            if (media == null) return NotFound();

            return View(media);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Media media)
        {
            if (id == null) return NotFound();

            if (id != media.Id) return BadRequest();


            var existMedia = await _dbContext.Medias.FindAsync(id);

            existMedia.Heading = media.Heading;

            existMedia.Description = media.Description;

            var trimmedName = existMedia.ImageUrl.Remove(0, 4);
            var pathForDelete = Path.Combine(Constants.ImagePath, trimmedName);

            if (Files.Exists(pathForDelete))
            {
                Files.Delete(pathForDelete);
            }

            var isExist = await _dbContext.Medias.AnyAsync(x => x.Heading.ToUpper() == media.Heading.ToUpper() && x.Id != id);

            if (isExist)
            {
                ModelState.AddModelError("Heading", "Bu media Artıq Mövcuddur");
                return View();
            }

            var path = Path.Combine(Constants.ImagePath);
            var fileName = await media.Photo.GenerateFile(path);
            existMedia.ImageUrl = fileName;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

