using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Base
    {
        public int BaseId { get; set; }
        public string BaseName { get; set; }
        public bool IsActive
        {
            get
            {
                DateTime now = DateTime.Now;
                if (now > BaseEnd)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            set { }
        }
        public DateTime BaseStart { get; set; }
        public DateTime BaseEnd { get; set; }

        public int DaysLeft
        {
            get
            {
                DateTime now = DateTime.Now;
                return (int)(BaseEnd - now).TotalDays;
            }
            set { }
        }

        public virtual ICollection<BaseAssignment> BaseAssignments { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}