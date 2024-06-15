﻿namespace BikeRent.Application.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Users.Email recipient, string subject, string body);
}
