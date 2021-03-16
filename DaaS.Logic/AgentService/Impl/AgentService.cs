using System;
using System.Threading.Tasks;
using DaaS.Core.ErrorHandler;
using DaaS.Core.ResponseWrapper;
using DaaS.Core.ViewModels.Agents;
using DaaS.DataLayer.Repository.AgentRepo;
using DaaS.Logic.AgentService.Provider;
using Microsoft.Extensions.Logging;
using PhoneNumbers;

namespace DaaS.Logic.AgentService.Impl
{
    public class AgentService : IAgentService
    {
        private readonly ILogger<AgentService> _logger;
        private readonly IAgentRepository _agentRepository;

        public AgentService(ILogger<AgentService> logger, IAgentRepository agentRepository)
        {
            _logger = logger;
            _agentRepository = agentRepository;
        }

        public async Task<AppResult> CreateAgent(CreateAgentVM model)
        {
            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumber = null;

                if (model.MobileNumber.StartsWith('+'))
                {
                    if (model.MobileNumber.Length < 8)
                    {
                        AppResult.Error(ErrorHandler.GeneralErrorMessage, ResponseMessages.InvalidPhoneNumber);
                    }

                    phoneNumber = phoneNumberUtil.Parse(model.MobileNumber, null);
                }

                if (model.MobileNumber.Length < 8)
                {
                    AppResult.Error(ErrorHandler.GeneralErrorMessage, ResponseMessages.InvalidPhoneNumber);
                }

                phoneNumber = phoneNumberUtil.Parse(model.MobileNumber, model.CountryCode);

                model.MobileNumber = $"{phoneNumber.CountryCode}{phoneNumber.NationalNumber}";


                var resp = await _agentRepository.CreateAgentInDb(model);

                return ErrorHandler.AgentCreateError.Equals(resp) ? AppResult.Error(resp) : AppResult.Success("Successfully created agent", resp);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.ToString());
                return AppResult.Error("An error occured", e.ToString());
            }
        }
    }
}