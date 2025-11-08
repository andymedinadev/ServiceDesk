using FluentValidation;

public class UpdateTicketDetailsCommandValidator : AbstractValidator<UpdateTicketDetailsCommand>
{
    public UpdateTicketDetailsCommandValidator()
    {
        RuleFor(c => c.TicketId).GreaterThan(0);

        RuleFor(c => c.Title).NotEmpty().MaximumLength(200);

        RuleFor(c => c.Description).NotEmpty();

        RuleFor(c => c.CategoryId).GreaterThan(0);

        RuleFor(c => c.UpdatedById).NotEmpty();
    }
}
