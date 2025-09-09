using MonitoringSystem.Services;
using MonitoringSystem.Domain.Entities;
using MonitoringSystem.Shared.Helpers;

namespace MonitoringSystem.Worker.Services;

public class MetricsProcessingService : BackgroundService
{
    private readonly MetricsService _metricsService;
    private readonly AlertsService _alertsService;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var metrics = await _metricsService.GetMetricsAsync();
            foreach (var metric in metrics)
            {
                if (ThresholdEvaluator.IsThresholdExceeded(metric))
                {
                    await _alertsService.CreateAlertAsync(metric);
                }
            }
            await Task.Delay(5000, stoppingToken);
        }
    }
}
