using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringSystem.API.DTOs;
using MonitoringSystem.API.Services;


namespace MonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly MetricsService _metricsService;

        public MetricsController(MetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpPost]
        public async Task<IActionResult> PostMetric([FromBody] MetricDto metric)
        {
            await _metricsService.AddMetricAsync(metric);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMetrics([FromQuery] string source)
        {
            var metrics = await _metricsService.GetMetricsAsync(source);
            return Ok(metrics);
        }
    }
}
