using ISG.TerminalConfiguration.Domain.Entities;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using ISG.TerminalConfiguration.Infrastructure.Data;
using ISG.TerminalConfiguration.Infrastructure.DTO;
using ISG.TerminalConfiguration.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISG.TerminalConfiguration.Infrastructure.Repositories
{
    public class KioskRepository : IKioskRepository
    {
        private readonly ConfigurationsDbContext _context;

        public KioskRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<ConfigurationsDbContext>();
        }

        public async Task AddKioskAsync(Kiosk kiosk)
        {
            if (kiosk == null)
            {
                throw new ArgumentNullException(nameof(kiosk), "Kiosk cannot be null");
            }

            await _context.kiosks.AddAsync(KioskInfoMapper.mapToKioskDTO(kiosk));
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteKioskAsync(Guid kioskId)
        {
            var kiosk = await _context.kiosks.FindAsync(kioskId);
            if (kiosk == null)
            {
                return false; // Kiosk not found
            }
            _context.kiosks.Remove(kiosk);
            await _context.SaveChangesAsync();
            return true; // Kiosk deleted successfully
        }

        public async Task<Kiosk?> GetKioskByIdAsync(Guid kioskId)
        {
            var kiosk = await _context.kiosks.FirstOrDefaultAsync(k => k.Id == kioskId);
            if (kiosk == null)
            {
                return null; // Kiosk not found
            }
            return KioskInfoMapper.mapToKiosk(kiosk);
        }

        public Task<List<Kiosk>> GetKiosksByClientIdAsync(Guid clientId)
        {
            return _context.kiosks
                .Where(k => k.ClientID == clientId)
                .Select(k => KioskInfoMapper.mapToKiosk(k))
                .ToListAsync();
        }

        public async Task<bool> UpdateKioskAsync(Kiosk kiosk)
        {
            if (kiosk == null)
            {
                throw new ArgumentNullException(nameof(kiosk), "Kiosk cannot be null");
            }
            var existingKiosk = _context.kiosks.Find(kiosk.Id);
            if (existingKiosk == null)
            {
                throw new KeyNotFoundException($"Kiosk with ID {kiosk.Id} not found");
            }
            existingKiosk.Id = kiosk.Id;
            existingKiosk.Address = kiosk.Address;
            existingKiosk.ClientID = kiosk.ClientID;
            _context.kiosks.Update(existingKiosk);
            await _context.SaveChangesAsync();
            return true; // Kiosk updated successfully
        }
    }
}
