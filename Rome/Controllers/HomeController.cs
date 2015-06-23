using System;
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
                case "accountcreation":
                    return PartialView("~/Views/Home/Templates/AccountCreation.cshtml");
                case "branches":
                    return PartialView("~/Views/Home/Templates/Branches.cshtml");
                case "calendar":
                    return PartialView("~/Views/Home/Templates/Calendar.cshtml");
                case "clientlist":
                    return PartialView("~/Views/Home/Templates/ClientList.cshtml");
                case "meetings":
                    return PartialView("~/Views/Home/Templates/Meetings.cshtml");
                case "profile":
                    return PartialView("~/Views/Home/Templates/Profile.cshtml");
                default:
                    return PartialView("~/Views/Home/Templates/Error.cshtml");
            }
        }
        public ActionResult Directives(string id)
        {
            switch (id.ToLower())
            {
                case "calendardaytemplate":
                    return PartialView("~/Views/Home/Directives/calendarDayTemplate.cshtml");
                case "calendarweektemplate":
                    return PartialView("~/Views/Home/Directives/calendarWeekTemplate.cshtml");
                case "calendartemplate":
                    return PartialView("~/Views/Home/Directives/calendarTemplate.cshtml");
                case "eventform":
                    return PartialView("~/Views/Home/Directives/eventForm.cshtml");
                case "monthpicker":
                    return PartialView("~/Views/Home/Directives/monthPicker.cshtml");
                default:
                    return PartialView("~/Views/Home/Directives/error.cshtml");
            }
        }
    }
}