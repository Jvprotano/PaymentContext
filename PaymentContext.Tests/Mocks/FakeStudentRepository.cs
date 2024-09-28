using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks;
public class FakeStudentRepository : IStudentRepository
{
    public void AddSubscription(Student student)
    {

    }

    public bool ExistDocument(string documentNumber)
    {
        if (documentNumber == "1234567891011")
            return true;

        return false;
    }
}