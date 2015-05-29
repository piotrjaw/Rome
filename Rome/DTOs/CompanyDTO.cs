using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<NetworkDTO> Networks { get; set; }
        public IEnumerable<UserDTO> CompanyManagers { get; set; }
    }
}