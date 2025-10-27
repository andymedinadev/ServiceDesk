public interface IAttachmentStorage
{
    Task<string> SaveAsync(string fileName, Stream content, CancellationToken ct = default);
}
