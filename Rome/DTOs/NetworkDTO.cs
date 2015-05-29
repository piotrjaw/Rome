using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class NetworkDTO
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public IEnumerable<UserDTO> NetworkManagers { get; set; }
        public IEnumerable<UserDTO> NetworkDeputyManagers { get; set; }
        public IEnumerable<RegionDTO> Regions { get; set; }
    }
}