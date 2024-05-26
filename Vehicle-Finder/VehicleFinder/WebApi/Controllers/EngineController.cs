using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using VehicleFinder.Application.Interfaces;

namespace VehicleFinder.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngineController : ControllerBase
    {
        private readonly IEngineService _engineService;

        public EngineController(IEngineService engineService)
        {
            _engineService = engineService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Engine>>> GetEngines()
        {
            var engines = await _engineService.GetAllEnginesAsync();
            return Ok(engines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Engine>> GetEngineById(Guid id)
        {
            var engine = await _engineService.GetEngineByIdAsync(id);
            if (engine == null)
            {
                return NotFound();
            }
            return Ok(engine);
        }

        [HttpPost]
        public async Task<ActionResult<Engine>> CreateEngine(Engine engine)
        {
            var createdEngine = await _engineService.AddEngineAsync(engine);
            return CreatedAtAction(nameof(GetEngineById), new { id = engine.Id }, createdEngine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEngine(Guid id, Engine engine)
        {
            if (id != engine.Id)
            {
                return BadRequest();
            }

            var updatedEndinge = await _engineService.UpdateEngineAsync(engine);
            if (updatedEndinge == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEngine(Guid id)
        {
            var deleted = await _engineService.DeleteEngineAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
