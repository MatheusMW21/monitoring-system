using System;
using MonitoringSystem.Domain.Enums;

namespace MonitoringSystem.Domain.Entities;

public class Alert
{
    public Guid Id { get; set; }
    public Guid MetricId { get; set; }
    public string AlertType { get; set; }
    public double Threshold { get; set; }
    public DateTime Timestamp { get; set; }
    public AlertStatus Status { get; set; }
}
