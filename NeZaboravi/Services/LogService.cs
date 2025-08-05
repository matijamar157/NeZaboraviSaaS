using Microsoft.EntityFrameworkCore;
using NeZaboravi.Data;
using NeZaboravi.Interfaces;
using NeZaboravi.Models;

namespace NeZaboravi.Services
{
    public class LogService : ILogService
    {
        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogActivityAsync(string message)
        {
            var newLog = new Log { Logs = message };
            _context.Logs.Add(newLog);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetLogsCountAsync()
        {
            return await _context.Logs.CountAsync();
        }
    }
}
