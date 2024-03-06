using Microsoft.AspNetCore.Identity;

namespace JwtAuthentication.Areas.Identity.Data.User
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResults

    {
        public IdentityUser User { get; set; }
        public IList<string> Role { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public long TokenExpireDate { get; set; }
        


    }

    public class AuthenticationResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public long TokenExpireDate { get; set; }

        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        

    }


}
