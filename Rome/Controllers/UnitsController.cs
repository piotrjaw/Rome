using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Rome.DAL;
using Rome.Models;

namespace Rome.Controllers
{
    public class UnitsController : ApiController
    {
        private XSellContext db = new XSellContext();

        [HttpGet]
        [ActionName("getUnits")]
        // GET: api/Units
        public IQueryable<Unit> GetUnits()
        {
            return db.Units;
        }

        [HttpGet]
        [ActionName("getUnit")]
        // GET: api/Units/5
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> GetUnit(int id)
        {
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/Units/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnit(int id, Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            db.Entry(unit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/Units
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> PostUnit(Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Units.Add(unit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = unit.UnitId }, unit);
        }

        // DELETE: api/Units/5
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> DeleteUnit(int id)
        {
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            db.Units.Remove(unit);
            await db.SaveChangesAsync();

            return Ok(unit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitExists(int id)
        {
            return db.Units.Count(e => e.UnitId == id) > 0;
        }
    }
}