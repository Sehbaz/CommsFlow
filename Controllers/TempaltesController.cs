using Commsflow.Data;
using Commsflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Commsflow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplatesController: ControllerBase
{
    private readonly AppDbContext _context;

    public TemplatesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Template>>> GetTemplates()
    {
        return  await _context.Templates.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Template>> CreateTemplate(Template template)
    {
        _context.Templates.Add(template);
        await _context.SaveChangesAsync();
        return Ok(template);
    }
}