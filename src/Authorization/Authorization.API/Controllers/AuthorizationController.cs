using Authorization.API.DataContext;
using Authorization.API.Models.LoginModel;
using Authorization.API.Service.AuthorizationService;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AuthorizationController:ControllerBase
    {
        private readonly IAuthService _tokenGenerator;
        private readonly BogchaDatabase _bogcha;
        private readonly PoliklinikaDatabase _poliklinika;
        public AuthorizationController(BogchaDatabase bogcha, PoliklinikaDatabase poliklinika, IAuthService tokenGenerator )
        {
            _bogcha = bogcha;
            _poliklinika = poliklinika;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(Login login)
        {
            string token = _tokenGenerator.GenerateToken(login);

            return Ok(token);
        }

        
    }
}
