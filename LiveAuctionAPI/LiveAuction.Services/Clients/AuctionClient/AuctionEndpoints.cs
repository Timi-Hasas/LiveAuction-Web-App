namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public static class AuctionEndpoints
    {
        public static string GetAuctionsEndpoint(int? skip = 0, int? take = 10)
            => $"{ServiceHost.AuctionsAPI}/api/v1/auctions?skip={skip}&take={take}";

        public static string GetAuctionEndpoint(Guid auctionId)
            => $"{ServiceHost.AuctionsAPI}/api/v1/auctions/{auctionId}";
    }
}
