using Microsoft.AspNetCore.Mvc;
using SportShoeManagement.API.Interfaces;
using SportShoeManagement.API.DTOs;
using SportShoeManagement.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportShoeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportShoesController : ControllerBase
    {
        private readonly ISportShoeService _service;
        public SportShoesController(ISportShoeService service)
        {
            _service = service;
        }

        // GET: api/SportShoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportShoe>>> GetSportShoes()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/SportShoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportShoe>> GetSportShoe(int id)
        {
            var sportShoe = await _service.GetByIdAsync(id);
            if (sportShoe == null)
            {
                return NotFound();
            }
            return Ok(sportShoe);
        }

        // POST: api/SportShoes
        [HttpPost]
        public async Task<ActionResult<SportShoe>> PostSportShoe([FromBody] SportShoeCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetSportShoe), new { id = created.Id }, created);
        }

        // PUT: api/SportShoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportShoe(int id, [FromBody] SportShoeUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        // DELETE: api/SportShoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportShoe(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
} 