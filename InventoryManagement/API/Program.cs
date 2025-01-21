using BAL.Classes;
using BAL.Common;
using BAL.Interface;
using DAL.Classes;
using DAL.DBContext;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DALDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("*") // Allow requests from your React app
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IUserBAL, UserBAL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IAuthAccess, AuthAccess>();
builder.Services.AddScoped<LoginMethods>();
builder.Services.AddScoped<ISupplierBAL, SupplierBAL>();
builder.Services.AddScoped<ISupplierDAL, SupplierDAL>();
builder.Services.AddScoped<ICategoryBAL, CategoryBAL>();
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<IInventoryDAL, InventoryDAL>();
builder.Services.AddScoped<IInventoryBAL, InventoryBAL>();
builder.Services.AddScoped<IOrderBAL, OrderBAL>();
builder.Services.AddScoped<IOrderDAl, OrderDAL>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var jwtSettings = builder.Configuration.GetSection("Jwt:SaltKey").Value;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "YourIssuer",
            ValidAudience = "YourAudience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings))
        };
    }
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthCore API V3");
    }
        );
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
