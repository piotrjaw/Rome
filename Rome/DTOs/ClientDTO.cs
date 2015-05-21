using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Owner { get; set; }
        public string CompanyName { get; set; }
        public string BaseName { get; set; }
        public DateTime? BaseStart { get; set; }
        public DateTime? BaseEnd { get; set; }
    }
}