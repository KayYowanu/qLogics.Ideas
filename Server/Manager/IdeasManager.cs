using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using qLogics.Ideas.Models;
using qLogics.Ideas.Repository;

namespace qLogics.Ideas.Manager
{
    public class IdeasManager : IInstallable, IPortable
    {
        private IIdeasRepository _IdeasRepository;
        private ISqlRepository _sql;

        public IdeasManager(IIdeasRepository IdeasRepository, ISqlRepository sql)
        {
            _IdeasRepository = IdeasRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "qLogics.Ideas." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "qLogics.Ideas.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Ideas> Ideass = _IdeasRepository.GetIdeass(module.ModuleId).ToList();
            if (Ideass != null)
            {
                content = JsonSerializer.Serialize(Ideass);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Ideas> Ideass = null;
            if (!string.IsNullOrEmpty(content))
            {
                Ideass = JsonSerializer.Deserialize<List<Models.Ideas>>(content);
            }
            if (Ideass != null)
            {
                foreach(var Ideas in Ideass)
                {
                    _IdeasRepository.AddIdeas(new Models.Ideas { ModuleId = module.ModuleId, Name = Ideas.Name });
                }
            }
        }
    }
}