using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public string ResultName { get; set; }
        public int NextResultListId { get; set; }
        public int StatusId { get; set; }

        public virtual ResultList NextResultList { get; set; }
        public virtual Status Status { get; set; }
    }
}