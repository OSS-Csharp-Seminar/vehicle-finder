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
    public class BodyController : ControllerBase
    {
        private readonly IBodyService _bodyService;

        public BodyController(IBodyService bodyService)
        {
            _bodyService = bodyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Body>>> GetAll()
        {
            var bodies = await _bodyService.GetAllBodiesAsync();
            return Ok(bodies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Body>> GetById(Guid id)
        {
            var body = await _bodyService.GetBodyByIdAsync(id);
            if (body == null)
            {
                return NotFound();
            }

            return Ok(body);
        }

        [HttpPost]
        public async Task<ActionResult<Body>> Create(Body body)
        {
            var createdBody = await _bodyService.AddBodyAsync(body);
            return CreatedAtAction(nameof(GetById), new { id = createdBody.Id }, createdBody);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Body body)
        {
            var updatedBody = await _bodyService.UpdateBodyAsync(id, body);
            if (updatedBody == null)
            {
                return NotFound();
            }

            return Ok(updatedBody);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _bodyService.DeleteBodyAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
