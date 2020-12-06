using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using qLogics.Ideas.Models;
using qLogics.Ideas.Repository;

namespace qLogics.Ideas.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class IdeasController : Controller
    {
        private readonly IIdeasRepository _IdeasRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public IdeasController(IIdeasRepository IdeasRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _IdeasRepository = IdeasRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Ideas> Get(string moduleid)
        {
            return _IdeasRepository.GetIdeass(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Ideas Get(int id)
        {
            Models.Ideas Ideas = _IdeasRepository.GetIdeas(id);
            if (Ideas != null && Ideas.ModuleId != _entityId)
            {
                Ideas = null;
            }
            return Ideas;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Ideas Post([FromBody] Models.Ideas Ideas)
        {
            if (ModelState.IsValid && Ideas.ModuleId == _entityId)
            {
                Ideas = _IdeasRepository.AddIdeas(Ideas);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Ideas Added {Ideas}", Ideas);
            }
            return Ideas;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Ideas Put(int id, [FromBody] Models.Ideas Ideas)
        {
            if (ModelState.IsValid && Ideas.ModuleId == _entityId)
            {
                Ideas = _IdeasRepository.UpdateIdeas(Ideas);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Ideas Updated {Ideas}", Ideas);
            }
            return Ideas;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Ideas Ideas = _IdeasRepository.GetIdeas(id);
            if (Ideas != null && Ideas.ModuleId == _entityId)
            {
                _IdeasRepository.DeleteIdeas(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Ideas Deleted {IdeasId}", id);
            }
        }
    }
}
