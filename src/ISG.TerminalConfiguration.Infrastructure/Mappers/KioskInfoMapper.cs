using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.Mappers
{
    public static class KioskInfoMapper
    {
        public static KioskDTO mapToKioskDTO(Kiosk kioskInfo)
        {
            return new KioskDTO
            {
                Id = kioskInfo.Id,
                ClientID = kioskInfo.ClientID,
                Address = kioskInfo.Address,
            };
        }
        public static Kiosk mapToKiosk(KioskDTO kioskInfoDTO)
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
