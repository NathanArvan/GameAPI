using GameInfrestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GameContext"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
