using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rome.Models
{
    public class Base
    {
        [Key, ForeignKey("BaseAssignments")]
        public int BaseId { get; set; }
        public string BaseName { get; set; }
        public DateTime BaseStart { get; set; }
        public DateTime BaseEnd { get; set; }

        public int DaysLeft
        {
            get
            {
                DateTime now = DateTime.Now;
                return (int)(BaseEnd - now).TotalDays;
            }
            set { DaysLeft = value; }
        }

        public virtual ICollection<BaseAssignment> BaseAssignments { get; set; }
    }
}