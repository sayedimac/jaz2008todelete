namespace BlobViewer.Options;

/// <summary>
/// Options bound from configuration for connecting to Azure Blob Storage.
/// </summary>
public class AzureStorageOptions
{
    public const string SectionName = "AzureStorage";

    /// <summary>
    /// The Azure Storage connection string. This can be supplied via:
    /// - appsettings.json / appsettings.Development.json under "AzureStorage:ConnectionString"
    /// - An environment variable named "AzureStorage__ConnectionString" (standard ASP.NET Core config override)
    /// - An Azure App Service Application Setting named "AZURE_STORAGE_CONNECTION_STRING"
    /// </summary>
    public string? ConnectionString { get; set; }
}
