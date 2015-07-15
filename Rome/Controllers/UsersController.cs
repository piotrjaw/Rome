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
using Rome.QueryObjects;

namespace Rome.Controllers
{
    public class UsersController : ApiController
    {
        private XSellContext db = new XSellContext();

        [HttpPost]
        [ActionName("getUser")]
        public async Task<UserDTO> Post(LoginQO id)
        {
            var query = (from u in db.Users
                        where u.UserName == id.UserName &&
                              u.Password == id.Password
                        select new UserDTO
                        {
                            UserId = u.UserId,
                            UserFirstName = u.UserFirstName,
                            UserSurname = u.UserSurname,
                            UserName = u.UserName,
                            Email = u.Email
                        }).FirstOrDefault();
            if (!query.Equals(null))
            {
                Session newSession = new Session(query.UserId);
                db.Sessions.Add(newSession);
                await db.SaveChangesAsync();

                var sessionQuery = (from s in db.Sessions
                                   where s.UserId == query.UserId
                                   orderby s.SessionExpirationDate descending
                                   select s.SessionId).FirstOrDefault();
                query.SessionId = sessionQuery;
                return query;
            }
            else
            {
                return null;
            }
        }
    }
}