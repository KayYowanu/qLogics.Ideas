using System.Collections.Generic;
using System.Threading.Tasks;
using qLogics.Ideas.Models;

namespace qLogics.Ideas.Services
{
    public interface IIdeasService 
    {
        Task<List<Models.Ideas>> GetIdeassAsync(int ModuleId);

        Task<Models.Ideas> GetIdeasAsync(int IdeasId, int ModuleId);

        Task<Models.Ideas> AddIdeasAsync(Models.Ideas Ideas);

        Task<Models.Ideas> UpdateIdeasAsync(Models.Ideas Ideas);

        Task DeleteIdeasAsync(int IdeasId, int ModuleId);
    }
}
