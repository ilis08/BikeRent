using BikeRent.Application.Email;

namespace BikeRent.Infrastructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(string recipient, string subject, string body)
        {
            Console.WriteLine($"{recipient} {subject} {body}");

            return Task.CompletedTask;
        }
    }
}
