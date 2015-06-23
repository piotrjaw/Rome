using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class BaseOptionSet
    {
        public int BaseOptionSetId { get; set; }
        public string BaseOptionSetDescription { get; set; }
        public int ResultSetId { get; set; }
        public int ResignationReasonSetId { get; set; }
        public int ProductSetId { get; set; }

        public ResultSet ResultSet { get; set; }
        public ResignationReasonSet ResignationReasonSet { get; set; }
        public ProductSet ProductSet { get; set; }
        public ICollection<Base> Bases { get; set; }
    }
}