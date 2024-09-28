namespace PaymentContext.Domain.Services;
public interface IEmailService
{
    void Send(string name, string address, string subject, 
        string body);
}