using System;
namespace AlMarket.DAL.Entities
{
	public class Ingridient :TimeStample
	{
		public string Name { get; set; }

		public string? Description { get; set; }
	}
}

