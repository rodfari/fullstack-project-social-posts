using Core.Application;
using Infrastructure.Persistence.pgSQL;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService();
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(conn);
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

//app.UseAuthorization();

app.MapControllers();
DbInitializer.SeedData(app);
app.Run();
