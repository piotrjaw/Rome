using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rome.Models;

namespace Rome.DTOs
{
    public class ResignationReasonSetDTO
    {
        public int ResignationReasonSetId { get; set; }
        public string ResignationReasonSetDescription { get; set; }
        public IEnumerable<ResignationReason> ResignationReasons { get; set; }
    }
}
