using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlagiarismAnalyzer.Models;

namespace PlagiarismAnalyzer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index([FromForm] string? filename = null)
    {
        AnalyzerResult aRes = new();
        aRes.Running = false;

        if (string.IsNullOrEmpty(filename))
        {
            return View(aRes);
        }

        aRes.Running = true;
        aRes.PlagiarismResult = FileReader.AnalyzeTarget(filename);
        aRes.SourceText = FileReader.GetSourceText(filename);

        return View(aRes);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
