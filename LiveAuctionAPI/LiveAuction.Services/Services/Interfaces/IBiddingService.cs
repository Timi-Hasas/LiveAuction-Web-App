using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services.Interfaces
{
    public interface IBiddingService
    {
        Task PlaceBiddingAsync(PlaceBiddingDTO bidding);
    }
}
