using System;
namespace AlMarket.DAL.Entities
{
	public class Header
	{
		public int Id { get; set; }

		public string? ImageUrl { get; set; }

		public ICollection<Navbar> Navbars { get; set; }

		public ICollection<Footer> Footers { get; set; }

        public ICollection<Elaqe> Elaqes { get; set; }

        public ICollection<Haqqimizda> Haqqimizdas { get; set; }

        public ICollection<Teklifler> Tekliflers { get; set; }

    }
}

