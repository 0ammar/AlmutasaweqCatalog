using AlmutasaweqCatalog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlmutasaweqCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReadController(IReadServices _readServices) : ControllerBase
	{
		[HttpGet("groups")]
		public async Task<IActionResult> GetAllGroups()
		{
			var groups = await _readServices.GetAllGroups();
			if (groups == null || groups.Count == 0)
				return NotFound("No groups found.");

			return Ok(groups);
		}

		[HttpGet("subones/{groupId}")]
		public async Task<IActionResult> GetAllSubOnesByGroups(int groupId)
		{
			if (groupId <= 0)
				return BadRequest("Invalid Group ID.");

			var subOnes = await _readServices.GetAllSubOnesByGroups(groupId);
			if (subOnes == null || subOnes.Count == 0)
				return NotFound($"No SubOne items found for Group ID {groupId}.");

			return Ok(subOnes);
		}

		[HttpGet("subtwos/{subOneId}")]
		public async Task<IActionResult> GetAllSubTwosBySubOnes(int subOneId)
		{
			if (subOneId <= 0)
				return BadRequest("Invalid SubOne ID.");

			var subTwos = await _readServices.GetAllSubTwosBySubOnes(subOneId);
			if (subTwos == null || subTwos.Count == 0)
				return NotFound($"No SubTwo items found for SubOne ID {subOneId}.");

			return Ok(subTwos);
		}

		[HttpGet("subthrees/{subTwoId}")]
		public async Task<IActionResult> GetAllSubThreesBySubTwos(int subTwoId)
		{
			if (subTwoId <= 0)
				return BadRequest("Invalid SubTwo ID.");

			var subThrees = await _readServices.GetAllSubThreesBySubTwos(subTwoId);
			if (subThrees == null || subThrees.Count == 0)
				return NotFound($"No SubThree items found for SubTwo ID {subTwoId}.");

			return Ok(subThrees);
		}

		[HttpGet("items/{subThreeId}")]
		public async Task<IActionResult> GetAllItemsBySubThrees(int subThreeId)
		{
			try
			{
				if (subThreeId <= 0)
					return BadRequest("Invalid SubThree ID.");

				var items = await _readServices.GetAllItemsBySubThrees(subThreeId);
				if (items == null || items.Count == 0)
					return NotFound($"No items found for SubThree ID {subThreeId}.");

				return Ok(items);
			}
			catch (Exception ex)
			{
				// Log the exception or use a logger
				return StatusCode(500, new { message = "An error occurred.", detail = ex.Message });
			}
		}

	}
}
