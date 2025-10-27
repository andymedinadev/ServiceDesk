public class AttachmentStorage : IAttachmentStorage
{
    public Task<string> SaveAsync(string fileName, Stream content, CancellationToken ct = default)
    {
        // ToDo -> implementar persistencia
        return Task.FromResult($"attachments/{Guid.NewGuid()}_{fileName}");
    }
}
