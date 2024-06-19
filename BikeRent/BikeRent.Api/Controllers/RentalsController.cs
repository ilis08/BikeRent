using BikeRent.Application.Rentals.RentBike;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly ISender sender;

        public RentalsController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> RentBike(
            [FromBody] RentBikeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            return Ok(result.Value);
        }
    }
}
