﻿using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.Security.Domain.Models;
using InnovaMind.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InnovaMind.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<SocialNetwork> SocialNetworks { get; set; }
    
    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Driverprofile> Driverprofiles { get; set; }
    
    public DbSet<License> Licenses { get; set; }
    
    public DbSet<School> Schools { get; set; }
    
    public DbSet<Education> Educations { get; set; }

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
            .WithMany(p => p.Addresses)
            .HasForeignKey(p => p.UserId);
        
        //Driver
        builder.Entity<Driver>().ToTable("Driver");
        builder.Entity<Driver>().HasKey(p => p.Id);
        builder.Entity<Driver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //Relationsships
        builder.Entity<Driver>()
            .HasOne(p => p.User)
            .WithOne(p => p.Driver)
            .HasForeignKey<Driver>(p => p.UserId);
        
        //Driverprofile
        builder.Entity<Driverprofile>().ToTable("Driverprofile");
        builder.Entity<Driverprofile>().HasKey(p => p.Id);
        builder.Entity<Driverprofile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //Relationsships
        builder.Entity<Driverprofile>()
            .HasOne(p => p.Driver)
            .WithOne(p => p.Driverprofile)
            .HasForeignKey<Driverprofile>(p => p.DriverId);
        builder.Entity<Driverprofile>()
            .HasOne(p => p.License)
            .WithOne(p => p.Driverprofile)
            .HasForeignKey<Driverprofile>(p => p.LicenseId);
        
        //License
        builder.Entity<License>().ToTable("License");
        builder.Entity<License>().HasKey(p => p.Id);
        builder.Entity<License>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        
        //Education
        builder.Entity<Education>().ToTable("Education");
        builder.Entity<Education>().HasKey(p => p.Id);
        builder.Entity<Education>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Education>().Property(p => p.Grade_education).IsRequired();
        //Relationsships
        builder.Entity<Education>()
            .HasOne(p => p.Driverprofile)
            .WithOne(p => p.Education)
            .HasForeignKey<Education>(p => p.DriverprofileId);
        
        //School
        builder.Entity<School>().ToTable("School");
        builder.Entity<School>().HasKey(p => p.Id);
        builder.Entity<School>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<School>().Property(p => p.name_school).IsRequired();
        builder.Entity<School>().Property(p => p.type).IsRequired();
        //Relationsships
        builder.Entity<School>()
            .HasOne(p => p.Education)
            .WithMany(p => p.Schooles)
            .HasForeignKey(p => p.EducationId);

        //Users
        //Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.Role).IsRequired().HasMaxLength(10);
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Description).IsRequired();
       
        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();

    }
}
