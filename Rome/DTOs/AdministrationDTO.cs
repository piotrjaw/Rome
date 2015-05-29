using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class AdministrationDTO
    {
        public int AdministrationId { get; set; }
        public IEnumerable<UserDTO> Admins { get; set; }
        public IEnumerable<CompanyDTO> Companies { get; set; }
    }
}