using ISG.TerminalConfiguration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Interfaces.Repositories
{
    public interface IKioskRepository
    {
        public  Task AddKioskAsync(Kiosk kiosk);
        public  Task<bool> DeleteKioskAsync(Guid kioskId);

        public  Task<Kiosk?> GetKioskByIdAsync(Guid kioskId);

        public Task<List<Kiosk>> GetKiosksByClientIdAsync(Guid clientId);

        public Task<bool> UpdateKioskAsync(Kiosk kiosk);
    }
}
