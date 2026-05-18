using Commsflow.DTOs;
using Commsflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commsflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenerateController : ControllerBase
{
    private readonly Data.AppDbContext _context;

    public GenerateController(Data.AppDbContext context)
    {
        _context = context;
    }

    // post request to generate communication job
    [HttpPost]
    public async Task<IActionResult> Generate(GenerateRequest request)
    {
        var template = await _context.Templates.FindAsync(request.TemplateId);

        if (template == null)
        {
            return NotFound("Template not found");
        }

        var generatedContent = template.Content
            .Replace("{Name}", request.Name)
            .Replace("{Invoice}", request.Invoice);

        var job = new CommunicationJob
        {
            RecipientName = request.Name,
            RecipientEmail = request.Email,
            GeneratedContent = generatedContent,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.CommunicationJobs.Add(job);

        await _context.SaveChangesAsync();

        return Ok(job);

    }
}