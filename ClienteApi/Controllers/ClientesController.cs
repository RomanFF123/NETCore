using ClienteApi.Data;
using ClienteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ClientesController(AppDbContext db) => _db = db;

        // METODO GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll() =>
            await _db.Clientes.AsNoTracking().ToListAsync();

        // METODO GET: api/clientes/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _db.Clientes.FindAsync(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        // METODO POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Clientes.Add(dto);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        // METODO PUT: api/clientes/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Entry(dto).State = EntityState.Modified;

            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) when (!_db.Clientes.Any(c => c.Id == id))
            { return NotFound(); }

            return NoContent();
        }

        // METODO DELETE: api/clientes/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _db.Clientes.FindAsync(id);
            if (cliente is null) return NotFound();

            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
