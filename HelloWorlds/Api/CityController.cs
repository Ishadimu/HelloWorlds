﻿using System.Data.Entity;
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
    [RoutePrefix("api/city")]
    public class CityController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(City[]))]
        public async Task<IHttpActionResult>  GetCities()
        {
            var cities = await db.Cities.ToArrayAsync();
            return Ok(cities);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetCity(int id)
        {
            City city = await db.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCity(int id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Id)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> PostCity(string cityName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = new City() { Name = cityName };
            db.Cities.Add(city);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CityExists(city.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        [HttpDelete]
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> DeleteCity(int id)
        {
            City city = await db.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            db.Cities.Remove(city);
            await db.SaveChangesAsync();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(int id)
        {
            return db.Cities.Count(e => e.Id == id) > 0;
        }
    }
}