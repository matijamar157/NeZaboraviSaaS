namespace NeZaboravi.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetRegisteredUsersCountAsync();
        Task<int> GetArtiklsCountAsync();
        int CalculateDisplayUsersCount(int baseCount, int logsMultiplier);
        int CalculateDisplayRecordsCount(int baseCount, int logsMultiplier);
    }
}
