using InnovaMind.API.InnovaMind.Domain.Repositories;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Persistence.Repositories;
using InnovaMind.API.InnovaMind.Services;
using InnovaMind.API.Security.Authorization.Handlers.Implementations;
using InnovaMind.API.Security.Authorization.Handlers.Interfaces;
using InnovaMind.API.Security.Authorization.Middleware;
using InnovaMind.API.Security.Authorization.Settings;
using InnovaMind.API.Security.Domain.Repositories;
using InnovaMind.API.Security.Domain.Services;
using InnovaMind.API.Security.Persistence.Repositories;
using InnovaMind.API.Security.Services;
using InnovaMind.API.Shared.Domain.Repositories;
using InnovaMind.API.Shared.Persistence.Contexts;
using InnovaMind.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors();

//Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    //Add API Documentation Information

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "INNOVAMIND Profile+ Center API",
        Description = "INNOVAMIND Profile+ Center API RESTful API",
        TermsOfService = new Uri("https://innova-mind.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "INNOVAMIND.studio",
            Url = new Uri ("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "INNOVAMIND Learning Center Resources License",
            Url = new Uri("https://innova-mind.com/license")
        }
    });
    options.EnableAnnotations();
});

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

//Add lowecase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

//Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// InnovaMind Injection Configuration
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
builder.Services.AddScoped<ISocialNetworkService, SocialNetworkService>();
// Security Injection Configuration

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(InnovaMind.API.InnovaMind.Mapping.ModelToResourceProfile),
    typeof(InnovaMind.API.Security.Mapping.ModelToResourceProfile),
     typeof(InnovaMind.API.InnovaMind.Mapping.ResourceToModelProfile),
    typeof(InnovaMind.API.Security.Mapping.ResourceToModelProfile)
    );

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
