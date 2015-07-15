using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ActionName("getUserEvents")]
        public IQueryable<EventDTO> Post(EventQO id)
        {
            var sessionStatus = (from s in db.Sessions
                                 where s.UserId == id.UserId &&
                                       s.SessionId == id.SessionId &&
                                       s.SessionExpirationDate > DateTime.Now
                                 select s.SessionId).FirstOrDefault();
            if (!sessionStatus.Equals(null))
            {
                var query = from e in db.Events
                            where e.UserId == id.UserId &&
                                  e.EventDate.Year == id.Year &&
                                  e.EventDate.Month == id.Month
                            select new EventDTO
                            {
                                EventId = e.EventId,
                                EventDate = e.EventDate,
                                SetEventDate = e.SetEventDate,
                                Comment = e.Comment,
                                Client = e.Client,
                                Base = e.Base,
                                User = e.User,
                                EventType = e.EventType,
                                Result = e.Result,
                                ResignationReason = e.ResignationReason,
                                Status = e.Status,
                                SetEventType = e.SetEventType
                            };
                return query;
            }
            else
            {
                return null;
            }

        }

    }
}