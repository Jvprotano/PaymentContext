using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks;
public class FakeEmailService : IEmailService
{
    public void Send(string name, string address, string subject, string body)
    {
        
    }
}