using Commsflow.Controllers;
using Commsflow.Data;
using Commsflow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CommsFlow.Tests;

public class TemplatesControllerTests
{
    private AppDbContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetTemplates_ReturnsEmptyList_WhenNoTemplates()
    {
        var context = GetInMemoryContext();
        var controller = new TemplatesController(context);

        var result = await controller.GetTemplates();

        Assert.NotNull(result.Value);
        Assert.Empty(result.Value);
    }

    [Fact]
    public async Task CreateTemplate_ReturnsCreatedTemplate()
    {
        var context = GetInMemoryContext();
        var controller = new TemplatesController(context);
        var template = new Template { Name = "Test", Content = "Hello {Name}" };

        var result = await controller.CreateTemplate(template);

        var ok = Assert.IsType<OkObjectResult>(result.Result);
        var created = Assert.IsType<Template>(ok.Value);
        Assert.Equal("Test", created.Name);
    }
}