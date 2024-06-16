using BikeRent.Application.Email;

namespace BikeRent.Infrastructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
