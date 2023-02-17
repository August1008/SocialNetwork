using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialNetwork.Models;
using SocialNetwork.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SocialNetworkDatabaseSetting>(
    builder.Configuration.GetSection("SocialNetworkDatabase"));
builder.Services.AddSingleton<ISocialNetworkDatabaseSetting>(
    sp => sp.GetRequiredService<IOptions<SocialNetworkDatabaseSetting>>().Value);
builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(builder.Configuration.GetValue<string>("SocialNetworkDatabase:ConnectionString")));

builder.Services.AddScoped<IRegistrationService,RegistrationService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
