using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class BranchDTO
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public IEnumerable<UserDTO> BranchManagers { get; set; }
        public IEnumerable<UserDTO> BranchDeputyManagers { get; set; }
        public IEnumerable<UserDTO> Advisors { get; set; }

    }
}