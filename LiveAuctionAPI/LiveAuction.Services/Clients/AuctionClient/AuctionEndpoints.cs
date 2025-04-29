namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public static class AuctionEndpoints
    {
        public static string GetAuctionsEndpoint()
            => $"{ServiceHost.AuctionsAPI}/api/v1/auctions";

        public static string GetAuctionEndpoint(Guid auctionId)
            => $"{ServiceHost.AuctionsAPI}/api/v1/auctions/{auctionId}";
    }
}
