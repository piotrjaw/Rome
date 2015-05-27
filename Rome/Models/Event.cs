﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Base Base { get; set; }
    }
}