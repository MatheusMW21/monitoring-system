using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringSystem.API.Services;
using MonitoringSystem.Domain.Entities;

namespace MonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly AlertsService _alertsService;

        public AlertsController(AlertsService alertsService)
        {
            _alertsService = alertsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlert([FromBody] Metric metric)
        {
            await _alertsService.CreateAlertAsync(metric);
            return CreatedAtAction(nameof(GetAlerts), new { metric.Id }, metric);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlerts()
        {
            var alerts = await _alertsService.GetAlertsAsync();
            return Ok(alerts);
        }

        [HttpPost("resolve/{id}")]
        public async Task<IActionResult> ResolveAlert(Guid id)
        {
            await _alertsService.ResolveAlertAsync(id);
            return Ok();
        }
    }
}
