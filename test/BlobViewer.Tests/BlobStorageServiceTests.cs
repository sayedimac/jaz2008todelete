using BlobViewer.Options;
using BlobViewer.Services;
using Microsoft.Extensions.Options;
using Xunit;

namespace BlobViewer.Tests;

public class BlobStorageServiceTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void IsConfigured_ReturnsFalse_WhenConnectionStringIsMissing(string? connectionString)
    {
        var service = CreateService(connectionString);

        Assert.False(service.IsConfigured);
    }

    [Fact]
    public void IsConfigured_ReturnsTrue_WhenConnectionStringIsSet()
    {
        var service = CreateService("UseDevelopmentStorage=true");

        Assert.True(service.IsConfigured);
    }

    [Fact]
    public async Task GetContainersAsync_Throws_WhenNotConfigured()
    {
        var service = CreateService(null);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetContainersAsync());
    }

    [Fact]
    public async Task GetBlobsAsync_Throws_WhenNotConfigured()
    {
        var service = CreateService(null);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetBlobsAsync("container"));
    }

    private static BlobStorageService CreateService(string? connectionString)
    {
        var options = Microsoft.Extensions.Options.Options.Create(new AzureStorageOptions { ConnectionString = connectionString });
        return new BlobStorageService(options);
    }
}
