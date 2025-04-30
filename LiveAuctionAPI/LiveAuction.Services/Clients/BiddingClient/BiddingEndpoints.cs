namespace LiveAuction.Gateway.Services.Clients.BiddingClient
{
    public class BiddingEndpoints
    {
        public static string GetBiddingsEndpoint() 
            => $"{ServiceHost.BiddingsAPI}/api/v1/biddings";

        public static string GetBiddingEndpoint(Guid biddingId)
            => $"{ServiceHost.BiddingsAPI}/api/v1/biddings/{biddingId}";
    }
}
