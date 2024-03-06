using JwtAuthentication.Areas.Identity.Data;
using JwtAuthentication.Areas.Identity.Data.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Data;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<RefreshToken> RefreshToken { get; set; }
     public DbSet<UserAccounts> UserAccounts { get; set; }
     public DbSet<Students> Students { get; set; }
     public DbSet<PhoneNumber> PhoneNumber { get; set; } 
     public DbSet<Address> Address { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
