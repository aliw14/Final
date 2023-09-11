using System;
using AlMarket.DAL.Entities;

namespace AlMarket.MVC.ViewModels
{
	public class HomeViewModel
	{
		public List<SliderImage>? SliderImages { get; set; }

		public List<Brand> Brands { get; set; }

		public List<Product> Products { get; set; }

		public List<Catalog> Catalogs { get; set; }

    }
}

