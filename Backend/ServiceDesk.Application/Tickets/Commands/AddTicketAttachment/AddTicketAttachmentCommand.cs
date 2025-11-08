public record AddTicketAttachmentCommand(
    int TicketId,
    string FileName,
    Stream Content,
    int UploadedById
);
