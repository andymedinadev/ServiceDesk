using FluentValidation;

public class AddTicketAttachmentCommandValidator : AbstractValidator<AddTicketAttachmentCommand>
{
    public AddTicketAttachmentCommandValidator()
    {
        RuleFor(c => c.TicketId).GreaterThan(0);

        RuleFor(c => c.FileName).NotEmpty();

        RuleFor(c => c.Content)
            .NotNull()
            .Must(content => content.CanRead)
            .WithMessage("Attachment content must be readable.");

        RuleFor(c => c.UploadedById).GreaterThan(0);
    }
}
