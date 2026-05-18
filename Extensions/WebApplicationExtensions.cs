namespace Commsflow.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApplicationMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        return app;
    }

    public static WebApplication MapApplicationEndpoints(this WebApplication app)
    {
        app.MapControllers();

        app.MapHealthChecks("/health");

        app.MapGet("/swagger", () => Results.Redirect("/swagger"));

        return app;
    }
}