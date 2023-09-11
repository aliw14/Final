using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AlMarket.DAL.Entities
{
	public class Media
	{
		public int Id { get; set; }

		public string? ImageUrl { get; set; }

		[Required, MaxLength(150)]

		public string? Heading { get; set; }

		public string? Description { get; set; }

		[NotMapped]

		public IFormFile Photo { get; set; }

    }
}

