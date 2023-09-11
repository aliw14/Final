using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AlMarket.DAL.Entities
{
	public class Catalog
	{
		public int Id { get; set; }

		public string? ImageUrl { get; set; }

        [NotMapped]

        public IFormFile Photo { get; set; }

    }
}

