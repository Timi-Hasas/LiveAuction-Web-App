using LiveAuction.Biddings.Services.DataReadServices;

namespace LiveAuction.Biddings.Endpoints
{
    public static class BiddingEndpoints
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var userEndpoints = app.MapGroup("/api/v1/biddings");

            userEndpoints.MapGet("", async (IBiddingDataReadService biddingService)
                => Results.Ok(await biddingService.GetBiddingsAsync()));

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
