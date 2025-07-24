namespace ISG.TerminalConfiguration.DTO.Responses
{
    public class ResponseTerminalSecurityDTO
    {
        public bool isExpired;

        public Guid id { get; set; }
        public string token { get; set; }
        public string TerminalId { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
