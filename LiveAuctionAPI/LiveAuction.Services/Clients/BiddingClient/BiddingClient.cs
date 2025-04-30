using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.BiddingClient
{
    public class BiddingClient : BaseClient, IBiddingClient
    {
        public BiddingClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId)
            => await GetAsync<BiddingAuctionDTO>(BiddingEndpoints.GetBiddingEndpoint(biddingId));

        public async Task<IEnumerable<BiddingAuctionDTO>?> GetBiddingsAsync()
            => await GetAsync<IEnumerable<BiddingAuctionDTO>>(BiddingEndpoints.GetBiddingsEndpoint());
    }
}
