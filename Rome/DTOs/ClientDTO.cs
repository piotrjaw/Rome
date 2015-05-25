using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Owner { get; set; }
        public string CompanyName { get; set; }
    }
}