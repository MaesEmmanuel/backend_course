using Business;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {

       private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public void Register(string login, string password)
        {

            _authenticationService.RegisterUser(login, password);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public string Login(string login, string password)
        {

            //   return _authenticationService.Login(login, password);
            return string.Empty;
        }

    }
}
