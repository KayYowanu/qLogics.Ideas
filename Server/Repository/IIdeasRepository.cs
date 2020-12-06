using System.Collections.Generic;
using qLogics.Ideas.Models;

namespace qLogics.Ideas.Repository
{
    public interface IIdeasRepository
    {
        IEnumerable<Models.Ideas> GetIdeass(int ModuleId);
        Models.Ideas GetIdeas(int IdeasId);
        Models.Ideas AddIdeas(Models.Ideas Ideas);
        Models.Ideas UpdateIdeas(Models.Ideas Ideas);
        void DeleteIdeas(int IdeasId);
    }
}
