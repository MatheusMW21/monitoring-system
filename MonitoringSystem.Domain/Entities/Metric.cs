using System;

namespace MonitoringSystem.Domain.Entities;

public class Metric
{
    public Guid Id { get; set; }
    public string Source { get; set; }
    public string MetricType { get; set; }
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
}
