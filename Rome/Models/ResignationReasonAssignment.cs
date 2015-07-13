using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rome.Models
{
    public class ResignationReasonAssignment
    {
        public int ResignationReasonId { get; set; }
        public int ResignationReasonSetId { get; set; }

        public virtual ResignationReason ResignationReason { get; set; }
        public virtual ResignationReasonSet ResignationReasonSet { get; set; }
    }
}
