using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using PruebaTecnica.Server.Services;

namespace PruebaTecnica.Server.Security
{
    public class BasicAuth : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuth(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService) : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No viene el header");
            }
            bool res = false;
            string User;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credenciales = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 3);
                User = credenciales[0];
                var Pass = credenciales[1];
                res = _userService.IsUser(User, Pass);

            }
            catch (Exception)
            {

                return AuthenticateResult.Fail("Algo anda mal");
            }

            if (!res)
            {
                return AuthenticateResult.Fail("Usuario o contraseña invalida");
            }


            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, User)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
