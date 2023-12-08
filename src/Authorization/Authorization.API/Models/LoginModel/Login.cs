using Authorization.API.Enums;
using System.Text.Json.Serialization;

namespace Authorization.API.Models.LoginModel
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
    }
}
