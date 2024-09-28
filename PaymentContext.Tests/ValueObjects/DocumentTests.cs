using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green Refactor
    // Fail test. Pass test. Refactor code. 
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var document = new Document("ABC", EDocumentType.CNPJ);
        Assert.IsTrue(!document.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var document = new Document("17900280000197", EDocumentType.CNPJ);
        Assert.IsTrue(document.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var document = new Document("ABC", EDocumentType.CPF);
        Assert.IsTrue(!document.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("69338728072")]
    [DataRow("02850818020")]
    [DataRow("80605442096")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
        var document = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(document.IsValid);
    }
}