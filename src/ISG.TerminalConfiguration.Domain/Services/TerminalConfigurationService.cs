using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using ISG.TerminalConfiguration.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Services
{
    public class TerminalConfigurationService : ITerminalConfigurationService
    {
        private readonly ITerminalInfoRepository terminalInfoRepository;

        public TerminalConfigurationService(IServiceProvider serviceProvider)
        {
            terminalInfoRepository = serviceProvider.GetRequiredService<ITerminalInfoRepository>();
        }

        public async Task<Terminal> GetTerminalInformationAsync(Guid KioskID)
        {
            return await terminalInfoRepository.GetTerminalInformationAsync(KioskID);

        }
        public async Task<List<Terminal>> GetTerminalsInfoByClientIDAsync(Guid clientID)
        {
            return await terminalInfoRepository.GetTerminalsInfoByClientIDAsync(clientID);
        }
        public async Task AddTerminalConfigurationAsync(TerminalConfig terminalConfiguration)
        {
            await terminalInfoRepository.AddTerminalConfigurationAsync(terminalConfiguration);
        }
        public async Task UpdateTerminalConfigurationAsync(TerminalConfig terminalConfiguration)
        {
            await terminalInfoRepository.UpdateTerminalConfigurationAsync(terminalConfiguration);
        }

        public Task<bool> deleteTerminalConfigurationWithKioskID(Guid kioskID)
        {
            return terminalInfoRepository.deleteTerminalConfigurationWithTerminalID(kioskID);
        }
        public Task<bool> deleteTerminalConfigurationWithTerminalID(Guid terminalID)
        {
            return terminalInfoRepository.deleteTerminalConfigurationWithTerminalID(terminalID);
        }
    }
}
