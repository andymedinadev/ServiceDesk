using FluentValidation;

public class SetTicketPriorityCommandValidator : AbstractValidator<SetTicketPriorityCommand>
{
    public SetTicketPriorityCommandValidator()
    {
        RuleFor(c => c.TicketId).GreaterThan(0);

        RuleFor(c => c.Priority).IsInEnum();

        RuleFor(c => c.ChangedById).GreaterThan(0);
    }
}
