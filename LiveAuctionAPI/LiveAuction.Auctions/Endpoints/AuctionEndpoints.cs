using LiveAuction.Auctions.Services.DataReadServices;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.Auctions.Endpoints
{
    public static class AuctionEndpoints
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var userEndpoints = app.MapGroup("/api/v1/auctions");

            userEndpoints.MapGet("", async([FromQuery] Guid ? ownerId, [FromQuery] int? skip, [FromQuery] int? take, IAuctionDataReadService auctionService)
                => Results.Ok(await auctionService.GetAuctionsAsync(ownerId, skip, take)));

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
