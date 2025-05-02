namespace LiveAuction.Gateway.Services.Clients.BiddingClient
{
    public class BiddingEndpoints
    {
        public static string GetBiddingsEndpoint(int? skip = 0, int? take = 10) 
            => $"{ServiceHost.BiddingsAPI}/api/v1/biddings?skip={skip}&take={take}";

        public static string GetBiddingEndpoint(Guid biddingId)
            => $"{ServiceHost.BiddingsAPI}/api/v1/biddings/{biddingId}";
    }
}
