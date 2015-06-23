using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class BaseOptionSetDTO
    {
        public int BaseOptionSetId { get; set; }
        public string BaseOptionSetDescription { get; set; }

        public ResultSetDTO ResultSet { get; set; }
        public ResignationReasonSetDTO ResignationReasonSet { get; set; }
        public ProductSetDTO ProductSet { get; set; }
    }
}