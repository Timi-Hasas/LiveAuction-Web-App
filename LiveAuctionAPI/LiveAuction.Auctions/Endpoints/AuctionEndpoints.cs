using LiveAuction.Auctions.Services.DataReadServices;

namespace LiveAuction.Auctions.Endpoints
{
    public static class AuctionEndpoints
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var userEndpoints = app.MapGroup("/api/v1/auctions");

            userEndpoints.MapGet("", async (IAuctionDataReadService auctionService)
                => Results.Ok(await auctionService.GetAuctionsAsync()));

            userEndpoints.MapGet("/{auctionId}",
                async (Guid auctionId, IAuctionDataReadService auctionService) =>
                {
                    var result = await auctionService.GetAuctionAsync(auctionId);

                    return result == null
                        ? Results.NotFound()
                        : Results.Ok(result);
                });
        }
    }
}
