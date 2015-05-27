using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class BaseDTO
    {
        public int BaseId { get; set; }
        public String BaseName { get; set; }
        public DateTime BaseStart { get; set; }
        public DateTime BaseEnd { get; set; }
        public int DaysLeft { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ClientDTO> Clients { get; set; }
    }
}