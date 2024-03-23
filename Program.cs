using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Helper;
using WebApi.Infrastructure;
using WebApi.Interfaces;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    }); ;

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    }) ;
});

#region [JWT Auth]
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
) ;
builder.Services.AddTransient<GerarToken>();
#endregion

#region [DEFAULT CORS]
builder.Services.AddCors(options => 
    options.AddPolicy(name:"localHome", 
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        }) 
);
#endregion
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer
(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICursoContent, CursoService>();

var app = builder.Build();


#region [USING CORS]
    app.UseCors("localHome");
#endregion


if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();