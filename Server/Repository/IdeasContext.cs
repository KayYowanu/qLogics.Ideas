using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using qLogics.Ideas.Models;

namespace qLogics.Ideas.Repository
{
    public class IdeasContext : DBContextBase, IService
    {
        public virtual DbSet<Models.Ideas> Ideas { get; set; }

        public IdeasContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
