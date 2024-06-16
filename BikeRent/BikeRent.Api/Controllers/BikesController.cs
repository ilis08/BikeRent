using BikeRent.Application.Bikes.SearchBikes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly ISender sender;

        public BikesController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchBikes(
            [FromQuery] string name,
            CancellationToken cancellationToken)
        {
            var query = new SearchBikesQuery(name);

            var result = await sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
