using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Interfaces.Services
{
    public interface ITerminalSecurityService
    {

        public Task<bool> ValidateTerminalSecurityAsync(string terminalId, string token);

        public Task AddOrUpdateTerminalSecurityAsync(string terminalId, string token, DateTime expirationDate);
        Task AddNewTerminalTokenAsync(TerminalSecurity terminalSecurity);
    }
}
