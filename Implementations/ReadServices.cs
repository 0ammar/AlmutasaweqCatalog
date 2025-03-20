using AlmutasaweqCatalog.DbContexts;
using AlmutasaweqCatalog.Entities;
using AlmutasaweqCatalog.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlmutasaweqCatalog.Implementations
{
	public class ReadServices(CatalogContext context) : IReadServices
	{
		private readonly CatalogContext _context = context;

		public async Task<List<Group>> GetAllGroups()
		{
			return await _context.Groups.ToListAsync();
		}

		public async Task<List<SubOne>> GetAllSubOnesByGroups(int input)
		{
			return await _context.SubOnes
				.Where(so => so.GroupId == input)
				.ToListAsync();
		}

		public async Task<List<SubTwo>> GetAllSubTwosBySubOnes(int input)
		{
			return await _context.SubTwos
				.Where(st => st.SubOneId == input)
				.ToListAsync();
		}

		public async Task<List<SubThree>> GetAllSubThreesBySubTwos(int input)
		{
			return await _context.SubThrees
				.Where(st => st.SubTwoId == input)
				.ToListAsync();
		}

		public async Task<List<Item>> GetAllItemsBySubThrees(int input)
		{
			var items = from i in _context.Items
						where i.SubThreeId == input
						select new Item
						{
							ItemNo = i.ItemNo,
							Name = i.Name,
							Price = i.Price,
							Image = i.Image,
						};
			return await items.ToListAsync();
		}
	}
}
