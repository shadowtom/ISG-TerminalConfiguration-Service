using ISG.TerminalConfiguration.Api.DTO.Requests;
using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Infrastructure.DTO;

namespace ISG.TerminalConfiguration.Api.Mappers
{
    public static class KioskMapper
    {
        public static Kiosk mapToKiosk(KioskRequestDTO kioskInfoDTO)
        {
            return new Kiosk
            {
                Id = kioskInfoDTO.Id,
                ClientID = kioskInfoDTO.ClientID,
                Address = kioskInfoDTO.Address,
            };
        }
    }
}
