using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;
[TestClass]
public class SubscriptionHandlerTest
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreatePaypalSubscriptionCommand();

        command.FirstName = "Jose";
        command.LastName = "Vinicius";
        command.Document = "1234567891011";
        command.Number = "123";
        command.Email = "test@gmail.com";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.PayerDocument = "1234567891011";
        command.PayerDocumentType = Domain.Enums.EDocumentType.CPF;
        command.Address = new Address("st", "123", "neighborhood", "city", "state",
                                "brazil", "zip");

        handler.Handle(command);
        Assert.IsFalse(handler.IsValid);
    }
}