using BikeRent.Application.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender sender;

        public UsersController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> RentBike(
            [FromBody] RegisterUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            return Ok(result.Value);
        }
    }
}
