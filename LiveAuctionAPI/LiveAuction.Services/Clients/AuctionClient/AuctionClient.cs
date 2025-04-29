using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public class AuctionClient : BaseClient, IAuctionClient
    {
        public AuctionClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId)
            => await GetAsync<AuctionBiddingDTO>(AuctionEndpoints.GetAuctionEndpoint(auctionId));

        public async Task<IEnumerable<AuctionBiddingDTO>?> GetAuctionsAsync()
            => await GetAsync<IEnumerable<AuctionBiddingDTO>>(AuctionEndpoints.GetAuctionsEndpoint());
    }
}
