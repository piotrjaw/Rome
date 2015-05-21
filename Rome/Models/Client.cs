using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rome.Models
{
    public class Client
    {
        [Key, ForeignKey("BaseAssignment")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }
        public string Owner { get; set; }
        public string CompanyName { get; set; }
        public string BaseName { get; set; }
        public DateTime? BaseStart { get; set; }
        public DateTime? BaseEnd { get; set; }

        public virtual BaseAssignment BaseAssignment { get; set; }
    }
}