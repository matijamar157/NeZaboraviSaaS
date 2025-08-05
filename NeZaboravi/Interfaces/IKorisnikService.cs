using NeZaboravi.Models;

namespace NeZaboravi.Interfaces
{
    public interface IKorisnikService
    {
        Task<IEnumerable<Korisnik>> GetAllKorisniciAsync();
        Task<Korisnik> GetKorisnikByIdAsync(int id);
        Task<Korisnik> GetKorisnikByUsernameAsync(string username);
        Task<Korisnik> CreateKorisnikAsync(Korisnik korisnik, string username);
        Task<bool> UpdateKorisnikAsync(Korisnik korisnik);
        Task<bool> DeleteKorisnikAsync(int id);
        Task<bool> KorisnikExistsAsync(int id);
    }
}
