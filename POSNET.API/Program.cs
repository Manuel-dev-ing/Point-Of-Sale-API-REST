using POSNet.Application.DependencyInjection;
using POSNet.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var origenes_permitidos = builder.Configuration.GetSection("originesPermitidos").Get<string[]>();

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(opciones =>
    {
        opciones.WithOrigins(origenes_permitidos).AllowAnyMethod().AllowAnyHeader();

    });

});

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
app.UseCors();

app.UseMiddleware<POSNET.API.Middleware.ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();


app.Run();
