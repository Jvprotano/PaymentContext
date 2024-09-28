using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories;
public interface IStudentRepository
{
    bool ExistDocument(string documentNumber);
    void AddSubscription(Student student);
}