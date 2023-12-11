using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure;

public class UserContext : DbContext
{
    public DbSet<User.State> Users { get; set; }

    public UserContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AggregateInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var userBuilder = modelBuilder.Entity<User.State>();
        userBuilder.HasKey(x => x.Id);
        userBuilder.Ignore(x => x.Root);
    }
}
