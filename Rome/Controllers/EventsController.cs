﻿using System;
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
        public IQueryable<EventDTO> Post(UserQO id)
        {
            var sessionStatus  = (from s in db.Sessions
                        where s.UserId == id.UserId &&
                                s.SessionId == id.SessionId &&
                                s.SessionExpirationDate > DateTime.Now
                        select s.SessionId).FirstOrDefault();
            if (!sessionStatus.Equals(null))
            {
                var query = from e in db.Events
                            join c in db.Clients on e.ClientId equals c.ClientId
                            join t in db.EventTypes on e.EventTypeId equals t.EventTypeId
                            where e.UserId == id.UserId
                            select new EventDTO
                            {
                                EventId = e.EventId,
                                EventDate = e.EventDate,
                                UserId = e.UserId,
                                ClientId = e.ClientId,
                                BaseId = e.BaseId,
                                Client = c,
                                EventType = t
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
        public async Task<IHttpActionResult> PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventId)
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
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
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
            return db.Events.Count(e => e.EventId == id) > 0;
        }
    }
}