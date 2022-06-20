using auto_system.Extensions;
using LuckCode.Common;
using LuckCode.Common.Helper;
using LuckCode.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
builder.Services.AddCustomizedConfigurationServices(builder.Configuration);
builder.Services.AddScoped<UserContext>();
builder.Services.AddSqlsugarSetup(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
    {
        policy
            .WithOrigins(
               builder.Configuration["App:CorsOrigins"]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
            )
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddAutoMapper(typeof(SystemManagementProfile));
builder.Services.AddAuthentication(x =>
{
    // 仔细看这个单词 上图中错误的提示里的那个
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(o => {

    //读取配置文件
    
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTTokenOptions:SecurityKey"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWTTokenOptions:Issuer"],//发行人
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWTTokenOptions:Audience"],//订阅人
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
        RequireExpirationTime = true,
    };
    o.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userContext = context.HttpContext.RequestServices.GetService<UserContext>();
            var claims = context.Principal.Claims;
            userContext.id = long.Parse(claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value);

            Console.WriteLine($"user id ={userContext.id}");      
            userContext.name = claims.First(x => x.Type == ClaimTypes.Name).Value;
            //userContext.Email = claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
            userContext.role = claims.First(x => x.Type == ClaimTypes.Role).Value;

            return Task.CompletedTask;
        }
    };
});
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("Default");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
