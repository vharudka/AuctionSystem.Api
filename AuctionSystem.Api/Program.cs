using AuctionSystem.Api.Infrastructure;
using AuctionSystem.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IBidService, BidService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();