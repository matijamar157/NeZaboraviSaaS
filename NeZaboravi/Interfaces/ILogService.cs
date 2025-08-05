namespace NeZaboravi.Interfaces
{
    public interface ILogService
    {
        Task LogActivityAsync(string message);
        Task<int> GetLogsCountAsync();
    }
}
