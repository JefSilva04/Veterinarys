using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinarys.API.Data;
using Veterinarys.Shared.Entities;

namespace Veterinarys.API.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController:ControllerBase
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        // Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //200 Ok
            //Select * From Owners
            return Ok(await _context.Owners.ToListAsync());    
        }

        // Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            //Select * From Owners where Id =
            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            _context.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        // Borra un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var AffectedRow = await _context.Owners.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (AffectedRow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
