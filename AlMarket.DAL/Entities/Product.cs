using System;
namespace AlMarket.DAL.Entities
{
	public class Product
	{
		public int Id { get; set; }

		public string? ImageUrl { get; set; }

		public string Description { get; set; }

		public int BrandId { get; set; }

		public Brand Brand { get; set; }

	}
}

