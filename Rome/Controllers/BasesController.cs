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
                            EventActions = 
                            from e in c.EventActions
                            where e.BaseId == b.BaseId
                            select new EventActionDTO
                            {
                                EventActionId = e.EventActionId,
                                EventActionDate = e.EventActionDate,
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
                                         s.SessionId == id.SessionId &&
                                         s.SessionExpirationDate > DateTime.Now
                                  select s.SessionId).FirstOrDefault();
            if (!sessionStatus.Equals(null))
            {
                var query = from b in db.Bases
                            join r in db.ResultSets on b.BaseOptionSet.ResultSetId equals r.ResultSetId
                            join p in db.ProductSets on b.BaseOptionSet.ProductSetId equals p.ProductSetId
                            join rr in db.ResignationReasonSets on b.BaseOptionSet.ResignationReasonSetId equals rr.ResignationReasonSetId
                            join ss in db.StatusSets on b.BaseOptionSet.StatusSetId equals ss.StatusSetId
                            join e in db.EventSets on b.BaseOptionSet.EventSetId equals e.EventSetId
                            select new BaseDTO
                            {
                                BaseId = b.BaseId,
                                BaseName = b.BaseName,
                                BaseStart = b.BaseStart,
                                BaseEnd = b.BaseEnd,
                                DaysLeft = b.DaysLeft,
                                IsActive = b.IsActive,
                                Progress = b.Progress,
                                BaseOptionSet = new BaseOptionSetDTO
                                {
                                    BaseOptionSetId = b.BaseOptionSet.BaseOptionSetId,
                                    BaseOptionSetDescription = b.BaseOptionSet.BaseOptionSetDescription,
                                    ResultSet = new ResultSetDTO
                                    {
                                        ResultSetId = r.ResultSetId,
                                        ResultSetDescription = r.ResultSetDescription,
                                        Results = 
                                        from tr in db.Results
                                        join ra in db.ResultAssignments on tr.ResultId equals ra.ResultId
                                        where ra.ResultSetId == b.BaseOptionSet.ResultSetId
                                        select tr
                                    },
                                    ResignationReasonSet = new ResignationReasonSetDTO
                                    {
                                        ResignationReasonSetId = rr.ResignationReasonSetId,
                                        ResignationReasonSetDescription = rr.ResignationReasonSetDescription,
                                        ResignationReasons =
                                        from trr in db.ResignationReasons
                                        join rra in db.ResignationReasonAssignments on trr.ResignationReasonId equals rra.ResignationReasonId
                                        where rra.ResignationReasonSetId == b.BaseOptionSet.ResignationReasonSetId
                                        select trr
                                    },
                                    ProductSet = new ProductSetDTO
                                    {
                                        ProductSetId = p.ProductSetId,
                                        ProductSetDescription = p.ProductSetDescription,
                                        Products = 
                                        from tp in db.Products
                                        join pa in db.ProductAssignments on tp.ProductId equals pa.ProductId
                                        where pa.ProductSetId == b.BaseOptionSet.ProductSetId
                                        select tp
                                    },
                                    EventSet = new EventSetDTO
                                    {   
                                        EventSetId = e.EventSetId,
                                        EventSetDescription = e.EventSetDescription,
                                        Events =
                                        from te in db.Events
                                        join ea in db.EventAssignments on te.EventId equals ea.EventId
                                        where ea.EventSetId == b.BaseOptionSet.EventSetId
                                        select te   
                                    },
                                    StatusSet = new StatusSetDTO
                                    {
                                        StatusSetId = ss.StatusSetId,
                                        StatusSetDescription = ss.StatusSetDescription,
                                        Statuses =
                                        from tss in db.Statuses
                                        join ssa in db.StatusAssignments on tss.StatusId equals ssa.StatusId
                                        where ssa.StatusSetId == b.BaseOptionSet.StatusSetId
                                        select tss
                                    }
                                },
                                Clients =
                                    from ba in b.BaseAssignments
                                    join c in db.Clients on ba.ClientId equals c.ClientId
                                    join s in db.Statuses on ba.StatusId equals s.StatusId
                                    where ba.UserId == id.UserId
                                    select new ClientDTO
                                    {
                                        ClientId = c.ClientId,
                                        CompanyName = c.CompanyName,
                                        Owner = c.Owner,
                                        UserId = ba.UserId,
                                        Status = s,
                                        EventActions =
                                        from ea in c.EventActions
                                        where ea.BaseId == b.BaseId && ea.UserId == id.UserId
                                        select new EventActionDTO
                                        {
                                            EventActionId = ea.EventActionId,
                                            EventActionDate = ea.EventActionDate,
                                            UserId = ea.UserId
                                        }
                                    }
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