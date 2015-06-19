using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Rome.QueryObjects
{
    public class UserQO
    {
        public int UserId { get; set; }
        public Guid SessionId { get; set; }
    }
}