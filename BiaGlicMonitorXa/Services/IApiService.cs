using System.Collections.Generic;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;

namespace BiaGlicMonitorXa.Services
{
	public interface IMonkeyHubApiService
	{
		Task<List<Content>> GetContentsByTagIdAsync(string tagId);
		Task<List<Tag>> GetTagsAsync();
		Task<List<Content>> GetContentsByFilterAsync(string filter);
	}
}
