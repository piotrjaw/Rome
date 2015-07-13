using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Session
    {
        public int UserId {get; set;}
        public Guid SessionId { get; set; }
        public DateTime SessionStartDate { get; set; }
        public DateTime SessionExpirationDate { get; set; }

        public virtual User User { get; set; }

        public Session()
        {
        }

        public Session(int UserId)
        {
            this.UserId = UserId;
            this.SessionId = Guid.NewGuid();
            this.SessionStartDate = DateTime.Now;
            this.SessionExpirationDate = this.SessionStartDate.AddHours(1);
        }
    }
}