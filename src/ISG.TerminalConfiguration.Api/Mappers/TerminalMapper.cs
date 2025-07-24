using ISG.TerminalConfiguration.Api.DTO.Responses;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.DTO.Requests;
using ISG.TerminalConfiguration.DTO.Responses;

namespace ISG.TerminalConfiguration.Api.Mappers
{
    public static class TerminalMapper
    {
        public static TerminalDTO mapToTerminalDTO(
            TerminalConfig terminalConfiguration,
            TerminalSecurity terminalSecurity)
        {
            return new TerminalDTO
            {
                TerminalConfiguration = new ResponseTerminalConfigurationDTO()
                {
                    TerminalId = terminalConfiguration.TerminalId,
                    IpAddress = terminalConfiguration.IpAddress,
                    Port = terminalConfiguration.Port,
                    Enabled = terminalConfiguration.Enabled,
                    Id = terminalConfiguration.Id,
                    KioskId = terminalConfiguration.KioskID
                },
                TerminalSecurity = new ResponseTerminalSecurityDTO()
                {
                    expirationDate = terminalSecurity.expirationDate,
                    id = terminalSecurity.id,
                    token = terminalSecurity.token,
                    TerminalId = terminalSecurity.TerminalId
                }
            };
        }

        internal static TerminalConfig mapToTerminalConfiguration(RequestTerminalConfigurationDTO terminalConfiguration)
        {
            return new TerminalConfig
            {
                TerminalId = terminalConfiguration.TerminalId,
                IpAddress = terminalConfiguration.IpAddress,
                Port = terminalConfiguration.Port,
                Enabled = terminalConfiguration.Enabled,
                Id = terminalConfiguration.Id,
                clientID = terminalConfiguration.clientID,
                KioskID = terminalConfiguration.KioskID.ToString()
                
            };
        }
    }
}
