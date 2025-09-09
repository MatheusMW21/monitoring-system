using System;
using MonitoringSystem.Domain.Entities;

namespace MonitoringSystem.Shared.Helpers;

public class ThresholdEvaluator
{
    public static bool IsThresholdExceeded(Metric metric)
    {
        // Example logic: threshold exceeded if metric value > 80
        return metric.Value > 80;
    }
}
