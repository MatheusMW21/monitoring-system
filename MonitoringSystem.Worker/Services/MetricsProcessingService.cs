using System;
using MonitoringSystem.API.Services;

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
                if (ThresholdEvaluation.IsThresholdExceeded(metric))
                {
                    await _alertsService.CreateAlertAsync(metric);
                }
            }
            await Task.Delay(5000, stoppingToken);
        } 
    }
}
