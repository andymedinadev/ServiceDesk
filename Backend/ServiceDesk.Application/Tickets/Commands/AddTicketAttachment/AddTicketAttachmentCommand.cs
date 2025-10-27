public record AddTicketAttachmentCommand(
    int TicketId,
    string FileName,
    Stream Content,
    Guid UploadedById
);
