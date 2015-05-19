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

        public virtual ICollection<Client> Clients { get; set; }
    }
}