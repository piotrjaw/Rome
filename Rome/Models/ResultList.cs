using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class ResultList
    {
        public int ResultListId { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}