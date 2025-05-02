using LiveAuction.Common.DTO;
using System.Text;

namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public class AuctionClient : BaseClient, IAuctionClient
    {
        public AuctionClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId)
            => await GetAsync<AuctionBiddingDTO>(AuctionEndpoints.GetAuctionEndpoint(auctionId));

        public async Task<IEnumerable<AuctionBiddingDTO>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            var route = new StringBuilder(AuctionEndpoints.GetAuctionsEndpoint(skip, take));

            if (ownerId.HasValue)
            {
                route.Append($"&ownerId={ownerId.Value}");
            }

            return await GetAsync<IEnumerable<AuctionBiddingDTO>>(route.ToString());
        }
    }
}
