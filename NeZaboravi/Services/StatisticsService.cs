using Microsoft.EntityFrameworkCore;
using NeZaboravi.Data;
using NeZaboravi.Interfaces;

namespace NeZaboravi.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogService _logService;

        public StatisticsService(ApplicationDbContext context, ILogService logService)
        {
            _context = context;
            _logService = logService;
        }

        public async Task<int> GetRegisteredUsersCountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> GetArtiklsCountAsync()
        {
            return await _context.Artikl.CountAsync();
        }

        public int CalculateDisplayUsersCount(int baseCount, int logsMultiplier)
        {
            const int baseUsers = 1000;
            return baseUsers + (baseCount * 2) + logsMultiplier;
        }

        public int CalculateDisplayRecordsCount(int baseCount, int logsMultiplier)
        {
            const int baseRecords = 4000;
            return baseRecords + (baseCount * 15) + logsMultiplier;
        }
    }
}
