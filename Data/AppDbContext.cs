using Microsoft.EntityFrameworkCore;

namespace Commsflow.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Template> Templates { get; set; }
    public DbSet<Domain.Entities.CommunicationJob> CommunicationJobs { get; set; }
}