﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EphIt.BL.Authorization;
using EphIt.BL.Script;
using EphIt.BL.User;
using EphIt.Db.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EphIt.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize("ScriptRead")]
    public class ScriptController : ControllerBase
    {
        private IEphItUser _ephItUser;
        private EphItContext _dbContext;
        private IUserAuthorization _userAuth;
        private IScriptManager _scriptManager;
        public ScriptController(EphItContext dbContext, IEphItUser ephItUser, IUserAuthorization userAuth, IScriptManager scriptManager)
        {
            _dbContext = dbContext;
            _ephItUser = ephItUser;
            _userAuth = userAuth;
            _scriptManager = scriptManager;
        }
        [HttpGet]
        [Route("/api/[controller]/{scriptId}")]
        public async Task<ActionResult<VMScript>> GetAsync(int scriptId)
        {
            var item = await _scriptManager.FindAsync(scriptId);
            if(item == null)
            {
                return NotFound();
            }

            return item;
        }
        [HttpGet]
        [Route("/api/[controller]")]
        public async Task<ActionResult<IEnumerable<VMScript>>> GetAsync(string Name)
        {
            var results = await _scriptManager.SafeSearchScriptsAsync(Name, true);
            return results;
        }
        [HttpPost]
        [Route("/api/[controller]")]
        [Authorize("ScriptEdit")]
        public async Task<int> New([FromBody] ScriptPostParameters postParams)
        {
            return await _scriptManager.NewAsync(postParams.Name, postParams.Description);
        }
        [HttpPut]
        [Route("[controller]/{scriptId}")]
        [Authorize("ScriptEdit")]
        public async Task Update(int scriptId, [FromBody] ScriptPostParameters postParams)
        {
            await _scriptManager.Update(scriptId, postParams.Name, postParams.Description, postParams.Published_Version);
        }
        [HttpDelete]
        [Route("[controller]/{scriptId}")]
        [Authorize("ScriptDelete")]
        public async Task Delete(int scriptId)
        {
            await _scriptManager.Delete(scriptId);
        }
        [HttpGet]
        [Route("[controller]/{scriptId}/Version")]
        public async Task<IEnumerable<VMScriptVersion>> GetVersion(int scriptId, bool IncludeAll = false)
        {
            return await _scriptManager.GetVersionAsync(scriptId, IncludeAll);
        }
        [HttpPost]
        [Route("/api/[controller]/{scriptId}/Version")]
        [Authorize("ScriptEdit")]
        public async Task<int> NewVersion(int scriptId, [FromBody] ScriptVersionPostParameters postParams)
        {
            return await _scriptManager.NewVersionAsync(scriptId, postParams.ScriptBody, postParams.ScriptLanguageId);
        }
    }
    public class ScriptPostParameters
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Published_Version { get; set; }
    }
    public class ScriptVersionPostParameters
    {
        public string ScriptBody { get; set; }
        public short ScriptLanguageId { get; set; }
    }
}
