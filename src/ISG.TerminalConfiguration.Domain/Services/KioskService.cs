using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using ISG.TerminalConfiguration.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Domain.Services
{
    public class KioskService : IKioskService
    {
        private readonly IKioskRepository kioskRepository;
        public KioskService(IServiceProvider serviceProvider)
        {
            kioskRepository = serviceProvider.GetRequiredService<IKioskRepository>();
        }
        public async Task<List<Kiosk>> GetKioskIdsByClientIdAsync(Guid clientId)
        {
            return await kioskRepository.GetKiosksByClientIdAsync(clientId);
        }
        public async Task<Kiosk> GetKioskByIdAsync(Guid kioskId)
        {
            if (kioskId == Guid.Empty)
            {
                throw new ArgumentException("Kiosk ID cannot be empty.", nameof(kioskId));
            }
            var kiosk = await kioskRepository.GetKioskByIdAsync(kioskId);
            if (kiosk == null)
            {
                throw new KeyNotFoundException($"Kiosk with ID {kioskId} not found.");
            }
            return kiosk;
        }
        public async Task AddKioskAsync(Kiosk kiosk)
        {
            if (kiosk == null)
            {
                throw new ArgumentNullException(nameof(kiosk), "Kiosk cannot be null.");
            }
            await kioskRepository.AddKioskAsync(kiosk);
        }
        public async Task UpdateKioskAsync(Kiosk kiosk)
        {
            if (kiosk == null)
            {
                throw new ArgumentNullException(nameof(kiosk), "Kiosk cannot be null.");
            }
            if (kiosk.Id == Guid.Empty)
            {
                throw new ArgumentException("Kiosk ID cannot be empty.", nameof(kiosk));
            }
            await kioskRepository.UpdateKioskAsync(kiosk);
        }
        public async Task<bool> DeleteKioskAsync(Guid kioskId)
        {
            if (kioskId == Guid.Empty)
            {
                throw new ArgumentException("Kiosk ID cannot be empty.", nameof(kioskId));
            }
            return await kioskRepository.DeleteKioskAsync(kioskId);
        }
    }
}
