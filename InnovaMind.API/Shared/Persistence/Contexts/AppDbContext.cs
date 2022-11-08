using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Security.Domain.Models;
using InnovaMind.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<SocialNetwork> SocialNetworks { get; set; }

    public DbSet<Address> Address { get; set; }

    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base (options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Social Network
        builder.Entity<SocialNetwork>().ToTable("SocialNetwork");
        builder.Entity<SocialNetwork>().HasKey(p => p.Id);
        builder.Entity<SocialNetwork>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SocialNetwork>().Property(p => p.NameSocialNetwork).IsRequired().HasMaxLength(100);
        builder.Entity<SocialNetwork>().Property(p => p.UrlSocialNetwork).IsRequired().HasMaxLength(500);
        //Relationsships
        builder.Entity<SocialNetwork>()
            .HasOne(p => p.User)
            .WithMany(p => p.SocialNetworks)
            .HasForeignKey(p => p.UserId);
        //Address
        builder.Entity<Address>().ToTable("Address");
        builder.Entity<Address>().HasKey(p => p.Id);
        builder.Entity<Address>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Address>().Property(p => p.NameAddress).IsRequired().HasMaxLength(500);
        //Relationsships
        builder.Entity<Address>()
            .HasOne(p => p.User)
            .WithMany(p => p.Address)
            .HasForeignKey(p => p.UserId);

        //Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.UserName).IsRequired();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.Role).IsRequired().HasMaxLength(10);
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Description);
       
        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();

    }
}
