﻿using LiveAuction.Auctions.Models;
using MongoDB.Driver;

namespace LiveAuction.Auctions.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly IMongoCollection<Auction> _auctionsCollection;

        public AuctionRepository(IMongoDatabase database)
        {
            _auctionsCollection = database.GetCollection<Auction>("auctions");
        }

        public async Task CreateAuctionAsync(Auction auction)
        {
            await _auctionsCollection.InsertOneAsync(auction);
        }

        public async Task DeleteAuctionAsync(Guid auctionId)
        {
            await _auctionsCollection.DeleteOneAsync(a => a.Id == auctionId);
        }

        public async Task<Auction?> GetAuctionAsync(Guid auctionId)
        {
            return await _auctionsCollection.Find(a => a.Id == auctionId).FirstOrDefaultAsync();
        }

        public async Task<List<Auction>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            return await _auctionsCollection.Find(a => a.Owner.Id == ownerId.GetValueOrDefault() || ownerId == null)
                .Skip(skip)
                .Limit(take)
                .ToListAsync();
        }

        public async Task UpdateAuctionAsync(Auction auction)
        {
            await _auctionsCollection.ReplaceOneAsync(a => a.Id == auction.Id, auction);
        }
    }
}