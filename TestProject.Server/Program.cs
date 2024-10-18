using Microsoft.EntityFrameworkCore;
using TestProject.Server.Data;
using TestProject.Server.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddDbContext<JobContext>(options =>
   options.UseInMemoryDatabase("TestProjectDb"));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policyBuilder => policyBuilder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
SeedData(app);

app.MapFallbackToFile("/index.html");

app.Run();


void SeedData(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<JobContext>();

        context.Database.EnsureCreated();

        // Seed data only if the database is empty
        if (!context.Jobs.Any())
        {
            // Create some sample jobs
            var jobs = new List<Job>
            {
                new Job
                {
                    Description = "Fix the leaking faucet in my kitchen.",
                    Requirements = "Experience with plumbing",
                    PosterName = "John Doe",
                    ContactInfo = "johndoe@example.com",
                    CreatedAt = DateTime.UtcNow,
                    ExpirationDate = DateTime.UtcNow.AddDays(3)
                },
                new Job
                {
                    Description = "Mow the lawn and trim the hedges.",
                    Requirements = "Own lawn equipment",
                    PosterName = "Jane Smith",
                    ContactInfo = "janesmith@example.com",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    ExpirationDate = DateTime.UtcNow.AddDays(2)
                },
                new Job
                {
                    Description = "Paint the living room and hallway.",
                    Requirements = "Experience with painting",
                    PosterName = "Tom White",
                    ContactInfo = "tomwhite@example.com",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    ExpirationDate = DateTime.UtcNow.AddDays(5)
                }
            };

            context.Jobs.AddRange(jobs);
            context.SaveChanges();

            // Add bids to some of the jobs
            var bids = new List<Bid>
            {
                new Bid { JobId = jobs[0].JobId, Amount = 50, CreatedAt = DateTime.UtcNow },
                new Bid { JobId = jobs[0].JobId, Amount = 45, CreatedAt = DateTime.UtcNow.AddHours(-1) },
                new Bid { JobId = jobs[1].JobId, Amount = 60, CreatedAt = DateTime.UtcNow.AddHours(-2) }
            };

            context.Bids.AddRange(bids);
            context.SaveChanges();
        }
    }

}