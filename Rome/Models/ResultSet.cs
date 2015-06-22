using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class ResultSet
    {
        public int ResultSetId { get; set; }
        public int ResultListId { get; set; }

        public virtual ResultList ResultList { get; set; }
    }
}