using System;
using System.Threading.Tasks;
using DaaS.Core.Extensions;
using DaaS.Core.ResponseWrapper;
using DaaS.Core.ViewModels.Agents;
using DaaS.Logic.AgentService.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DaaS.Presentation.Controllers
{
    [Route("api/agents")]
    public class AgentsController : Controller
    {
        private readonly ILogger<AgentsController> _logger;
        private readonly IAgentService _agentService;

        public AgentsController(ILogger<AgentsController> logger, IAgentService agentService)
        {
            _logger = logger;
            _agentService = agentService;
        }

        [HttpPost("createagent")]
        public async Task<IActionResult> CreateAgent([FromBody] CreateAgentVM request)
        {
            if (!ModelState.IsValid) return AppResult.Fail(ModelState.GetErrorMessageAsString("\n")).ToIActionResult();

            var result = await _agentService.CreateAgent(request);
            return result.ToIActionResult();
        }
    }
}