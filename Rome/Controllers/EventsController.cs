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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rome.DAL;
using Rome.DTOs;
using Rome.Models;
using Rome.QueryObjects;

namespace Rome.Controllers
{
    public class EventsController : ApiController
    {
        private XSellContext db = new XSellContext();

        [HttpPost]
        [ActionName("getSelectedEvents")]
        public IQueryable<EventActionDTO> Post(UserQO id)
        {
            var sessionStatus  = (from s in db.Sessions
                        where s.UserId == id.UserId &&
                                s.SessionId == id.SessionId &&
                                s.SessionExpirationDate > DateTime.Now
                        select s.SessionId).FirstOrDefault();
            if (!sessionStatus.Equals(null))
            {
                var query = from e in db.EventActions
                            join c in db.Clients on e.ClientId equals c.ClientId
                            join t in db.Events on e.EventId equals t.EventId
                            where e.UserId == id.UserId
                            select new EventActionDTO
                            {
                                EventActionId = e.EventActionId,
                                EventActionDate = e.EventActionDate,
                                UserId = e.UserId,
                                ClientId = e.ClientId,
                                BaseId = e.BaseId,
                                Client = c,
                                Event = t
                            };
                var session = db.Sessions.Where(s => s.SessionId == id.SessionId).FirstOrDefault();
                session.SessionExpirationDate = DateTime.Now.AddHours(1);
                db.SaveChanges();
                return query;
            }
            else
            {
                return null;
            }
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(int id, EventAction @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventActionId)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [ResponseType(typeof(EventAction))]
        public async Task<IHttpActionResult> PostEvent(EventAction @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventActions.Add(@event);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = @event.EventActionId }, @event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(EventAction))]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            EventAction @event = await db.EventActions.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.EventActions.Remove(@event);
            await db.SaveChangesAsync();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.EventActions.Count(e => e.EventActionId == id) > 0;
        }
    }
}