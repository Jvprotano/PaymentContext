using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;
public class PaypalPayment : Payment
{
    public PaypalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total,
                            decimal totalPaid, Document document, Address address, Email email)
                            : base(paidDate, expireDate, total, totalPaid, document, address, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}