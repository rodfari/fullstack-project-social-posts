using Core.Application;
using Infrastructure.Persistence.mySQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var FrontEndCorsName = "FrontEndCors";
var allowedCors = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontEndCorsName,
        policy => policy.WithOrigins(allowedCors)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
    );
});
//Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService();
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("\n\n\n\n\n Connection string: " + conn + "\n\n\n\n\n");
builder.Services.AddPostgresPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors(FrontEndCorsName);
//app.UseAuthorization();

app.MapControllers();
if (app.Environment.IsProduction())
{

    for (int i = 0; i < 3; i++)
    {
        try
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            db.Database.Migrate();
            if (!db.User.Any())
            {
                var seed = GetUsers.SeedUsers();
                db.User.AddRange(seed);
                db.SaveChanges();
                Console.WriteLine("\n\nDatabase is ready...");
                Console.WriteLine("Seed data added...\n\n");
                break;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("\n\nIt seems database isn't ready...");
            Console.WriteLine("waitint for the databade to start...\n\n");
            Thread.Sleep(5000);
            Console.WriteLine("Retrying...\n\n");
        }
    }
}

app.Run();
