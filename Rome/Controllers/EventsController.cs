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
                            join st in db.Statuses on e.StatusId equals st.StatusId
                            where e.UserId == id.UserId
                            select new EventActionDTO
                            {
                                EventActionId = e.EventActionId,
                                EventActionDate = e.EventActionDate,
                                EventId = e.EventId,
                                ClientId = e.ClientId,
                                BaseId = e.BaseId,
                                UserId = e.UserId,
                                ResultId = e.ResultId,
                                StatusId = e.StatusId,
                                SetEventId = e.SetEventId,
                                SetEventActionDate = e.SetEventActionDate,
                                Comment = e.Comment,
                                Status = st,
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

        // POST: api/postEvent/{event}
        [HttpPost]
        [ActionName("postEvent")]
        public async Task<IHttpActionResult> Post(EventActionQO eaqo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @ea = new EventAction
            {
                EventActionDate = eaqo.EventActionDate,
                EventId = eaqo.EventId,
                ClientId = eaqo.ClientId,
                BaseId = eaqo.BaseId,
                UserId = eaqo.UserId,
                ResultId = eaqo.ResultId,
                StatusId = eaqo.StatusId,
                SetEventId = eaqo.SetEventId,
                SetEventActionDate = eaqo.SetEventActionDate
            };

            db.EventActions.Add(ea);
            await db.SaveChangesAsync();

            var result = from e in db.EventActions
                        join c in db.Clients on e.ClientId equals c.ClientId
                        join t in db.Events on e.EventId equals t.EventId
                        join st in db.Statuses on e.StatusId equals st.StatusId
                        where e.EventActionId == @ea.EventActionId
                        select new EventActionDTO
                        {
                            EventActionId = e.EventActionId,
                            EventActionDate = e.EventActionDate,
                            EventId = e.EventId,
                            ClientId = e.ClientId,
                            BaseId = e.BaseId,
                            UserId = e.UserId,
                            ResultId = e.ResultId,
                            StatusId = e.StatusId,
                            SetEventId = e.SetEventId,
                            SetEventActionDate = e.SetEventActionDate,
                            Comment = e.Comment,
                            Status = st,
                            Client = c,
                            Event = t
                        };

            return CreatedAtRoute("DefaultApi", new { id = @ea.EventActionId }, result);
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