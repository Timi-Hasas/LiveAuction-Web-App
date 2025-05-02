using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Services.Interfaces;
using LiveAuction.GatewayAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.GatewayAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/auctions")]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuctions([FromQuery] Guid? ownerId, [FromQuery]  int? skip = 0, [FromQuery] int? take = 10)
        {
            var result = await _auctionService.GetAuctionsAsync(ownerId, skip, take);

            return Ok(result);
        }

        [HttpGet("{auctionId}")]
        public async Task<IActionResult> GetAuctionById(Guid auctionId)
        {
            var result = await _auctionService.GetAuctionAsync(auctionId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction([FromBody] AuctionDTO auction)
        {
             await _auctionService.CreateAuctionAsync(auction);

            return Accepted();
        }

        [HttpPut("{auctionId}")]
        public async Task<IActionResult> UpdateAuction(Guid auctionId, [FromBody] AuctionDTO auction)
        {
            auction.Id = auctionId;

            await _auctionService.UpdateAuctionAsync(auction);

            return Accepted();
        }

        [HttpPut("{auctionId}/complete")]
        public async Task<IActionResult> CompleteAuction(Guid auctionId)
        {
            await _auctionService.CompleteAuctionAsync(auctionId);

            return Accepted();
        }

        [HttpDelete("{auctionId}")]
        public async Task<IActionResult> DeleteAuction(Guid auctionId)
        {
            await _auctionService.DeleteAuctionAsync(auctionId);

            return Accepted();
        }
    }
}
