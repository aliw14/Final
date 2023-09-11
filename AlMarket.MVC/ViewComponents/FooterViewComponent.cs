using System;
using AlMarket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlMarket.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public FooterViewComponent(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _dbcontext.Footers.Include(x => x.Elaqes).Include(x => x.Haqqimizdas).Include(x => x.Tekliflers).Include(x => x.Links).Include(x => x.SocialNetworks).FirstOrDefault();

            return View(footer);
        }
    }
}

