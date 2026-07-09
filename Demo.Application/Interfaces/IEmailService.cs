using Demo.Application.DTOs;

namespace Demo.infrastructure.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}