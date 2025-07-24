using ISG.TerminalConfiguration.DTO.Responses;

namespace ISG.TerminalConfiguration.Api.DTO.Responses
{
    public class TerminalDTO
    {
        public ResponseTerminalConfigurationDTO TerminalConfiguration { get; set; }
        public ResponseTerminalSecurityDTO TerminalSecurity { get; set; }
    }
}
