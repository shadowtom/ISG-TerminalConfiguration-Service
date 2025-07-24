namespace ISG.TerminalConfiguration.DTO.Responses
{
    public class ResponseTerminalConfigurationDTO
    {
        public Guid Id { get; set; }
        public string TerminalId { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool Enabled { get; set; }
        public string KioskId { get; set; }
    }
}
