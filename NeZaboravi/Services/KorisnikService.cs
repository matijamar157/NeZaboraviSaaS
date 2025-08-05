using Microsoft.EntityFrameworkCore;
using NeZaboravi.Data;
using NeZaboravi.Interfaces;
using NeZaboravi.Models;

namespace NeZaboravi.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly ApplicationDbContext _context;

        public KorisnikService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Korisnik>> GetAllKorisniciAsync()
        {
            return await _context.Korisnik.ToListAsync();
        }

        public async Task<Korisnik> GetKorisnikByIdAsync(int id)
        {
            return await _context.Korisnik.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Korisnik> GetKorisnikByUsernameAsync(string username)
        {
            return await _context.Korisnik
                .Where(x => x.Username == username)
                .FirstOrDefaultAsync();
        }

        public async Task<Korisnik> CreateKorisnikAsync(Korisnik korisnik, string username)
        {
            korisnik.Username = username;
            _context.Add(korisnik);
            await _context.SaveChangesAsync();
            return korisnik;
        }

        public async Task<bool> UpdateKorisnikAsync(Korisnik korisnik)
        {
            try
            {
                _context.Update(korisnik);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await KorisnikExistsAsync(korisnik.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteKorisnikAsync(int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null) return false;

            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> KorisnikExistsAsync(int id)
        {
            return await _context.Korisnik.AnyAsync(e => e.Id == id);
        }
    }
}
