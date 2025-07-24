using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using ISG.TerminalConfiguration.Infrastructure.Data;
using ISG.TerminalConfiguration.Infrastructure.DTO;
using ISG.TerminalConfiguration.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.Repositories
{
    public class TerminalInfoRepository : ITerminalInfoRepository
    {
        private readonly ConfigurationsDbContext _context;

        public TerminalInfoRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<ConfigurationsDbContext>();
        }

        public async Task<Terminal> GetTerminalInformationAsync(Guid KioskID)
        {
            var terminalConfiguration = await _context.TerminalConfigurations.Where(tc => tc.KioskID == KioskID.ToString())
                .Include(tc => tc.Security)
                .FirstOrDefaultAsync();
            if(terminalConfiguration == null)
            {
                throw new KeyNotFoundException($"Terminal configuration with KioskID {KioskID} not found.");
            }
            var response = TerminalInfoMapper.mapToTerminal(terminalConfiguration);

            return response;
        }

        public async Task<List<Terminal>> GetTerminalsInfoByClientIDAsync(Guid clientID)
        {
            var terminalConfigurations = await _context.TerminalConfigurations
                .Where(tc => tc.clientID == clientID.ToString())
                .Include(tc => tc.Security)
                .ToListAsync();
            var response = terminalConfigurations.Select(TerminalInfoMapper.mapToTerminal).ToList();
            return response;
        }
        public async Task AddTerminalConfigurationAsync(TerminalConfig terminalConfiguration)
        {
            TerminalConfigurationDTO terminalConfigurationDTO = TerminalInfoMapper.mapToTerminalConfiguration(terminalConfiguration);
            await _context.TerminalConfigurations.AddAsync(terminalConfigurationDTO);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTerminalConfigurationAsync(TerminalConfig terminalConfiguration)
        {
            if (terminalConfiguration == null)
            {
                throw new ArgumentNullException(nameof(terminalConfiguration), "Terminal configuration cannot be null.");
            }
            _context.TerminalConfigurations.Update(TerminalInfoMapper.mapToTerminalConfigurationDTO(terminalConfiguration));
            await _context.SaveChangesAsync();
        }
        public async Task<TerminalSecurity?> GetTerminalSecurityByTerminalIdAsync(string terminalId)
        {
            var terminalSecurityDTO = await _context.TerminalSecurities
                .FirstOrDefaultAsync(ts => ts.TerminalId == new Guid(terminalId));
            if (terminalSecurityDTO == null)
            {
                return null;
            }
            var terminalSecurity = TerminalInfoMapper.mapToTerminalSecurity(terminalSecurityDTO);

            return terminalSecurity;
        }
        public async Task UpdateTerminalSecurityAsync(TerminalSecurity terminalSecurity)
        {
            _context.Entry(terminalSecurity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task AddTerminalSecurityAsync(TerminalSecurity terminalSecurity)
        {
            TerminalSecurityDTO terminalSecurityDTO = TerminalInfoMapper.mapToTerminalSecurityDTO(terminalSecurity);
            await _context.TerminalSecurities.AddAsync(terminalSecurityDTO);
            await _context.SaveChangesAsync();
        }

        public Task<bool> deleteTerminalConfigurationWithKioskID(Guid kioskID)
        {
            var terminalConfiguration = _context.TerminalConfigurations.FirstOrDefault(tc => tc.KioskID == kioskID.ToString());
            if (terminalConfiguration == null)
            {
                throw new KeyNotFoundException($"Terminal configuration with KioskID {kioskID} not found.");
            }
            _context.TerminalConfigurations.Remove(terminalConfiguration);
            return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public Task<bool> deleteTerminalConfigurationWithTerminalID(Guid terminalID)
        {
            var terminalConfiguration = _context.TerminalConfigurations.FirstOrDefault(tc => tc.Id == terminalID);
            if (terminalConfiguration == null)
            {
                throw new KeyNotFoundException($"Terminal configuration with KioskID {terminalID.ToString()} not found.");
            }
            _context.TerminalConfigurations.Remove(terminalConfiguration);
            return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
    }
}
