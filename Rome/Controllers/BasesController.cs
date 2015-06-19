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
using System.Web.UI;
using Rome.DAL;
using Rome.DTOs;
using Rome.Models;
using Rome.QueryObjects;

namespace Rome.Controllers
{
    public class BasesController : ApiController
    {
        private XSellContext db = new XSellContext();

        // GET: api/Bases
        public IQueryable<BaseDTO> GetBases()
        {
            var query = from b in db.Bases
                select new BaseDTO
                {
                    BaseId = b.BaseId,
                    BaseName = b.BaseName,
                    BaseStart = b.BaseStart,
                    BaseEnd = b.BaseEnd,
                    DaysLeft = b.DaysLeft,
                    IsActive = b.IsActive,
                    Progress = b.Progress,
                    Clients =
                        from ba in b.BaseAssignments 
                        join c in db.Clients on ba.ClientId equals c.ClientId
                        select new ClientDTO
                        {
                            ClientId = c.ClientId,
                            CompanyName = c.CompanyName,
                            Owner = c.Owner,
                            UserId = ba.UserId,
                            Events = 
                            from e in c.Events
                            where e.BaseId == b.BaseId
                            select new EventDTO
                            {
                                EventId = e.EventId,
                                EventDate = e.EventDate,
                                UserId = e.UserId
                            }
                        }
                };
            return query;
        }

        [HttpPost]
        [ActionName("getSelectedBases")]
        public IQueryable<BaseDTO> Post(UserQO id)
        {
            var sessionStatus  = (from s in db.Sessions
                                   where s.UserId == id.UserId &&
                                         s.SessionExpirationDate < DateTime.Now
                                   orderby s.SessionExpirationDate descending
                                   select s.SessionId).FirstOrDefault();
            if (!sessionStatus.Equals(null))
            {
                var query = from b in db.Bases
                            select new BaseDTO
                            {
                                BaseId = b.BaseId,
                                BaseName = b.BaseName,
                                BaseStart = b.BaseStart,
                                BaseEnd = b.BaseEnd,
                                DaysLeft = b.DaysLeft,
                                IsActive = b.IsActive,
                                Progress = b.Progress,
                                Clients =
                                    from ba in b.BaseAssignments
                                    join c in db.Clients on ba.ClientId equals c.ClientId
                                    where ba.UserId == id.UserId
                                    select new ClientDTO
                                    {
                                        ClientId = c.ClientId,
                                        CompanyName = c.CompanyName,
                                        Owner = c.Owner,
                                        UserId = ba.UserId,
                                        Events =
                                        from e in c.Events
                                        where e.BaseId == b.BaseId && e.UserId == id.UserId
                                        select new EventDTO
                                        {
                                            EventId = e.EventId,
                                            EventDate = e.EventDate,
                                            UserId = e.UserId
                                        }
                                    }
                            };
                return query;
            }
            else
            {
                return null;
            }
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