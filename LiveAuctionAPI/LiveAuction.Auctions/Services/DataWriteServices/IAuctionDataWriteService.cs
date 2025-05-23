﻿using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataWriteServices
{
    public interface IAuctionDataWriteService
    {

        Task CreateAuctionAsync(AuctionBiddingDTO auction);

        Task UpdateAuctionAsync(AuctionBiddingDTO auction);

        Task DeleteAuctionAsync(Guid auctionId);

        Task PlaceAuctionBiddingAsync(BiddingAuctionDTO bidding);

        Task CompleteAuctionAsync(Guid auctionId);
    }
}
