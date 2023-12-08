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
var connectionsStrings = $"Data Source=umumiydb;Initial Catalog=BogchaDb;User ID=sa;Password=pa@2or$%%dd;Encrypt=False;Connection Timeout=120";

builder.Services.AddDbContext<BogchaDatabase>(options => options.UseSqlServer(connectionsString));
builder.Services.AddDbContext<PoliklinikaDatabase>(options => options.UseSqlServer(connectionsStrings));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
