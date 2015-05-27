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
using System.Web.UI;
using Rome.DAL;
using Rome.DTOs;
using Rome.Models;

namespace Rome.Controllers
{
    public class BasesController : ApiController
    {
        private XSellContext db = new XSellContext();

        // GET: api/Bases
        public IQueryable<BaseDTO> GetBases()
        {
            db.Configuration.ProxyCreationEnabled = false;
    var query = from b in db.Bases
        select new BaseDTO
        {
            BaseId = b.BaseId,
            BaseName = b.BaseName,
            BaseStart = b.BaseStart,
            BaseEnd = b.BaseEnd,
            DaysLeft = b.DaysLeft,
            IsActive = b.IsActive,
            Clients =
                from ba in b.BaseAssignments 
                join c in db.Clients on ba.ClientId equals c.ClientId
                select new ClientDTO
                {
                    ClientId = c.ClientId,
                    CompanyName = c.CompanyName,
                    Owner = c.Owner,
                    Events = 
                    from e in c.Events
                    where e.BaseId == b.BaseId
                    select new EventDTO
                    {
                        EventId = e.EventId,
                        EventDate = e.EventDate
                    }
                }
        };
                
                /*from b in db.Bases
                group b by b.BaseId into nb
                join ba in db.BaseAssignments on nb.FirstOrDefault().BaseId equals ba.BaseId
                join c in db.Clients on ba.ClientId equals c.ClientId
                select new BaseDTO
                {
                    BaseName = nb.FirstOrDefault().BaseName,
                    BaseStart = nb.FirstOrDefault().BaseStart,
                    BaseEnd = nb.FirstOrDefault().BaseEnd,
                    Clients = new ClientDTO
                    {
                        ClientId = c.ClientId,
                        CompanyName = c.CompanyName,
                        Owner = c.Owner
                    }
                };*/
            return query;
        }

        // GET: api/Bases/5
        [ResponseType(typeof(Base))]
        public async Task<IHttpActionResult> GetBase(int id)
        {
            Base @base = await db.Bases.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }

            return Ok(@base);
        }

        // PUT: api/Bases/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBase(int id, Base @base)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @base.BaseId)
            {
                return BadRequest();
            }

            db.Entry(@base).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseExists(id))
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

        // POST: api/Bases
        [ResponseType(typeof(Base))]
        public async Task<IHttpActionResult> PostBase(Base @base)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bases.Add(@base);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = @base.BaseId }, @base);
        }

        // DELETE: api/Bases/5
        [ResponseType(typeof(Base))]
        public async Task<IHttpActionResult> DeleteBase(int id)
        {
            Base @base = await db.Bases.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }

            db.Bases.Remove(@base);
            await db.SaveChangesAsync();

            return Ok(@base);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaseExists(int id)
        {
            return db.Bases.Count(e => e.BaseId == id) > 0;
        }
    }
}