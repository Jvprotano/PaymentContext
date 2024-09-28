using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;
[TestClass]
public class StudentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenHasActiveSubscription()
    {
        var name = new Name("José", "Vinícius");
        var document = new Document("testeDoc", Domain.Enums.EDocumentType.CPF);
        var subscription = new Subscription(null);
        var email = new Email("teste@gmail");
        var student = new Student(name, document, email);
        
        student.AddSubscription(subscription);
        // student.FirstName = ""; // Não pode porque coloquei o set private
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenHasNoActiveSubscription()
    {
                var name = new Name("José", "Vinícius");
        var document = new Document("testeDoc", Domain.Enums.EDocumentType.CPF);
        var subscription = new Subscription(null);
        var email = new Email("teste@gmail");
        var student = new Student(name, document, email);
        
        student.AddSubscription(subscription);

        Assert.IsTrue(student.HasActiveSubscription());
    }

}