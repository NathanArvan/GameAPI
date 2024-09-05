using GameDomain.Abilities;
using GameDomain.Battle;
using GameDomain.Characters;
using GameDomain.Items;
using GameDomain.Maps;
using GameDomain.Tokens;
using GameInfrestructure;
using GameInfrestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHttpLogging(o => { });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<MapService>();
builder.Services.AddScoped<IMapRepsitory, MapRepository>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<AbilityService>();
builder.Services.AddScoped<IAbilityRepository, AbilityRepository>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<BattleService>();
builder.Services.AddScoped<IBattleRepository, BattleRepository>();
builder.Services.AddDbContext<GameContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GameContext")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();


