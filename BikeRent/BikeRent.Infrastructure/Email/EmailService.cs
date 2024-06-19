using BikeRent.Application.Email;
using Microsoft.Extensions.Logging;

namespace BikeRent.Infrastructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> logger;

        public EmailService(ILogger<EmailService> logger)
        {
            this.logger = logger;
        }

        public Task SendAsync(string recipient, string subject, string body)
        {
            logger.LogWarning($"{recipient} {subject} {body}");

            return Task.CompletedTask;
        }
    }
}
