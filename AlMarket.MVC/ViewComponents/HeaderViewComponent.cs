using System;
using AlMarket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlMarket.MVC.ViewComponents
{
	public class HeaderViewComponent : ViewComponent
	{
        private readonly AppDbContext _dbcontext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var header = _dbcontext.Headers.Include(x => x.Navbars).Include(x=>x.Footers).Include(x => x.Elaqes).Include(x => x.Haqqimizdas).Include(x => x.Tekliflers).FirstOrDefault();

            return View(header);
        }
    }
}

