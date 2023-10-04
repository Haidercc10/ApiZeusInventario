using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlasticaribeAPI.Service;
using System.Text;
using ZeusInventarioWebAPI.Data;
using ZeusInventarioWebAPI.Models;
using ZeusInventarioWebAPI.Service;
using ConfigurationManager = ZeusInventarioWebAPI.Service.ConfigurationManager;

//Variable para habilitar error de CORS
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo { Version = "V1", Title = "Inventario Zeus WebAPI", Description = "" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } },
            new List<string>()
        }
    });
});
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddDbContext<InventarioDataContext>(options =>
{ options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: SqlOptions => { SqlOptions.EnableRetryOnFailure(); }); });
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
#pragma warning disable CS8604 // Posible argumento de referencia nulo
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = ConfigurationManager.AppSetting["JWT:ValidIssuer"],
        ValidAudience = ConfigurationManager.AppSetting["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]))
    };
#pragma warning restore CS8604 // Posible argumento de referencia nulo
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://192.168.0.193:4600", "http://192.168.0.85:4700", "http://192.168.0.193:5000", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/V1/swagger.json", "Inventario Zeus WebAPI"); });
}
app.UseAuthentication();
app.UseCors(myAllowSpecificOrigins);
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
