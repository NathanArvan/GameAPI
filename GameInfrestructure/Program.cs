using GameInfrestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Game;User Id=GameAdmin;Password=myPassword;"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
