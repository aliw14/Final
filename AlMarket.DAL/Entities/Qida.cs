using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace AlMarket.DAL.Entities
{
	public class Qida
	{
		public int Id { get; set; }

		public string? ImageUrl { get; set; }

        [MaxLength(150)]

        public string? Description { get; set; }

        [NotMapped]

        public IFormFile Photo { get; set; }

    }
}

