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
        [ActionName("GetAdm")]
        public IQueryable<AdministrationDTO> GetAdministrations()
        {
            var query = from u in db.Units
                        where u.UnitTypeId == 1
                        select new AdministrationDTO
                        {
                            AdministrationId = u.UnitId,
                            Admins = from ra1 in u.RoleAssignments
                                     join us1 in db.Users on ra1.UserId equals us1.UserId
                                     where ra1.RoleId == 1 && ra1.UnitId == u.UnitId
                                     select new UserDTO
                                     {
                                         UserId = us1.UserId,
                                         UserFirstName = us1.UserFirstName,
                                         UserSurname = us1.UserSurname,
                                         UserName = us1.UserName,
                                         Email = us1.Email
                                     },
                            Companies = from ur2 in u.UnitRelations
                                        join u2 in db.Units on ur2.ChildUnitId equals u2.UnitId
                                        where u2.UnitTypeId == 2
                                        select new CompanyDTO
                                        {
                                            CompanyId = u2.UnitId,
                                            CompanyName = u2.UnitName,
                                            CompanyManagers = from ra2 in u2.RoleAssignments
                                                              join us2 in db.Users on ra2.UserId equals us2.UserId
                                                              where ra2.RoleId == 1 && ra2.UnitId == u2.UnitId
                                                              select new UserDTO
                                                              {
                                                                  UserId = us2.UserId,
                                                                  UserFirstName = us2.UserFirstName,
                                                                  UserSurname = us2.UserSurname,
                                                                  UserName = us2.UserName,
                                                                  Email = us2.Email
                                                              },
                                            Networks = from ur3 in u2.UnitRelations
                                                       join u3 in db.Units on ur3.ChildUnitId equals u3.UnitId
                                                       where u3.UnitTypeId == 3
                                                       select new NetworkDTO
                                                       {
                                                           NetworkId = u3.UnitId,
                                                           NetworkName = u3.UnitName,
                                                           NetworkManagers = from ra3 in u3.RoleAssignments
                                                                             join us3 in db.Users on ra3.UserId equals us3.UserId
                                                                             where ra3.RoleId == 1 && ra3.UnitId == u3.UnitId
                                                                             select new UserDTO
                                                                             {
                                                                                 UserId = us3.UserId,
                                                                                 UserFirstName = us3.UserFirstName,
                                                                                 UserSurname = us3.UserSurname,
                                                                                 UserName = us3.UserName,
                                                                                 Email = us3.Email
                                                                             },
                                                           NetworkDeputyManagers = from ra3 in u3.RoleAssignments
                                                                                   join us3 in db.Users on ra3.UserId equals us3.UserId
                                                                                   where ra3.RoleId == 2 && ra3.UnitId == u3.UnitId
                                                                                   select new UserDTO
                                                                                   {
                                                                                       UserId = us3.UserId,
                                                                                       UserFirstName = us3.UserFirstName,
                                                                                       UserSurname = us3.UserSurname,
                                                                                       UserName = us3.UserName,
                                                                                       Email = us3.Email
                                                                                   },
                                                           Regions = from ur4 in u3.UnitRelations
                                                                     join u4 in db.Units on ur4.ChildUnitId equals u4.UnitId
                                                                     where u4.UnitTypeId == 4
                                                                     select new RegionDTO
                                                                     {
                                                                         RegionId = u4.UnitId,
                                                                         RegionName = u4.UnitName,
                                                                         RegionManagers = from ra4 in u4.RoleAssignments
                                                                                          join us4 in db.Users on ra4.UserId equals us4.UserId
                                                                                          where ra4.RoleId == 1 && ra4.UnitId == u4.UnitId
                                                                                          select new UserDTO
                                                                                          {
                                                                                              UserId = us4.UserId,
                                                                                              UserFirstName = us4.UserFirstName,
                                                                                              UserSurname = us4.UserSurname,
                                                                                              UserName = us4.UserName,
                                                                                              Email = us4.Email
                                                                                          },
                                                                         RegionDeputyManagers = from ra4 in u4.RoleAssignments
                                                                                                join us4 in db.Users on ra4.UserId equals us4.UserId
                                                                                                where ra4.RoleId == 2 && ra4.UnitId == u4.UnitId
                                                                                                select new UserDTO
                                                                                                {
                                                                                                    UserId = us4.UserId,
                                                                                                    UserFirstName = us4.UserFirstName,
                                                                                                    UserSurname = us4.UserSurname,
                                                                                                    UserName = us4.UserName,
                                                                                                    Email = us4.Email
                                                                                                },
                                                                         Branches = from ur5 in u4.UnitRelations
                                                                                    join u5 in db.Units on ur5.ChildUnitId equals u5.UnitId
                                                                                    where u5.UnitTypeId == 5
                                                                                    select new BranchDTO
                                                                                    {
                                                                                        BranchId = u5.UnitId,
                                                                                        BranchName = u5.UnitName,
                                                                                        BranchManagers = from ra5 in u5.RoleAssignments
                                                                                                         join us5 in db.Users on ra5.UserId equals us5.UserId
                                                                                                         where ra5.RoleId == 1 && ra5.UnitId == u5.UnitId
                                                                                                         select new UserDTO
                                                                                                         {
                                                                                                             UserId = us5.UserId,
                                                                                                             UserFirstName = us5.UserFirstName,
                                                                                                             UserSurname = us5.UserSurname,
                                                                                                             UserName = us5.UserName,
                                                                                                             Email = us5.Email
                                                                                                         },
                                                                                        BranchDeputyManagers = from ra5 in u5.RoleAssignments
                                                                                                               join us5 in db.Users on ra5.UserId equals us5.UserId
                                                                                                               where ra5.RoleId == 2 && ra5.UnitId == u5.UnitId
                                                                                                               select new UserDTO
                                                                                                               {
                                                                                                                   UserId = us5.UserId,
                                                                                                                   UserFirstName = us5.UserFirstName,
                                                                                                                   UserSurname = us5.UserSurname,
                                                                                                                   UserName = us5.UserName,
                                                                                                                   Email = us5.Email
                                                                                                               },
                                                                                        Advisors = from ra5 in u5.RoleAssignments
                                                                                                   join us5 in db.Users on ra5.UserId equals us5.UserId
                                                                                                   where ra5.RoleId == 3 && ra5.UnitId == u5.UnitId
                                                                                                   select new UserDTO
                                                                                                   {
                                                                                                       UserId = us5.UserId,
                                                                                                       UserFirstName = us5.UserFirstName,
                                                                                                       UserSurname = us5.UserSurname,
                                                                                                       UserName = us5.UserName,
                                                                                                       Email = us5.Email
                                                                                                   }
                                                                                    }
                                                                     }
                                                       }

                                        }
                        };
            return query;
        }

    }
}