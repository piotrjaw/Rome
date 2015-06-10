﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Rome.QueryObjects
{
    public class EventQO
    {
        public int UserId { get; set; }
        public DateTime MinEventDate { get; set; }
        public DateTime MaxEventDate { get; set; }
    }
}