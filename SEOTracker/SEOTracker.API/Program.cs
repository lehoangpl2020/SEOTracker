using SEOTracker.Application;
using SEOTracker.Application.Interfaces;
using SEOTracker.Core.Enums;
using SEOTracker.Infrastructure;
using SEOTracker.Infrastructure.Data;
using SEOTracker.Infrastructure.Services.Scrapers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<GoogleScraper>();
builder.Services.AddScoped<BingScraper>();
builder.Services.AddTransient<Func<SearchEngineType, ISearchEngineScraper>>(serviceProvider => key =>
{
    switch (key)
    {
        case SearchEngineType.Google:
            return serviceProvider.GetService<GoogleScraper>();
        case SearchEngineType.Bing:
            return serviceProvider.GetService<BingScraper>();
        default:
            return serviceProvider.GetService<GoogleScraper>();
    }
});

builder.Services.AddApplication();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SEOTrackerDbContext>();
    dbContext.Database.EnsureCreated(); // Ensures the database is created if it does not exist
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
