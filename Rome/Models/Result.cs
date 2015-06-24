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

        public bool IsPositiveEnding { get; set; }
        public bool IsNegativeEnding { get; set; }
        public int SpecificToEventId { get; set; }
        public int ResultingEventId { get; set; }
    }
}