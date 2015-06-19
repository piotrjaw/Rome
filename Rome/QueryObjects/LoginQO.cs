using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Rome.QueryObjects
{
    public class LoginQO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}