using Bogcha.Application.Abstraction;
using Bogcha.Application.UseCases.TokenCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bogcha.Application.UseCases.TokenCases.Handlers
{
    public class CreateBogchaAdminTokenCommandHandler : IRequestHandler<CreateBogchaAdminTokenCommand, string>
    {
        private readonly IConfiguration _configuration;
        private readonly IBogchaDbContext bogchaDbContext;

        public CreateBogchaAdminTokenCommandHandler(IConfiguration configuration, IBogchaDbContext _bogchaDbContext)
        {
            _configuration = configuration;
            bogchaDbContext = _bogchaDbContext;
        }
        public async Task<string> Handle(CreateBogchaAdminTokenCommand request, CancellationToken cancellationToken)
        {

            var AdminPU = await bogchaDbContext.Adminlar.FirstOrDefaultAsync(x => x.Password == request.Parol && x.UserName == request.UserName);
            if (AdminPU != null)
            {
                var token = await GenerateToken(request.UserName, request.Role);
                return token;
            }
            return "Ma'lumotlar topilmadi";

        }
        private async ValueTask<string> GenerateToken(string userName, string role)
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

                new Claim(ClaimTypes.Role, role)
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
