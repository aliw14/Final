using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AlMarket.DAL.Entities
{
	public class Brand
	{
		[Key]

		public int Id { get; set; }

		public string? ImageUrl { get; set; }

		public List<Product> Products { get; set; }

        [NotMapped]

        public IFormFile Photo { get; set; }

    }
}