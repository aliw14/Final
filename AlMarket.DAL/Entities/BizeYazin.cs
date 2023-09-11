using System;
namespace AlMarket.DAL.Entities
{
	public class BizeYazin
	{
		public int Id { get; set; }

		public string Heading { get; set; }

		public string Description { get; set; }

		public ICollection<SocialNetwork> SocialNetworks { get; set; }

		public ICollection<Links> Links { get; set; }

	}
}

