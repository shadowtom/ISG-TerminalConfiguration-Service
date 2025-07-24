using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.Mappers
{
    public static class TerminalInfoMapper
    {
        public static Terminal mapToTerminal(TerminalConfigurationDTO dto)
        {
            TerminalSecurity security = new TerminalSecurity()
            {
                id = dto.Security.id,
                token = dto.Security.token,
                TerminalId = dto.Security.TerminalId.ToString(),
                expirationDate = dto.Security.expirationDate
            };
            TerminalConfig terminalConfiguration = new TerminalConfig
            {
                Id = dto.Id,
                clientID = dto.clientID,
                TerminalId = dto.TerminalId,
                IpAddress = dto.IpAddress,
                Port = dto.Port,
                Enabled = dto.Enabled
            };
            return new Terminal()
            {
                Configuration = terminalConfiguration,
                Security = security
            };
        }

        public static TerminalSecurity mapToTerminalSecurity(TerminalSecurityDTO terminalSecurityDTO)
        {
            TerminalSecurity terminalSecurity = new TerminalSecurity()
            {
                expirationDate = terminalSecurityDTO.expirationDate,
                id = terminalSecurityDTO.id,
                token = terminalSecurityDTO.token,
                TerminalId = terminalSecurityDTO.TerminalId.ToString(),
            };

            return terminalSecurity;
        }

        public static TerminalSecurityDTO mapToTerminalSecurityDTO(TerminalSecurity terminalSecurity)
        {
            TerminalSecurityDTO terminalSecurityDTO = new TerminalSecurityDTO()
            {
                id = terminalSecurity.id,
                token = terminalSecurity.token,
                TerminalId = new Guid(terminalSecurity.TerminalId),
                expirationDate = terminalSecurity.expirationDate
            };

            return terminalSecurityDTO;
        }

        public static TerminalConfigurationDTO mapToTerminalConfiguration(TerminalConfig terminalConfiguration)
        {
            return new TerminalConfigurationDTO
            {
                Id = terminalConfiguration.Id,
                clientID = terminalConfiguration.clientID,
                TerminalId = terminalConfiguration.TerminalId,
                IpAddress = terminalConfiguration.IpAddress,
                Port = terminalConfiguration.Port,
                Enabled = terminalConfiguration.Enabled,
                KioskID = terminalConfiguration.KioskID
            };
        }

        public static TerminalConfigurationDTO mapToTerminalConfigurationDTO(TerminalConfig terminalConfiguration)
        {
            return new TerminalConfigurationDTO
            {
                Id = terminalConfiguration.Id,
                clientID = terminalConfiguration.clientID,
                TerminalId = terminalConfiguration.TerminalId,
                IpAddress = terminalConfiguration.IpAddress,
                Port = terminalConfiguration.Port,
                Enabled = terminalConfiguration.Enabled,
                KioskID = terminalConfiguration.KioskID
            };
        }
    }
}
