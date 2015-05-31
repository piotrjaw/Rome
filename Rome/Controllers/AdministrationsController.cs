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
using Rome.DTOs;
using Rome.Models;

namespace Rome.Controllers
{
    public class AdministrationsController : ApiController
    {
        private XSellContext db = new XSellContext();

        // GET: api/Administrations
        public IQueryable<AdministrationDTO> GetAdministrations()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var query = from u in db.Units
                        where u.UnitTypeId = 1
                        select new AdministrationDTO
                        {
                            AdministrationId = u.UnitId,
                            Admins = from ra in u.RoleAssignments
                                     join us in db.Users on
                                     new
                                     {
                                         JoinProperty1 = ra.UserId,
                                         JoinProperty2 = ra.RoleId,
                                         JoinProperty3 = ra.UnitId
                                     }
                                     equals
                                     new
                                     {
                                         JoinProperty1 = us.UserId,
                                         JoinProperty2 = 1,
                                         JoinProperty3 = u.UnitId
                                     }
                                     select new UserDTO
                                     {
                                         UserId = us.UserId,
                                         UserFirstName = us.UserFirstName,
                                         UserSurname = us.UserSurname,
                                         UserName = us.UserName,
                                         Email = us.Email
                                     },
                            Companies = from s in u.SlaveUnits
                                        select new CompanyDTO
                                        {
                                            CompanyId = s.UnitId,
                                            CompanyName = s.UnitName,
                                            CompanyManagers = from ra in s.RoleAssignments
                                                              join us in db.Users on
                                                              new
                                                              {
                                                                  JoinProperty1 = ra.UserId,
                                                                  JoinProperty2 = ra.RoleId,
                                                                  JoinProperty3 = ra.UnitId
                                                              }
                                                              equals
                                                              new
                                                              {
                                                                  JoinProperty1 = us.UserId,
                                                                  JoinProperty2 = 1,
                                                                  JoinProperty3 = s.UnitId
                                                              }
                                                              select new UserDTO
                                                              {
                                                                  UserId = us.UserId,
                                                                  UserFirstName = us.UserFirstName,
                                                                  UserSurname = us.UserSurname,
                                                                  UserName = us.UserName,
                                                                  Email = us.Email
                                                              },

                                        }
                        }

