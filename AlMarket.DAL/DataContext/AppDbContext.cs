using System;
using AlMarket.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlMarket.DAL.DataContext
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Food> Foods { get; set; }

		public DbSet<Ingridient> Ingridients { get; set; }

		public DbSet<FoodIngridient> FoodIngridients { get; set; }

		public DbSet<Footer> Footers { get; set; }

		public DbSet<Elaqe> Elaqes { get; set; }

		public DbSet<Haqqimizda> Haqqimizdas { get; set; }

		public DbSet<Links> Links { get; set; }

		public DbSet<SocialNetwork> SocialNetworks { get; set; }

		public DbSet<Teklifler> Tekliflers { get; set; }

        public DbSet<SliderImage> SliderImages { get; set; }

		public DbSet<Media> Medias { get; set; }

		public DbSet<Brand> Brands { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Header> Headers { get; set; }

		public DbSet<Navbar>Navbars { get; set; }

		public DbSet<Market> Markets { get; set; }

		public DbSet<Huquq> Huquqs { get; set; }

		public DbSet<Catalog> Catalogs { get; set; }

		public DbSet<Kimik> Kimiks { get; set; }

		public DbSet<Karyera> Karyeras { get; set; }

		public DbSet<BizeYazin> BizeYazins { get; set; }

		public DbSet<Qida> Qidas { get; set; }

		public DbSet<QeyriQida> QeyriQidas { get; set; }

		public DbSet<TestEntity> TestEntities { get; set; }

    }
}

