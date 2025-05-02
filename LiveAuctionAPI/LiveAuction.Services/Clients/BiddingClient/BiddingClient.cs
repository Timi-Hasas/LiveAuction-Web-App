using LiveAuction.Common.DTO;
using System.Text;

namespace LiveAuction.Gateway.Services.Clients.BiddingClient
{
    public class BiddingClient : BaseClient, IBiddingClient
    {
        public BiddingClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId)
            => await GetAsync<BiddingAuctionDTO>(BiddingEndpoints.GetBiddingEndpoint(biddingId));

        public async Task<IEnumerable<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            var route = new StringBuilder(BiddingEndpoints.GetBiddingsEndpoint(skip, take));

            if (ownerId.HasValue)
            {
                route.Append($"&ownerId={ownerId.Value}");
            }
            
            return await GetAsync<IEnumerable<BiddingAuctionDTO>>(route.ToString());
        }
    }
}
