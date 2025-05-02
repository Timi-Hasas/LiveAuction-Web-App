using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.BiddingClient
{
    public interface IBiddingClient
    {
        Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId);

        Task<IEnumerable<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10);
    }
}
