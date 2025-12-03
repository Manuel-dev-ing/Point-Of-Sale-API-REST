using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using POSNet.Application.DependencyInjection;
using POSNet.Infrastructure.DependencyInjection;
using POSNet.Infrastructure.Identity;
using POSNET.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentityDatabaseFirst();
builder.Services.AddApplication();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.MapInboundClaims = false;

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {

            var path = context.HttpContext.Request.Path;

            if (path.StartsWithSegments("/api/auth/refresh"))
            {
                // No exigir token aquí
                context.NoResult();
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }


    };

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["llavejwt"])
        ),
        ClockSkew = TimeSpan.Zero
    };

});

builder.Services.AddAuthorization();
builder.Services.AddProblemDetails();

var origenes_permitidos = builder.Configuration.GetSection("originesPermitidos").Get<string[]>();

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(opciones =>
    {
        opciones.WithOrigins(origenes_permitidos)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();

    });

});


var app = builder.Build();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
app.UseCors();
app.UseExceptionHandler(_ => { });
app.UseMiddleware<POSNET.API.Middleware.ExceptionMiddleware>();
//app.UseMiddleware<ValidatedTokenMiddleware>();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
