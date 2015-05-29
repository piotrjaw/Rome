using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class RegionDTO
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public IEnumerable<UserDTO> RegionManagers { get; set; }
        public IEnumerable<UserDTO> RegionDeputyManagers { get; set; }
        public IEnumerable<BranchDTO> Branches { get; set; }
    }
}