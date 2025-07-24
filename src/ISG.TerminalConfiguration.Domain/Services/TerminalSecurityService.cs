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
    public class TerminalSecurityService : ITerminalSecurityService
    {
        private readonly ITerminalInfoRepository terminalInfoRepository;

        public TerminalSecurityService(IServiceProvider serviceProvider)
        {
            terminalInfoRepository = serviceProvider.GetRequiredService<ITerminalInfoRepository>();
        }

        public async Task<bool> ValidateTerminalSecurityAsync(string terminalId, string token)
        {
            var terminalSecurity = await terminalInfoRepository.GetTerminalSecurityByTerminalIdAsync(terminalId);
            if (terminalSecurity == null)
            {
                return false;
            }
            // Check if the token matches and is not expired
            return terminalSecurity.token == token;
        }

        public async Task AddOrUpdateTerminalSecurityAsync(string terminalId, string token, DateTime expirationDate)
        {
            var terminalSecurity = await terminalInfoRepository.GetTerminalSecurityByTerminalIdAsync(terminalId);
            if (terminalSecurity == null)
            {
                // Create new TerminalSecurity
                terminalSecurity = new TerminalSecurity
                {
                    TerminalId = terminalId,
                    token = token,
                    expirationDate = expirationDate
                };
                await terminalInfoRepository.AddTerminalSecurityAsync(terminalSecurity);
            }
            else
            {
                // Update existing TerminalSecurity
                terminalSecurity.token = token;
                terminalSecurity.expirationDate = expirationDate;
                await terminalInfoRepository.UpdateTerminalSecurityAsync(terminalSecurity);
            }
        }
    }
}
