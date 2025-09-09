using System;
using Microsoft.EntityFrameworkCore;
using MonitoringSystem.Data;
using MonitoringSystem.Domain.Entities;
using MonitoringSystem.Domain.Enums;
using MonitoringSystem.Shared.Notifications;


namespace MonitoringSystem.Services;

public class AlertsService
{
    private readonly MonitoringDbContext _context;
    private readonly EmailNotifier _emailNotifier;
    private readonly SmsNotifier _smsNotifier;

    public AlertsService(MonitoringDbContext context, EmailNotifier emailNotifier, SmsNotifier smsNotifier)
    {
        _context = context;
        _emailNotifier = emailNotifier;
        _smsNotifier = smsNotifier;
    }

    public async Task CreateAlertAsync(Metric metric)
    {
        var alert = new Alert
        {
            Id = Guid.NewGuid(),
            MetricId = metric.Id,
            AlertType = metric.MetricType,
            Threshold = metric.Value,
            Timestamp = DateTime.UtcNow,
            Status = AlertStatus.Pending
        };

        await _context.Alerts.AddAsync(alert);
        await _context.SaveChangesAsync();

        await _emailNotifier.SendAlertAsync(alert);
        await _smsNotifier.SendAlertAsync(alert);
    }

    public async Task<List<Alert>> GetAlertsAsync()
    {
        return await _context.Alerts.ToListAsync();
    }

    public async Task<List<Alert>> GetRecentAlertsAsync(int limit = 50)
    {
        return await _context.Alerts
            .OrderByDescending(a => a.Timestamp)
            .Take(limit)
            .ToListAsync();
    }

    public async Task ResolveAlertAsync(Guid alertId)
    {
        var alert = await _context.Alerts.FindAsync(alertId);
        if (alert != null)
        {
            alert.Status = AlertStatus.Resolved;
            await _context.SaveChangesAsync();
        }
    }
}
