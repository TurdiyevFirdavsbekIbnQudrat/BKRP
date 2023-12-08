using Authorization.API.DataContext;
using Authorization.API.Service.AuthorizationService;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();

var connectionsString = $"Data Source=umumiydb;Initial Catalog=PoliklinikaDb;User ID=sa;Password=pa@2or$%%dd;Encrypt=False;Connection Timeout=120";
//string host = Environment.GetEnvironmentVariable("DB_HOST");
//string db = Environment.GetEnvironmentVariable("DB_NAME");
//string pass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var connectionsStrings = $"Data Source={host};Initial Catalog={db};User ID=sa;Password={pass};Encrypt=False;Connection Timeout=120";
var connectionsStrings = $"Data Source=umumiydb;Initial Catalog=BogchaDb;User ID=sa;Password=pa@2or$%%dd;Encrypt=False;Connection Timeout=120";

builder.Services.AddDbContext<BogchaDatabase>(options => options.UseSqlServer(connectionsStrings, providerOptions => providerOptions.EnableRetryOnFailure()));
builder.Services.AddDbContext<PoliklinikaDatabase>(options => options.UseSqlServer(connectionsStrings, providerOptions => providerOptions.EnableRetryOnFailure()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
