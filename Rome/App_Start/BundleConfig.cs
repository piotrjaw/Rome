﻿using System.Web;
using System.Web.Optimization;

namespace Rome
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular/angular.js",
                        "~/Scripts/angular-animate/angular-animate.js",
                        "~/Scripts/angular-aria/angular-aria.js",
                        "~/Scripts/angular-filter/dist/angular-filter.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment/moment.js",
                        "~/Scripts/moment/locale/pl.js"));

            bundles.Add(new ScriptBundle("~/bundles/d3").Include(
                        "~/Scripts/d3/d3.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/appControllers.js",
                        "~/Scripts/app/appFilters.js",
                        "~/Scripts/app/appDirectives.js",
                        "~/Scripts/app/appServices.js"));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                        "~/Scripts/angular-material/angular-material.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/style.less",
                      "~/Scripts/angular-material/angular-material.css"));

        }
    }
}
