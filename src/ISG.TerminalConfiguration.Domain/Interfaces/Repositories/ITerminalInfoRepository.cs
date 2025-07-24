using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Interfaces.Repositories
{
    public interface ITerminalInfoRepository
    {
        public Task<Terminal> GetTerminalInformationAsync(Guid KioskID);

        public Task<List<Terminal>> GetTerminalsInfoByClientIDAsync(Guid clientID);
        public  Task AddTerminalConfigurationAsync(TerminalConfig terminalConfiguration);
        public  Task UpdateTerminalConfigurationAsync(TerminalConfig terminalConfiguration);
        public Task<TerminalSecurity?> GetTerminalSecurityByTerminalIdAsync(string terminalId);
        public Task UpdateTerminalSecurityAsync(TerminalSecurity terminalSecurity);
        public Task AddTerminalSecurityAsync(TerminalSecurity terminalSecurity);
        Task<bool> deleteTerminalConfigurationWithKioskID(Guid kioskID);
        Task<bool> deleteTerminalConfigurationWithTerminalID(Guid terminalID);
    }
}
