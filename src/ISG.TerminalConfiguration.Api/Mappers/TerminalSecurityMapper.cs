using ISG.TerminalConfiguration.Api.DTO.Requests;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.DTO.Responses;

namespace ISG.TerminalConfiguration.Api.Mappers
{
    public static class TerminalSecurityMapper
    {
        public static TerminalSecurity mapToTerminalSecurity(TerminalSecurityRequestDTO requestDTO)
        {
            return new TerminalSecurity
            {
                id = requestDTO.id,
                token = requestDTO.token,
                TerminalId = requestDTO.TerminalId.ToString(),
                expirationDate = requestDTO.expirationDate
            };
        }
        public static ResponseTerminalSecurityDTO mapToTerminalSecurityResponse(TerminalSecurity terminalSecurity)
        {
            return new ResponseTerminalSecurityDTO
            {
                id = terminalSecurity.id,
                token = terminalSecurity.token,
                TerminalId = terminalSecurity.TerminalId,
                expirationDate = terminalSecurity.expirationDate
            };
        }
    }
}
