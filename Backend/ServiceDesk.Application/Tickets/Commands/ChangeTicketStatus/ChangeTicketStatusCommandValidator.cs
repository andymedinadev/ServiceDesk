using FluentValidation;

public class ChangeTicketStatusCommandValidator : AbstractValidator<ChangeTicketStatusCommand>
{
    public ChangeTicketStatusCommandValidator()
    {
        RuleFor(c => c.TicketId).GreaterThan(0);

        RuleFor(c => c.NewStatus).IsInEnum();

        RuleFor(c => c.ChangedById).GreaterThan(0);
    }
}
