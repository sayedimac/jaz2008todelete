using BlobViewer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlobViewer.Controllers;

public class BlobsController : Controller
{
    private readonly IBlobStorageService _blobStorageService;

    public BlobsController(IBlobStorageService blobStorageService)
    {
        _blobStorageService = blobStorageService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        if (!_blobStorageService.IsConfigured)
        {
            ViewBag.NotConfigured = true;
            return View(Array.Empty<Models.BlobContainerViewModel>());
        }

        var containers = await _blobStorageService.GetContainersAsync(cancellationToken);
        return View(containers);
    }

    public async Task<IActionResult> Container(string name, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Container name is required.");
        }

        if (!_blobStorageService.IsConfigured)
        {
            return RedirectToAction(nameof(Index));
        }

        var model = await _blobStorageService.GetBlobsAsync(name, cancellationToken);
        return View(model);
    }
}
