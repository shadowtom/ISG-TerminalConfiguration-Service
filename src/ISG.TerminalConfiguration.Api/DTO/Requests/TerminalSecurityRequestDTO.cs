namespace ISG.TerminalConfiguration.Api.DTO.Requests
{
    public class TerminalSecurityRequestDTO
    {
        public Guid id { get; set; }
        public string token { get; set; }
        public Guid TerminalId { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
