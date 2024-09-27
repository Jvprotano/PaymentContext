using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;
[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AddSubscription()
    {
        var subscription = new Subscription(null);
        var student = new Student(new Name("José", "Vinícius"), new Document("testeDoc", Domain.Enums.EDocumentType.CPF), new Email("teste@gmail"));
        student.AddSubscription(subscription);
        // student.FirstName = ""; // Não pode porque coloquei o set private
    }

}