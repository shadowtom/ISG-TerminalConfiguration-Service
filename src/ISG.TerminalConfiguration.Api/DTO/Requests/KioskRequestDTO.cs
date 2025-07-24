namespace ISG.TerminalConfiguration.Api.DTO.Requests
{
    public class KioskRequestDTO
    {
        public Guid Id { get; set; }
        public Guid ClientID { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
