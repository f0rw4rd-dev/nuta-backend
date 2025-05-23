using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuta.Backend.BuildingBlocks.Infrastructure.Inbox;
using Nuta.Backend.BuildingBlocks.Infrastructure.Outbox;
using Nuta.Backend.Users.Domain.Aggregates;
using Nuta.Backend.Users.Options;

namespace Nuta.Backend.Users.Infrastructure.Postgres;

public class UsersModuleDbContext(
    DbContextOptions<UsersModuleDbContext> options,
    IOptions<UsersModuleOptions> moduleOptions)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    
    public DbSet<InboxMessage> InboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(moduleOptions.Value.Postgres.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersModuleDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}