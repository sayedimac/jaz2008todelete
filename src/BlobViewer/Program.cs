using BlobViewer.Options;
using BlobViewer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Bind Azure Storage options from configuration (appsettings.json, environment variables, etc.).
builder.Services.AddOptions<AzureStorageOptions>()
    .Bind(builder.Configuration.GetSection(AzureStorageOptions.SectionName));

// Allow the connection string to also be supplied via the "AZURE_STORAGE_CONNECTION_STRING"
// environment variable, matching how Azure App Service application settings are typically named.
builder.Services.PostConfigure<AzureStorageOptions>(options =>
{
    if (string.IsNullOrWhiteSpace(options.ConnectionString))
    {
        options.ConnectionString = builder.Configuration["AZURE_STORAGE_CONNECTION_STRING"]
            ?? Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
    }
});

builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
