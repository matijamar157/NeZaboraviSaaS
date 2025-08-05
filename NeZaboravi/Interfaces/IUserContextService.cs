namespace NeZaboravi.Interfaces
{
    public interface IUserContextService
    {
        string GetCurrentUsername();
        bool IsUserAuthenticated();
    }
}
