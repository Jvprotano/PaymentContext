using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;
public class SubscriptionHandler :
    IHandler<CreatePaypalSubscriptionCommand>,
    IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;
    private bool _valid { get; set; } = true;

    public bool IsValid => _valid;

    public SubscriptionHandler(IStudentRepository documentRepository, IEmailService emailService)
    {
        _repository = documentRepository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreatePaypalSubscriptionCommand command)
    {
        command.Validate();

        if (command.Number == null) // !command.IsValid
            return new CommandResult(false, "Assinatura não realizada.");

        // Check if document is already in use
        if (_repository.ExistDocument(command.Document))
        {
            _valid = false;
            // AddNotification("Document", "Document already exists");

        }

        // Generate VOs 
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, command.PayerDocumentType);
        var email = new Email(command.Email);
        // ...

        // Generate entities 
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new PaypalPayment(
                            command.Number,
                            command.PaidDate,
                            command.ExpireDate,
                            command.Total,
                            command.TotalPaid,
                            document,
                            new Address("st", "123", "neighborhood", "city", "state",
                                "brazil", "zip"),
                            email);

        // Relationships
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        // Group Notifications
        // AddNotifications(name, document, email ...)

        // Save informations 
        _repository.AddSubscription(student);

        // Send welcome email
        _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome!", "Welcome to this course!");

        // Return info
        return new CommandResult(true, "Assinatura realizada com sucesso!");
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        // Implement the same, but changing PayPal for Boleto
        throw new NotImplementedException();
    }
}