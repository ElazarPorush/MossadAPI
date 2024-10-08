using MossadAPI.Data;
using Microsoft.EntityFrameworkCore;
using MossadAPI.Manegers;
using MossadAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MossadDBContext>(options => options.UseSqlServer(connectionString).UseValidationCheckConstraints());

builder.Services.AddScoped<MissionForAgent>();
builder.Services.AddScoped<MissionForTarget>();
builder.Services.AddScoped<MissionBase>();
builder.Services.AddScoped<ViewMissions>();

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
