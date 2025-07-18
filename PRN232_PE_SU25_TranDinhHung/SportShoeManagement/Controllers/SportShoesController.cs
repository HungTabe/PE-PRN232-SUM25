using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportShoeManagement.DTOs;
using SportShoeManagement.Interfaces;
using SportShoeManagement.Models;

namespace SportShoeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportShoesController : ControllerBase
    {
        private readonly ISportShoeService _service;
        public SportShoesController (ISportShoeService service)
        {
            _service = service;
        }

        // (GetList) GET: api/SportShoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportShoe>>> GetListSportShoes()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // (GetbyID) Get: api/SportShoes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SportShoe>> GetSportShoes (int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Add
        [HttpPost]
        public async Task<ActionResult<SportShoe>> PostSportShoe([FromBody]SportShoeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetSportShoes), new { id = created.Id }, created);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportShoe(int id, [FromBody] SportShoeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }


        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportShoe(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
