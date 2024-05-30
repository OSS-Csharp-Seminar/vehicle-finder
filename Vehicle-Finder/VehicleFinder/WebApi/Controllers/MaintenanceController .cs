using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using VehicleFinder.Application.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetAll()
        {
            var maintenances = await _maintenanceService.GetAllMaintenancesAsync();
            return Ok(maintenances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maintenance>> GetById(Guid id)
        {
            var maintenance = await _maintenanceService.GetMaintenanceByIdAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return Ok(maintenance);
        }

        [HttpPost]
        public async Task<ActionResult<Maintenance>> Create(Maintenance maintenance)
        {
            var createdMaintenance = await _maintenanceService.AddMaintenanceAsync(maintenance);
            return CreatedAtAction(nameof(GetById), new { id = createdMaintenance.Id }, createdMaintenance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Maintenance maintenance)
        {
            var updatedMaintenance = await _maintenanceService.UpdateMaintenanceAsync(id, maintenance);
            if (updatedMaintenance == null)
            {
                return NotFound();
            }

            return Ok(updatedMaintenance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _maintenanceService.DeleteMaintenanceAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
