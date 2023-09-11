using System;
namespace AlMarket.DAL.Entities
{
	public class Market
	{
		public int id { get; set; }

		public string Filials { get; set; }

		public ICollection<Media> medias { get; set; }

		public ICollection<Huquq> Huquqs { get; set; }

		public ICollection<Catalog> Catalogs { get; set; }
	}
}

