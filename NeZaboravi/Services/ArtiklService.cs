using Microsoft.EntityFrameworkCore;
using NeZaboravi.Data;
using NeZaboravi.Interfaces;
using NeZaboravi.Models;

namespace NeZaboravi.Services
{
    public class ArtiklService : IArtiklService
    {
        private readonly ApplicationDbContext _context;

        public ArtiklService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artikl>> GetUserArtiklsAsync(string username)
        {
            return await _context.Artikl
                .Where(x => x.Username == username)
                .ToListAsync();
        }

        public async Task<Artikl> GetArtiklByIdAsync(int id)
        {
            return await _context.Artikl.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Artikl> CreateArtiklAsync(Artikl artikl, string username)
        {
            artikl.Username = username;
            _context.Add(artikl);
            await _context.SaveChangesAsync();
            return artikl;
        }

        public async Task<bool> UpdateArtiklAsync(Artikl artikl)
        {
            try
            {
                _context.Update(artikl);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArtiklExistsAsync(artikl.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteArtiklAsync(int id)
        {
            var artikl = await _context.Artikl.FindAsync(id);
            if (artikl == null) return false;

            _context.Artikl.Remove(artikl);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ArtiklExistsAsync(int id)
        {
            return await _context.Artikl.AnyAsync(e => e.Id == id);
        }
    }
}
