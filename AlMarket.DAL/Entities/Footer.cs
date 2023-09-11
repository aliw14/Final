using System;
namespace AlMarket.DAL.Entities
{
	public class Footer
	{
		public int Id { get; set; }

		public string CreatedBy { get; set; }

        public ICollection<Elaqe> Elaqes { get; set; }

		public ICollection<Haqqimizda> Haqqimizdas { get; set; }

		public ICollection<Links> Links { get; set; }

		public ICollection<SocialNetwork> SocialNetworks { get; set; }

		public ICollection<Teklifler> Tekliflers { get; set; }

    }
}

