using Authorization.API.DataContext;
using Authorization.API.Models.LoginModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.API.Service.AuthorizationService
{
    public class AuthService:IAuthService
    {
        private readonly BogchaDatabase _bogchaDatabase;

        private readonly PoliklinikaDatabase _poliklinikacDatabase;
        public AuthService(BogchaDatabase bogchaDatabase, PoliklinikaDatabase poliklinikacDatabase)
        {
            _bogchaDatabase = bogchaDatabase;
            _poliklinikacDatabase = poliklinikacDatabase;
        }
        public string GenerateToken(Login login)
        {
            List<Login> loginlist = _poliklinikacDatabase.Admins.Select(admin => new Login
            {
                UserName = admin.Username,
                Password = admin.Parol,
                Role = admin.role
            }).ToList();
            loginlist.AddRange(_poliklinikacDatabase.Admins.Select(Admin=>new Login() {
            Password=Admin.Parol,
            Role=Admin.role,
            UserName=Admin.Username,
            }));
            loginlist.AddRange(_bogchaDatabase.Teachers.Select(Admin => new Login()
            {
                Password = Admin.Password, 
                Role=Admin.role,
                UserName=Admin.UserName
            }));
            var res = loginlist.FirstOrDefault(x => x.UserName == login.UserName && x.Password == Hash512.ComputeSHA512HashFromString(login.Password));
          
            if (res == null)
                throw new UserNotFound();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mana-shu-security-key"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, res.UserName),
                new Claim(ClaimTypes.Role, res.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
