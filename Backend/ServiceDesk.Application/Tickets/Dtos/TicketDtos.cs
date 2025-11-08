using ServiceDesk.Domain.Entities;

public record TicketCommentDto(int Id, int AuthorId, string Body, DateTime CreatedAt);

public record TicketAttachmentDto(
    int Id,
    string FileName,
    string ContentType,
    long SizeBytes,
    int UploadedById,
    DateTime CreatedAt
);

public record TicketStatusHistoryDto(
    int Id,
    TicketStatus FromStatus,
    TicketStatus ToStatus,
    int ChangedById,
    DateTime ChangedAt
);

public record TicketSummaryDto(
    int Id,
    string Title,
    string Category,
    TicketStatus Status,
    TicketPriority Priority,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? ClosedAt
);

public record TicketDetailDto(
    int Id,
    string Title,
    string Description,
    string Category,
    TicketStatus Status,
    TicketPriority Priority,
    int CreatedById,
    int? AssignedToId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? ClosedAt,
    IReadOnlyCollection<TicketCommentDto> Comments,
    IReadOnlyCollection<TicketAttachmentDto> Attachments,
    IReadOnlyCollection<TicketStatusHistoryDto> StatusHistory
);
