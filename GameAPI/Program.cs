using GameInfrestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<GameContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GameContext")));
builder.Services.AddDbContext<GameContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Game;User Id=GameAdmin;Password=myPassword;"));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/", () => "Hello World!");

app.Run();
