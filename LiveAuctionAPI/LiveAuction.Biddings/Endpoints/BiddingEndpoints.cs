using LiveAuction.Biddings.Services.DataReadServices;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.Biddings.Endpoints
{
    public static class BiddingEndpoints
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var userEndpoints = app.MapGroup("/api/v1/biddings");

            userEndpoints.MapGet("", async ([FromQuery] Guid? ownerId, [FromQuery] int? skip, [FromQuery] int? take, IBiddingDataReadService biddingService)
                => Results.Ok(await biddingService.GetBiddingsAsync(ownerId, skip, take)));

            userEndpoints.MapGet("/{biddingId}",
                async (Guid biddingId, IBiddingDataReadService biddingService) =>
                {
                    var result = await biddingService.GetBiddingAsync(biddingId);

                    return result == null
                        ? Results.NotFound()
                        : Results.Ok(result);
                });
        }
    }
}
