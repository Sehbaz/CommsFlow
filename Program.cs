
using Microsoft.EntityFrameworkCore;
using Commsflow.Data;
using Commsflow.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddHealthChecks();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseApplicationMiddleware();

app.MapApplicationEndpoints();

app.Run();

