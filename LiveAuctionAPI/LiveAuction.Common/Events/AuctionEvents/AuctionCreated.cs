using LiveAuction.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveAuction.Common.Events.AuctionEvents
{
    public class AuctionCreated
    {
        public AuctionDTO Auction { get; set; }
    }
}
