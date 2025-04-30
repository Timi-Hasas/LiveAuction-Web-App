using LiveAuction.Biddings.Models;
using MongoDB.Driver;

namespace LiveAuction.Biddings.Repositories
{
    public class BiddingRepository : IBiddingRepository
    {
        private readonly IMongoCollection<Bidding> _biddingsCollection;

        public BiddingRepository(IMongoDatabase database)
        {
            _biddingsCollection = database.GetCollection<Bidding>("biddings");
        }

        public async Task CreateBiddingAsync(Bidding bidding)
        {
            await _biddingsCollection.InsertOneAsync(bidding);
        }

        public async Task UpdateBiddingsAsync(Guid auctionId)
        {
            await _biddingsCollection.UpdateManyAsync(b => b.Auction.Id == auctionId,
                Builders<Bidding>.Update.Set(b => b.IsActive, false));
        }

        public async Task<Bidding?> GetBiddingAsync(Guid biddingId)
        {
            return await _biddingsCollection.Find(b => b.Id == biddingId).FirstOrDefaultAsync();
        }

        public async Task<List<Bidding>?> GetBiddingsAsync()
        {
            return await _biddingsCollection.Find(_ => true).ToListAsync();
        }
    }
}