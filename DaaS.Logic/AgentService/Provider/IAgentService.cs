using System.Threading.Tasks;
using DaaS.Core.ResponseWrapper;
using DaaS.Core.ViewModels.Agents;

namespace DaaS.Logic.AgentService.Provider
{
    public interface IAgentService
    {
        Task<AppResult> CreateAgent(CreateAgentVM model);
    }
}