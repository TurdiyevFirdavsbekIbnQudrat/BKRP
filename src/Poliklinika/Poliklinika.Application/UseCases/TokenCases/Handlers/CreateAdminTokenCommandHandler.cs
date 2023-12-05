using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poliklinika.Application.Abstraction;
using Poliklinika.Application.UseCases.TokenCases.Commands;
using Poliklinika.Domain.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poliklinika.Application.UseCases.TokenCases
{
    public class CreateAdminTokenCommandHandler : IRequestHandler<CreateAdminTokenCommand, string>
    {
        private readonly IConfiguration _configuration;
        private readonly IPoliklinikaDbContext poliklinikaDbContext;

        public CreateAdminTokenCommandHandler(IConfiguration configuration, IPoliklinikaDbContext _poliklinikaDbContext)
        {
            _configuration = configuration;
            poliklinikaDbContext = _poliklinikaDbContext;
        }
        public async Task<string> Handle(CreateAdminTokenCommand request ,CancellationToken cancellationToken)
        {

            var AdminPU = await poliklinikaDbContext
                .Adminlar
                .FirstOrDefaultAsync(x => x.Parol == request.Parol && x.Username == request.UserName);
            if(AdminPU != null)
            {
                var token = await GenerateToken(request.UserName);
                return token;
            }
            return "Ma'lumotlar topilmadi";

        }
        private async ValueTask<string> GenerateToken(string userName)
        {
            // bu malumotlar
            var claims = new Claim[]
            {
                // name 
                new Claim(JwtRegisteredClaimNames.Name, userName),
                // identificatori
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // vaqti
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),

            };

            // qandedur algoritm boyicha shifrlanadi
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);

        }

    }
}

