# jaz2008todelete
Web app for showing azure storage blobs

## BlobViewer

An ASP.NET Core MVC web app (net10.0) that lists Azure Storage containers and blobs.

### Running locally

The app is located at `src/BlobViewer`.

```bash
cd src/BlobViewer
dotnet run
```

### Configuring the Azure Storage connection string

The connection string can be supplied in any of the following ways (checked in order):

1. **appsettings.json / appsettings.Development.json** — set `AzureStorage:ConnectionString`.
2. **Environment variable** `AzureStorage__ConnectionString` (the standard ASP.NET Core configuration
   override syntax, using a double underscore in place of the `:` separator). This works both locally
   and when deployed.
3. **Azure App Service Application Setting** named `AZURE_STORAGE_CONNECTION_STRING`. This lets you
   configure the connection string directly from the Azure Portal (or via IaC) without needing to know
   the nested configuration key syntax.

If no connection string is configured, the Blobs page will display a message explaining how to set one
instead of failing.
