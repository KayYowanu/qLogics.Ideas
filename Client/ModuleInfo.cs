using Oqtane.Models;
using Oqtane.Modules;

namespace qLogics.Ideas
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Ideas",
            Description = "Ideas",
            Version = "1.0.0",
            ServerManagerType = "qLogics.Ideas.Manager.IdeasManager, qLogics.Ideas.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "qLogics.Ideas.Shared.Oqtane"
        };
    }
}
