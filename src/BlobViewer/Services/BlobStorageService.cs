using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobViewer.Models;
using BlobViewer.Options;
using Microsoft.Extensions.Options;

namespace BlobViewer.Services;

public interface IBlobStorageService
{
    /// <summary>
    /// Indicates whether a connection string has been configured.
    /// </summary>
    bool IsConfigured { get; }

    Task<IReadOnlyList<BlobContainerViewModel>> GetContainersAsync(CancellationToken cancellationToken = default);

    Task<BlobListViewModel> GetBlobsAsync(string containerName, CancellationToken cancellationToken = default);
}

public class BlobStorageService : IBlobStorageService
{
    private readonly string? _connectionString;

    public BlobStorageService(IOptions<AzureStorageOptions> options)
    {
        _connectionString = options.Value.ConnectionString;
    }

    public bool IsConfigured => !string.IsNullOrWhiteSpace(_connectionString);

    private BlobServiceClient CreateClient()
    {
        if (!IsConfigured)
        {
            throw new InvalidOperationException(
                "Azure Storage connection string is not configured. Set 'AzureStorage:ConnectionString' " +
                "in appsettings.json, the 'AzureStorage__ConnectionString' environment variable, or the " +
                "'AZURE_STORAGE_CONNECTION_STRING' Azure App Service application setting.");
        }

        return new BlobServiceClient(_connectionString);
    }

    public async Task<IReadOnlyList<BlobContainerViewModel>> GetContainersAsync(CancellationToken cancellationToken = default)
    {
        var client = CreateClient();
        var containers = new List<BlobContainerViewModel>();

        await foreach (var container in client.GetBlobContainersAsync(cancellationToken: cancellationToken))
        {
            containers.Add(new BlobContainerViewModel { Name = container.Name });
        }

        return containers;
    }

    public async Task<BlobListViewModel> GetBlobsAsync(string containerName, CancellationToken cancellationToken = default)
    {
        var client = CreateClient();
        var containerClient = client.GetBlobContainerClient(containerName);
        var result = new BlobListViewModel { ContainerName = containerName };

        await foreach (BlobItem blobItem in containerClient.GetBlobsAsync(cancellationToken: cancellationToken))
        {
            result.Blobs.Add(new BlobItemViewModel
            {
                Name = blobItem.Name,
                ContentLength = blobItem.Properties.ContentLength,
                LastModified = blobItem.Properties.LastModified
            });
        }

        return result;
    }
}
