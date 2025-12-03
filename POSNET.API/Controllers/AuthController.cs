using System.Diagnostics.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSNet.Application.DTOs;
using POSNet.Application.Features.Auth.Commands;
using POSNet.Application.Features.Auth.Queries;
using POSNet.Application.Features.Products.Queries;

namespace POSNET.API.Controllers
{
    
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("profile")]
        public async Task<profileDTO> profile([FromQuery] string email)
        {
            var user = await mediator.Send(new GetProfileQuery(email));

            return user;
        }


        [HttpPost("login")]
        public async Task<RespuestaAutenticacionDTO> login([FromBody] LoginCommand command)
        {
            var resultado = await mediator.Send(new LoginCommand(command.Email, command.Password));

            Response.Cookies.Append("refreshToken", resultado.refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse("30"))
            });

            return resultado;
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<RespuestaAutenticacionDTO>> Refresh()
        {
            var refe = Request.Cookies;
            var refresh = Request.Cookies["refreshToken"];

            var res = await mediator.Send(new RefreshTokenCommand(refresh ?? string.Empty));

            if (res == null)
            {
                return Unauthorized();
            }

            Response.Cookies.Append("refreshToken", res.refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse("30"))
            });

            return res;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var refresh = Request.Cookies["refreshToken"];

            var res = await mediator.Send(new RefreshTokenCommand(refresh ?? string.Empty));

            Response.Cookies.Delete("refreshToken");

            return NoContent();
        }

    }
}