            var query = from u in db.Units
                        where u.UnitTypeId = 1
                        select new AdministrationDTO
                        {
                            AdministrationId = u.UnitId,
                            Admins = from ra in u.RoleAssignments
                                     join us in db.Users on 
                                     new
                                     {
                                         JoinProperty1 = ra.UserId,
                                         JoinProperty2 = ra.RoleId,
                                         JoinProperty3 = ra.UnitId
                                     }
                                     equals
                                     new {
                                         JoinProperty1 = us.UserId,
                                         JoinProperty2 = 1,
                                         JoinProperty3 = u.UnitId
                                     }
                                     select new UserDTO
                                     {
                                         UserId = u.UserId,
                                         UserFirstName = u.UserFirstName,
                                         UserSurname = u.UserSurname,
                                         UserName = u.UserName,
                                         Email = u.Email
                                     },
                            Companies = from c in a.Companies
                                        select new CompanyDTO
                                        {
                                            CompanyId = c.CompanyId,
                                            CompanyName = c.CompanyName,
                                            CompanyManagers = from ra in a.RoleAssignments
                                                              join u in db.Users on
                                                              new
                                                              {
                                                                  JoinProperty1 = ra.UserId,
                                                                  JoinProperty2 = ra.RoleId,
                                                                  JoinProperty3 = ra.UnitId
                                                              }
                                                              equals
                                                              new
                                                              {
                                                                  JoinProperty1 = u.UserId,
                                                                  JoinProperty2 = 2,
                                                                  JoinProperty3 = u.UnitId
                                                              }
                                                              select new UserDTO
                                                              {
                                                                  UserId = u.UserId,
                                                                  UserFirstName = u.UserFirstName,
                                                                  UserSurname = u.UserSurname,
                                                                  UserName = u.UserName,
                                                                  Email = u.Email
                                                              },
                                            Networks = from n in c.Networks
                                                       select new NetworkDTO
                                                       {
                                                           NetworkId = n.NetworkId,
                                                           NetworkName = n.NetworkName,
                                                           NetworkManagers = from ra in a.RoleAssignments
                                                                            join u in db.Users on
                                                                            new
                                                                            {
                                                                                JoinProperty1 = ra.UserId,
                                                                                JoinProperty2 = ra.RoleId,
                                                                                JoinProperty3 = ra.UnitId
                                                                            }
                                                                            equals
                                                                            new
                                                                            {
                                                                                JoinProperty1 = u.UserId,
                                                                                JoinProperty2 = 3,
                                                                                JoinProperty3 = u.UnitId
                                                                            }
                                                                            select new UserDTO
                                                                            {
                                                                                UserId = u.UserId,
                                                                                UserFirstName = u.UserFirstName,
                                                                                UserSurname = u.UserSurname,
                                                                                UserName = u.UserName,
                                                                                Email = u.Email
                                                                            },
                                                           NetworkDeputyManagers = from ra in a.RoleAssignments
                                                                                   join u in db.Users on
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = ra.UserId,
                                                                                       JoinProperty2 = ra.RoleId,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   equals
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = u.UserId,
                                                                                       JoinProperty2 = 4,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = u.UserId,
                                                                                       UserFirstName = u.UserFirstName,
                                                                                       UserSurname = u.UserSurname,
                                                                                       UserName = u.UserName,
                                                                                       Email = u.Email
                                                                                   },
                                                           Regions = from r in n.Regions
                                                                     select new RegionDTO
                                                                     {
                                                                         RegionId = r.RegionId,
                                                                         RegionName = r.RegionName,
                                                                         RegionManagers = from ra in a.RoleAssignments
                                                                                   join u in db.Users on
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = ra.UserId,
                                                                                       JoinProperty2 = ra.RoleId,
                                                                                       JoinProperty3 = ra.UnitId
                                                                                   }
                                                                                   equals
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = u.UserId,
                                                                                       JoinProperty2 = 5,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = u.UserId,
                                                                                       UserFirstName = u.UserFirstName,
                                                                                       UserSurname = u.UserSurname,
                                                                                       UserName = u.UserName,
                                                                                       Email = u.Email
                                                                                   },
                                                                         RegionDeputyManagers = from ra in a.RoleAssignments
                                                                                   join u in db.Users on
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = ra.UserId,
                                                                                       JoinProperty2 = ra.RoleId,
                                                                                       JoinProperty3 = ra.UnitId
                                                                                   }
                                                                                   equals
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = u.UserId,
                                                                                       JoinProperty2 = 6,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = u.UserId,
                                                                                       UserFirstName = u.UserFirstName,
                                                                                       UserSurname = u.UserSurname,
                                                                                       UserName = u.UserName,
                                                                                       Email = u.Email
                                                                                   },
                                                                         Branches = from b in r.Branches
                                                                                    select new BranchDTO
                                                                                    {
                                                                                        BranchId = b.BranchId,
                                                                                        BranchName = b.BranchName,
                                                                                        BranchManagers = from ra in a.RoleAssignments
                                                                                   join u in db.Users on
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = ra.UserId,
                                                                                       JoinProperty2 = ra.RoleId,
                                                                                       JoinProperty3 = ra.UnitId
                                                                                   }
                                                                                   equals
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = u.UserId,
                                                                                       JoinProperty2 = 7,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = u.UserId,
                                                                                       UserFirstName = u.UserFirstName,
                                                                                       UserSurname = u.UserSurname,
                                                                                       UserName = u.UserName,
                                                                                       Email = u.Email
                                                                                   },
                                                                                        BranchDeputyManagers = from ra in a.RoleAssignments
                                                                                   join u in db.Users on
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = ra.UserId,
                                                                                       JoinProperty2 = ra.RoleId,
                                                                                       JoinProperty3 = ra.UnitId
                                                                                   }
                                                                                   equals
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = u.UserId,
                                                                                       JoinProperty2 = 8,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = u.UserId,
                                                                                       UserFirstName = u.UserFirstName,
                                                                                       UserSurname = u.UserSurname,
                                                                                       UserName = u.UserName,
                                                                                       Email = u.Email
                                                                                   },
                                                                                        Advisors = from ra in a.RoleAssignments
                                                                                   join u in db.Users on
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = ra.UserId,
                                                                                       JoinProperty2 = ra.RoleId,
                                                                                       JoinProperty3 = ra.UnitId
                                                                                   }
                                                                                   equals
                                                                                   new
                                                                                   {
                                                                                       JoinProperty1 = u.UserId,
                                                                                       JoinProperty2 = 9,
                                                                                       JoinProperty3 = u.UnitId
                                                                                   }
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = u.UserId,
                                                                                       UserFirstName = u.UserFirstName,
                                                                                       UserSurname = u.UserSurname,
                                                                                       UserName = u.UserName,
                                                                                       Email = u.Email
                                                                                   }
                                                                                    }

                                                                     }
                                                       }

                                        }
                        };

            return query;
        }

        // GET: api/Administrations/5
        [ResponseType(typeof(Administration))]
        public async Task<IHttpActionResult> GetAdministration(int id)
        {
            Administration administration = await db.Administrations.FindAsync(id);
            if (administration == null)
            {
                return NotFound();
            }

            return Ok(administration);
        }

        // PUT: api/Administrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministration(int id, Administration administration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administration.AdministrationId)
            {
                return BadRequest();
            }

            db.Entry(administration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrationExists(id))
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

        // POST: api/Administrations
        [ResponseType(typeof(Administration))]
        public async Task<IHttpActionResult> PostAdministration(Administration administration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrations.Add(administration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administration.AdministrationId }, administration);
        }

        // DELETE: api/Administrations/5
        [ResponseType(typeof(Administration))]
        public async Task<IHttpActionResult> DeleteAdministration(int id)
        {
            Administration administration = await db.Administrations.FindAsync(id);
            if (administration == null)
            {
                return NotFound();
            }

            db.Administrations.Remove(administration);
            await db.SaveChangesAsync();

            return Ok(administration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministrationExists(int id)
        {
            return db.Administrations.Count(e => e.AdministrationId == id) > 0;
        }
    }
}