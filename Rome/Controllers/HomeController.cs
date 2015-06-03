﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Templates(string id)
        {
            switch (id.ToLower())
            {
                case "clientlist":
                    return PartialView("~/Views/Home/Templates/ClientList.cshtml");
                case "calendar":
                    return PartialView("~/Views/Home/Templates/Calendar.cshtml");
                case "meetings":
                    return PartialView("~/Views/Home/Templates/Meetings.cshtml");
                case "accountcreation":
                    return PartialView("~/Views/Home/Templates/AccountCreation.cshtml");
                case "branches":
                    return PartialView("~/Views/Home/Templates/Branches.cshtml");
                case "calendartemplate":
                    return PartialView("~/Views/Home/Templates/calendarTemplate.cshtml");
                case "calendarweektemplate":
                    return PartialView("~/Views/Home/Templates/calendarWeekTemplate.cshtml");
                case "calendardaytemplate":
                    return PartialView("~/Views/Home/Templates/calendarDayTemplate.cshtml");
                default:
                    return PartialView("~/Views/Home/Templates/ClientList.cshtml");
            }
        }
    }
}