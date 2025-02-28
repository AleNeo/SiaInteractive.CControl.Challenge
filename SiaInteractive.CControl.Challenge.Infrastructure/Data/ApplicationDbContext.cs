using Microsoft.EntityFrameworkCore;
using SiaInteractive.CControl.Challenge.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace SiaInteractive.CControl.Challenge.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<WindowApp> WindowApps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        
        modelBuilder.Entity<WindowApp>().ToTable("WindowApp");
    }
}
