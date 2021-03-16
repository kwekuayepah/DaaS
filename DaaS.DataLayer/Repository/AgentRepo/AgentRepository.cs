using System;
using System.Threading.Tasks;
using DaaS.Core.ErrorHandler;
using DaaS.Core.Helpers;
using DaaS.Core.ViewModels.Agents;
using DaaS.DataLayer.DataModels;
using DaaS.DataLayer.Repository.Base;
using Microsoft.Extensions.Logging;

namespace DaaS.DataLayer.Repository.AgentRepo
{
    public class AgentRepository: Repository<Agent>, IAgentRepository
    {
        private readonly ILogger<AgentRepository> _logger;

        public AgentRepository(ApplicationDbContext context, ILogger<AgentRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<string> CreateAgentInDb(CreateAgentVM model)
        {
            var result = string.Empty;
            try
            {
                var agent = new Agent
                {
                    AccountCode = model.AccountCode,
                    AccountName = model.AccountName,
                    AccountType = model.AccountType,
                    AccountNumber = model.AccountNumber,
                    AccountProvider = model.AccountProvider,
                    CountryCode = model.CountryCode,
                    CreatedAt = DateTime.UtcNow,
                    Fullname = model.Fullname,
                    ImageUrl = model.ImageUrl,
                    MobileNumber = model.MobileNumber,
                    MotorNumber = model.MotorNumber,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Status = AgentStatus.Inactive,
                    Id = Guid.NewGuid().ToString("N")
                };

                await context.Agents.AddAsync(agent);
                result = agent.Id;
                _logger.LogInformation("Create agent successful with Id: {agent_id}", result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.ToString());
                result = ErrorHandler.AgentCreateError;
            }

            return result;
        }
    }
}