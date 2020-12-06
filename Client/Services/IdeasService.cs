using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using qLogics.Ideas.Models;

namespace qLogics.Ideas.Services
{
    public class IdeasService : ServiceBase, IIdeasService, IService
    {
        private readonly SiteState _siteState;

        public IdeasService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "Ideas");

        public async Task<List<Models.Ideas>> GetIdeassAsync(int ModuleId)
        {
            List<Models.Ideas> Ideass = await GetJsonAsync<List<Models.Ideas>>
                (CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return Ideass;
        }

        public async Task<Models.Ideas> GetIdeasAsync(int IdeasId, int ModuleId)
        {
            return await GetJsonAsync<Models.Ideas>(CreateAuthorizationPolicyUrl($"{Apiurl}/{IdeasId}", ModuleId));
        }

        public async Task<Models.Ideas> AddIdeasAsync(Models.Ideas Ideas)
        {
            return await PostJsonAsync<Models.Ideas>(CreateAuthorizationPolicyUrl($"{Apiurl}", Ideas.ModuleId), Ideas);
        }

        public async Task<Models.Ideas> UpdateIdeasAsync(Models.Ideas Ideas)
        {
            return await PutJsonAsync<Models.Ideas>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Ideas.IdeasId}", Ideas.ModuleId), Ideas);
        }

        public async Task DeleteIdeasAsync(int IdeasId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{IdeasId}", ModuleId));
        }
    }
}
