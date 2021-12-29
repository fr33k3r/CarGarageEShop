using CarGarageApi.Models;
using CarGarageApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarGarageApi.Helpers;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)    
    .AddEnvironmentVariables();

builder.Services.Configure<CarGarageDatabaseSettings>(
builder.Configuration.GetSection("CarGarageDatabase"));

builder.Services.Configure<JwtSettings>(
builder.Configuration.GetSection("Auth"));

builder.Services.AddSingleton<ICarGarageService, CarGarageService>();
builder.Services.AddSingleton<JwtToken>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .WithOrigins("http://localhost:3000")
        //.AllowAnyOrigin()
        .AllowAnyHeader()
        );
});

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

//Configure the JWT Authentication Service
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", jwtOptions =>
 {
     jwtOptions.TokenValidationParameters = new TokenValidationParameters()
     {
         //The SigningKey is defined in the TokenController Class
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Auth:SecretKey"))),
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidIssuer = "https://localhost:7072",
         ValidAudience = "https://localhost:7072",
         ValidateLifetime = true
     };
 });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
