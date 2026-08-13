namespace BlobViewer.Models;

public class BlobContainerViewModel
{
    public string Name { get; set; } = string.Empty;
}

public class BlobItemViewModel
{
    public string Name { get; set; } = string.Empty;
    public long? ContentLength { get; set; }
    public DateTimeOffset? LastModified { get; set; }
}

public class BlobListViewModel
{
    public string ContainerName { get; set; } = string.Empty;
    public List<BlobItemViewModel> Blobs { get; set; } = new();
}
