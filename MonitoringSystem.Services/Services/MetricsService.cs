using MonitoringSystem.Data;
using MonitoringSystem.Domain.Entities;
using MonitoringSystem.Shared.Notifications;
using Microsoft.EntityFrameworkCore;

namespace MonitoringSystem.Services;

public class MetricsService
{
    private readonly MonitoringDbContext _context;

    public MetricsService(MonitoringDbContext context)
    {
        _context = context;
    }

    public async Task AddMetricAsync(Metric metric)
    {
        metric.Id = Guid.NewGuid();
        metric.Timestamp = DateTime.UtcNow;

        await _context.Metrics.AddAsync(metric);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Metric>> GetMetricsAsync(string source = null)
    {
        var query = _context.Metrics.AsQueryable();

        if (!string.IsNullOrEmpty(source))
        {
            query = query.Where(m => m.Source == source);
        }

        return await query.OrderByDescending(m => m.Timestamp).ToListAsync();
    }

    public async Task<List<Metric>> GetRecentMetricsAsync(TimeSpan? interval = null)
    {
        var cutoff = DateTime.UtcNow.Subtract(interval ?? TimeSpan.FromMinutes(5));
        return await _context.Metrics
            .Where(m => m.Timestamp >= cutoff)
            .ToListAsync();
    }
}
