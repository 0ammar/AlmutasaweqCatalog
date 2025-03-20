using System.Text.Json.Serialization;

namespace AlmutasaweqCatalog.Entities
{
	public class Item
	{
		public int ItemNo { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		[JsonIgnore]
		public List<String> Image { get; set; }
		public DateTime CreationDate { get; set; }
		public bool IsDeleted { get; set; }
		public int SubThreeId { get; set; }
	}
}
