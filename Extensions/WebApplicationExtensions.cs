namespace Commsflow.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApplicationMiddleware(this WebApplication app)
    {
        app.UseMiddleware<Commsflow.Middleware.ExceptionHandlingMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI();

        if (app.Environment.IsDevelopment())
        {
            app.UseHttpsRedirection();
        }

        app.UseAuthorization();

        return app;
    }

    public static WebApplication MapApplicationEndpoints(this WebApplication app)
    {
        app.MapControllers();

        app.MapHealthChecks("/health");

        app.MapGet("/", () => Results.Redirect("/swagger"));

        return app;
    }
}