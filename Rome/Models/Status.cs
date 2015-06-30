﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int StatusValue { get; set; }

        public virtual Client Client { get; set; }
    }
}