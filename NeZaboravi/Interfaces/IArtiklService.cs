using NeZaboravi.Models;

namespace NeZaboravi.Interfaces
{
    public interface IArtiklService
    {
        Task<IEnumerable<Artikl>> GetUserArtiklsAsync(string username);
        Task<Artikl> GetArtiklByIdAsync(int id);
        Task<Artikl> CreateArtiklAsync(Artikl artikl, string username);
        Task<bool> UpdateArtiklAsync(Artikl artikl);
        Task<bool> DeleteArtiklAsync(int id);
        Task<bool> ArtiklExistsAsync(int id);
    }
}
