using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShoping.Application.Interfaces;
using OnlineShoping.Application.SD;
using OnlineShoping.Application.Service.Implementation;
using OnlineShoping.Application.Service.Interface;
using OnlineShoping.Domain.Model;
using OnlineShoping.Infrastructure.Data;
using OnlineShoping.Infrastructure.Repository;
using StackExchange.Redis;
using System.Text;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
//builder.Services.Configure<CurrencySettings>(builder.Configuration.GetSection("CurrencyExchange"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<OnlineShopingDbContext>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<OnlineShopingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


//builder.Services.Configure<CurrencyExchangeConfig>(builder.Configuration.GetSection("CurrencyExchange"));
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = Configuration.GetConnectionString("RedisConnection");
//    options.InstanceName = "CurrencyExchange";


//    options.Configuration = $"{Configuration["CurrencyExchange:RedisHost"]}:{Configuration["CurrencyExchange:RedisPort"]}";
//});

//builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("RedisURL"));
//builder.Services.AddHttpClient();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = $"{builder.Configuration.GetValue<string>("RedisCache:Host")}:{builder.Configuration.GetValue<int>("RedisCache:Port")}";
//});






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICashService, CashService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
