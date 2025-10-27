using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceDesk.Domain.Entities;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> e)
    {
        e.HasKey(x => x.Id);
        e.Property(x => x.Title).IsRequired().HasMaxLength(200);
        e.Property(x => x.Description).IsRequired();

        e.Property(x => x.Status).HasConversion<int>().IsRequired();
        e.Property(x => x.Priority).HasConversion<int>().IsRequired();

        e.HasOne(x => x.Category)
            .WithMany(c => c.Tickets)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        e.HasOne(x => x.CreatedBy)
            .WithMany(u => u.CreatedTickets)
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        e.HasOne(x => x.AssignedTo)
            .WithMany(u => u.AssignedTickets)
            .HasForeignKey(x => x.AssignedToId)
            .OnDelete(DeleteBehavior.SetNull);

        e.HasMany(x => x.Comments).WithOne(c => c.Ticket).HasForeignKey(c => c.TicketId);

        e.HasMany(x => x.StatusHistory).WithOne(h => h.Ticket).HasForeignKey(h => h.TicketId);
    }
}
