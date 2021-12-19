using CarGarageApi.Models;
using CarGarageApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<CarGarageDatabaseSettings>(
builder.Configuration.GetSection("CarGarageDatabase"));

builder.Services.AddSingleton<CarGarageService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        //.WithOrigins("http://localhost:3000/")
        .AllowAnyOrigin()
        );
});

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
