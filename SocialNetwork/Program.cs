using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialNetwork.Models;
using SocialNetwork.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.Configure<SocialNetworkDatabaseSetting>(
    builder.Configuration.GetSection("SocialNetworkDatabase"));
builder.Services.AddSingleton<ISocialNetworkDatabaseSetting>(
    sp => sp.GetRequiredService<IOptions<SocialNetworkDatabaseSetting>>().Value);
builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(builder.Configuration.GetValue<string>("SocialNetworkDatabase:ConnectionString")));

builder.Services.AddScoped<IRegistrationService,RegistrationService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<INewService, NewService>();

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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
