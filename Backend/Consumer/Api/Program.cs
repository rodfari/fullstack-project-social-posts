using Api;
using Core.Application;
using Infrastructure.Persistence.mySQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var origins =
builder
.Configuration
.GetSection("AllowedOrigins")
.Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(origins!)
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
    );
});
//Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService();
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"\n\n: connection string: {conn}\n\n");
builder.Services.AddMySqlPersistence(conn);
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
app.UseCors();
//app.UseAuthorization();

app.MapControllers();


//init database
DatabaseInitialization
.CreateAndSeed(app);

app.Run();
