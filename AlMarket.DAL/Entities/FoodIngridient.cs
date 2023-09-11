using System;
namespace AlMarket.DAL.Entities
{
	public class FoodIngridient : Entity
	{
		public int FoodId { get; set; }

		public Food Food { get; set; }

		public int IngidientId { get; set; }

		public Ingridient Ingridient { get; set; }
	}
}

