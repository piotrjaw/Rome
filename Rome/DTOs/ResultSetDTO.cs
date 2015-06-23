using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class ResultSetDTO
    {
        public int ResultSetId { get; set; }
        public string ResultSetDescription { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }
}