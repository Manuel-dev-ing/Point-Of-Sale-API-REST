using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace POSNET.API.Middleware
{
    public class ValidatedTokenMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public ValidatedTokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }


        public async Task Invoke(HttpContext context)
        {

            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);

                var principal = ValidateToken(token);

                if (principal == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { error = "Invalid or expired token" });
                    return;
                }

                context.User = principal;
            }

            await next(context);

        }

        private ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                var llave = configuration["llavejwt"];
                var key = Encoding.UTF8.GetBytes(llave);
                var tokenHandler = new JwtSecurityTokenHandler();

                var validationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = false,    // FIX IMPORTANTE
                    ValidateAudience = false,  // FIX CONSISTENTE


                    ClockSkew = TimeSpan.Zero
                };

                return tokenHandler.ValidateToken(token, validationParams, out _);
            }
            catch (Exception ex)
            {

                Console.WriteLine("TOKEN ERROR => " + ex.Message);
                return null;
            }


        }



    }
}
