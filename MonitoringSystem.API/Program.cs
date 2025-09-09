using Microsoft.EntityFrameworkCore;
using MonitoringSystem.Data;
using MonitoringSystem.Domain.Entities;
using MonitoringSystem.Services;
using MonitoringSystem.SignalR;
using MonitoringSystem.Shared.Notifications;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// 1. Configuração do banco de dados
// ----------------------
builder.Services.AddDbContext<MonitoringDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----------------------
// 2. Adicionar Controllers
// ----------------------
builder.Services.AddControllers();

// ----------------------
// 3. Configuração de SignalR
// ----------------------
builder.Services.AddSignalR();

// ----------------------
// 4. Adicionar Background Service (Worker)
// ----------------------
builder.Services.AddHostedService<MetricsProcessingService>();

// ----------------------
// 5. Injeção de dependências para serviços
// ----------------------
builder.Services.AddScoped<MetricsService>();
builder.Services.AddScoped<AlertsService>();

// Notificações
builder.Services.AddScoped<EmailNotifier>();
builder.Services.AddScoped<SmsNotifier>();

// ----------------------
// 6. Configurar Swagger (opcional, mas recomendado para APIs)
// ----------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------
// 7. Configuração do pipeline HTTP
// ----------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Mapear hub SignalR
app.MapHub<MetricsHub>("/hub/metrics");

app.Run();
