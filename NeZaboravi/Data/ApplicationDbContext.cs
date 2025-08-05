using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeZaboravi.Models;

namespace NeZaboravi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artikl> Artikl { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
    }
}