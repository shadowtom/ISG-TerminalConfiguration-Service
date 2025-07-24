using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Interfaces.Services
{
    public interface IKioskService
    {
        public Task<List<Kiosk>> GetKioskIdsByClientIdAsync(Guid clientId);
        public Task<Kiosk> GetKioskByIdAsync(Guid kioskId);
        public Task AddKioskAsync(Kiosk kiosk);
        public Task UpdateKioskAsync(Kiosk kiosk);
        public Task<bool> DeleteKioskAsync(Guid kioskId);
    }
}
