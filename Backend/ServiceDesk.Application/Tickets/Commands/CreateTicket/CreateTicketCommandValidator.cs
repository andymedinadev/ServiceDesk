using FluentValidation;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MaximumLength(200);

        RuleFor(c => c.Description).NotEmpty();

        RuleFor(c => c.CategoryId).GreaterThan(0);

        RuleFor(c => c.CreatedById).NotEmpty();
    }
}
