using FluentValidation;

public class CloseTicketCommandValidator : AbstractValidator<CloseTicketCommand>
{
    public CloseTicketCommandValidator()
    {
        RuleFor(c => c.TicketId).GreaterThan(0);

        RuleFor(c => c.ClosedById).NotEmpty();
    }
}
