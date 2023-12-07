using Bogcha.Application;
using Bogcha.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddAplication();

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AuthDemo",
        Description = "Auth Demo Description"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Bearer Authentication",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string> ()
        }

    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(opttins =>
   {
       opttins.TokenValidationParameters = new TokenValidationParameters
       {
           // kimga chiqarilgan
           ValidateIssuer = true,
           // kim tomonidan berilgan
           ValidateAudience = true,
           // vaqti
           ValidateLifetime = true,
           // secret keyi
           ValidateIssuerSigningKey = true,
           ValidAudience = builder.Configuration["JWT:ValidAudience"],
           ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
           ClockSkew = TimeSpan.Zero
       };
   });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/V1/swagger.json", "Auth Demo API");
});


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
