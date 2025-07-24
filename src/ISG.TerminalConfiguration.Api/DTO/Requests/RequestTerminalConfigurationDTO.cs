namespace ISG.TerminalConfiguration.DTO.Requests
{
    public class RequestTerminalConfigurationDTO
    {
        public Guid Id { get; set; }
        public string clientID { get; set; }
        public string TerminalId { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool Enabled { get; set; }
        public Guid KioskID { get; set; }
    }
}
