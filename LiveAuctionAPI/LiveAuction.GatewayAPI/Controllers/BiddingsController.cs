using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Services.Interfaces;
using LiveAuction.GatewayAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.GatewayAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/biddings")]
    public class BiddingsController : ControllerBase
    {
        private readonly IBiddingService _biddingService;

        public BiddingsController(IBiddingService biddingService)
        {
            _biddingService = biddingService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBidding([FromBody] PlaceBiddingDTO bidding)
        {
            await _biddingService.PlaceBiddingAsync(bidding);

            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> GetBiddings([FromQuery] Guid? ownerId, [FromQuery] int? skip = 0, [FromQuery] int? take = 10)
        {
            var result = await _biddingService.GetBiddingsAsync(ownerId, skip, take);

            return Ok(result);
        }

        [HttpGet("{biddingId}")]
        public async Task<IActionResult> GetBidding(Guid biddingId)
        {
            var result = await _biddingService.GetBiddingAsync(biddingId);

            return Ok(result);
        }
    }
}
