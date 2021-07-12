using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValheimBlueprintStore.Models;

namespace ValheimBlueprintStore.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BlueprintsController : ControllerBase
    {
        private readonly ValheimBlueprintStoreContext _context;

        public BlueprintsController(ValheimBlueprintStoreContext context)
        {
            _context = context;
        }

        // GET: api/Blueprints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blueprint>>> GetBlueprints()
        {
            return await _context.Blueprints.ToListAsync();
        }

        // GET: api/Blueprints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blueprint>> GetBlueprint(string id)
        {
            var blueprint = await _context.Blueprints.FindAsync(id);

            if (blueprint == null)
            {
                return NotFound();
            }

            return blueprint;
        }

        // PUT: api/Blueprints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlueprint(string id, Blueprint blueprint)
        {
            if (id != blueprint.Id)
            {
                return BadRequest();
            }

            _context.Entry(blueprint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlueprintExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Blueprints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blueprint>> PostBlueprint(Blueprint blueprint)
        {
            _context.Blueprints.Add(blueprint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BlueprintExists(blueprint.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBlueprint", new { id = blueprint.Id }, blueprint);
        }

        // DELETE: api/Blueprints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlueprint(string id)
        {
            var blueprint = await _context.Blueprints.FindAsync(id);
            if (blueprint == null)
            {
                return NotFound();
            }

            _context.Blueprints.Remove(blueprint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlueprintExists(string id)
        {
            return _context.Blueprints.Any(e => e.Id == id);
        }
    }
}
