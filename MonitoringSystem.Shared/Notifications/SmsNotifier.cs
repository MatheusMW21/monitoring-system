using MonitoringSystem.Domain.Entities;

namespace MonitoringSystem.Shared.Notifications
{
    public class SmsNotifier
    {
        // Exemplo simples: apenas escreve no console
        public Task SendAlertAsync(Alert alert)
        {
            Console.WriteLine($"[SMS] Alerta disparado! Tipo: {alert.AlertType}, Valor: {alert.Threshold}, Id: {alert.Id}");
            return Task.CompletedTask;
        }
    }
}