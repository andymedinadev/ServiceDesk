namespace ServiceDesk.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
