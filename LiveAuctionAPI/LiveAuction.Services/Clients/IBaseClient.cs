namespace LiveAuction.Gateway.Services.Clients
{
    public interface IBaseClient
    {
        Task<T?> GetAsync<T>(string route);
    }
}
