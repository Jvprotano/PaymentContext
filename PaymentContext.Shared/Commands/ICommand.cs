namespace PaymentContext.Shared.Commands;
public interface ICommand
{
    void Validate();
    bool IsValid() => false;
}