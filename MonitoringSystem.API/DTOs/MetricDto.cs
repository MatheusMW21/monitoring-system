using System;

namespace MonitoringSystem.API.DTOs;

public class MetricDto
{
    public Guid Id { get; set; }
    public string Source { get; set; }
    public string MetricType { get; set; }
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }

}
