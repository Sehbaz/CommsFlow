using Microsoft.EntityFrameworkCore;

namespace Commsflow.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Models.Template> Templates { get; set; }
    public DbSet<Models.CommunicationJob> CommunicationJobs { get; set; }
}