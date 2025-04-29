using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public class AuctionClient : BaseClient, IAuctionClient
    {
        public AuctionClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<AuctionDTO?> GetAuctionAsync(Guid auctionId)
            => await GetAsync<AuctionDTO>(AuctionEndpoints.GetAuctionEndpoint(auctionId));

        public async Task<IEnumerable<AuctionDTO>?> GetAuctionsAsync()
            => await GetAsync<IEnumerable<AuctionDTO>>(AuctionEndpoints.GetAuctionsEndpoint());
    }
}
