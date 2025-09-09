using MonitoringSystem.Domain.Entities;  // precisa estar exatamente assim
using MonitoringSystem.Domain.Enums;     // se usar enums do Domain


namespace MonitoringSystem.Shared.Notifications;

public class EmailNotifier
{
    public Task SendAlertAsync(Alert alert)
    {
        Console.WriteLine($"[EMAIL] Alerta disparado! Tipo: {alert.AlertType}, Valor: {alert.Threshold}, Id: {alert.Id}");
        return Task.CompletedTask;
    }
}
