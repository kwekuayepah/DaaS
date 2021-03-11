using System.Threading.Tasks;
using DaaS.Core.ViewModels.Agents;
using DaaS.DataLayer.DataModels;
using DaaS.DataLayer.Repository.Base;

namespace DaaS.DataLayer.Repository.AgentRepo
{
    public interface IAgentRepository:IRepository<Agent>
    {
        Task<string> CreateAgentInDb(CreateAgentVM model);
    }
}