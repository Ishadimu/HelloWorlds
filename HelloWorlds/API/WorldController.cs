using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HelloWorlds.Models;
using HelloWorlds.Models.Locations;

namespace HelloWorlds.API
{
    [AllowAnonymous]
    [RoutePrefix("api/world")]
    public class WorldController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/World
        public IQueryable<World> GetWorlds()
        {
            return db.Worlds;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetWorld(int id)
        {
            World world = await db.Worlds.FindAsync(id);

            if (world == null)
            {
                return NotFound();
            }

            return Ok(world);
        }

        // PUT: api/World/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorld(int id, World world)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != world.Id)
            {
                return BadRequest();
            }

            db.Entry(world).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("add")]
        [ResponseType(typeof(World))]
        public async Task<IHttpActionResult> PostWorld(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var world = new World(name);

            db.Worlds.Add(world);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorldExists(world.Id))
                {
                    return Conflict();
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = world.Id }, world);
        }

        // DELETE: api/World/5
        [ResponseType(typeof(World))]
        public async Task<IHttpActionResult> DeleteWorld(int id)
        {
            World world = await db.Worlds.FindAsync(id);
            if (world == null)
            {
                return NotFound();
            }

            db.Worlds.Remove(world);
            await db.SaveChangesAsync();

            return Ok(world);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorldExists(int id)
        {
            return db.Worlds.Count(e => e.Id == id) > 0;
        }
    }
}