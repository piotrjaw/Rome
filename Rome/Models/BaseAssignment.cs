using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rome.Models
{
    public class BaseAssignment
    {
        [Key]
        public int BaseAssignmentId { get; set; }
        public int BaseId { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("BaseId")]
        public virtual Base Base { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}