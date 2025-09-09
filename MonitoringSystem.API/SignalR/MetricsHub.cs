using System;
using Microsoft.AspNetCore.SignalR;
using MonitoringSystem.Domain.Entities;

namespace MonitoringSystem.API.SignalR;

public class MetricsHub : Hub
{
    public async Task SendMetric(Metric metric)
    {
        await Clients.All.SendAsync("ReceiveMetric", metric);
    }
}
