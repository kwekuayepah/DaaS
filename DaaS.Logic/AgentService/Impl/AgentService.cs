using System;
using System.Threading.Tasks;
using DaaS.Core.ResponseWrapper;
using DaaS.Core.ViewModels.Agents;
using DaaS.Logic.AgentService.Provider;
using Microsoft.Extensions.Logging;
using PhoneNumbers;

namespace DaaS.Logic.AgentService.Impl
{
    public class AgentService:IAgentService
    {
        private readonly ILogger<AgentService> _logger;

        public AgentService(ILogger<AgentService> logger)
        {
            _logger = logger;
        }

        public async Task<AppResult> CreateAgent(CreateAgentVM model)
        {
            try
            {
                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumber = null;

                if (model.MobileNumber.StartsWith('+'))
                {
                    if (model.MobileNumber.Length < 8)
                    {
                        //todo: some logic here to bounce number
                        //todo: return appresult
                    }

                    phoneNumber = phoneNumberUtil.Parse(model.MobileNumber, null);
                }
                
                if (model.MobileNumber.Length < 8)
                {
                    //todo: some logic here to bounce number
                    //todo: return appresult
                }
                
                phoneNumber = phoneNumberUtil.Parse(model.MobileNumber, model.CountryCode);


                return AppResult.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}