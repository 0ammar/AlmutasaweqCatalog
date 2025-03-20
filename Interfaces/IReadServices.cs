using AlmutasaweqCatalog.Entities;

namespace AlmutasaweqCatalog.Interfaces
{
	public interface IReadServices
	{
		Task<List<Group>> GetAllGroups();
		Task<List<SubOne>> GetAllSubOnesByGroups(int input);
		Task<List<SubTwo>> GetAllSubTwosBySubOnes(int input);
		Task<List<SubThree>> GetAllSubThreesBySubTwos(int input);
		Task<List<Item>> GetAllItemsBySubThrees(int input);
	}
}
