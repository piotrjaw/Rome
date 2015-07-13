﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid SessionId { get; set; }
    }
}