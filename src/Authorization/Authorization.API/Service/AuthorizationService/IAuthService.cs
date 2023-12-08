using Authorization.API.Models.LoginModel;

namespace Authorization.API.Service.AuthorizationService
{
    public interface IAuthService
    {

        string GenerateToken(Login login);
    }
}
