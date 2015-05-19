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
        public int ClientId { get; set; }
        public string Owner { get; set; }
        public string CompanyName { get; set; }

        public virtual Base Base { get; set; }
    }
}