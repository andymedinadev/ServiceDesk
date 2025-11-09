using FluentValidation;

public class AssignTicketCommandValidator : AbstractValidator<AssignTicketCommand>
{
    public AssignTicketCommandValidator()
    {
        RuleFor(c => c.TicketId).GreaterThan(0);

        RuleFor(c => c.AssignedToId).GreaterThan(0).When(x => x.AssignedToId.HasValue);

        RuleFor(c => c.ChangedById).GreaterThan(0);
    }
}
