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
                return (int)Math.Max((BaseEnd - now).TotalDays + 1, -1);
            }
            set { }
        }

        public int Progress
        {
            get
            {
                DateTime now = DateTime.Now;
                return (int)Math.Min(100*((now - BaseStart).TotalDays)/((BaseEnd - BaseStart).TotalDays), 100);
            }
            set { }
        }

        public virtual ICollection<BaseAssignment> BaseAssignments { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}