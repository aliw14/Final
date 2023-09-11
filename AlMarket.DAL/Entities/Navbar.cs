using System;
namespace AlMarket.DAL.Entities
{
	public class Navbar
	{
		public int Id { get; set; }

		public string Nav { get; set; }

		public ICollection<Haqqimizda> Haqqimizdas { get; set; }

		public ICollection<Teklifler> Tekliflers { get; set; }

		public ICollection<Elaqe> Elaqes { get; set; }

		public ICollection<Footer> Footers { get; set; }
	}
}

