using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringSystem.API.DTOs;
using MonitoringSystem.Services;


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
        public async Task<IActionResult> PostMetric([FromBody] MetricDto dto)
        {
            var metric = new Domain.Entities.Metric
            {
                Id = dto.Id,
                Source = dto.Source,
                MetricType = dto.MetricType,
                Value = dto.Value,
                Timestamp = dto.Timestamp
            };


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
