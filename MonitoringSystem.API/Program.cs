using Microsoft.EntityFrameworkCore;
using MonitoringSystem.Data;
using MonitoringSystem.Domain.Entities;
using MonitoringSystem.Services;
using MonitoringSystem.Shared.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MonitoringDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddScoped<MetricsService>();
builder.Services.AddScoped<AlertsService>();

builder.Services.AddScoped<EmailNotifier>();
builder.Services.AddScoped<SmsNotifier>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
