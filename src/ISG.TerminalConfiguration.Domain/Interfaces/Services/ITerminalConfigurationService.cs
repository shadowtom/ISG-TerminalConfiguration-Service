using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Interfaces.Services
{
    public interface ITerminalConfigurationService
    {
        Task<Terminal> GetTerminalInformationAsync(Guid kioskID);

        Task<List<Terminal>> GetTerminalsInfoByClientIDAsync(Guid clientID);
        Task AddTerminalConfigurationAsync(TerminalConfig terminalConfiguration);
        Task UpdateTerminalConfigurationAsync(TerminalConfig terminalConfiguration);
        Task<bool> deleteTerminalConfigurationWithKioskID(Guid kioskID);
        Task<bool> deleteTerminalConfigurationWithTerminalID(Guid terminalID);

    }
}
