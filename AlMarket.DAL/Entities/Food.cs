using System;
namespace AlMarket.DAL.Entities
{
	public class Food : TimeStample
	{
		public string Name { get; set; }

		public string? Description { get; set; }

		public string? ImageUrl { get; set; }
	}
}

