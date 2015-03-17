using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Optimization;
using System.Web.Razor.Tokenizer.Symbols;

namespace GlobalEventNepal.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Bootstrap/bootstrap.css",
                "~/Content/Bootstrap/bootstrap-theme.css",
                "~/Content/Bootstrap/carousel.css",
                "~/Content/eventCalender.css",
                "~/Content/eventCalender_theme.css",
                "~/Content/eventCalender_theme_responsive.css",
                "~/Content/CommonStyles.css",
                "~/Content/Site.css"));
            
            // Javascript BUndles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/Bootstrap/bootstrap.min.js",
                "~/Scripts/Bootstrap/ie10-viewport-bug-workaround.js",
                "~/Scripts/Bootstrap/ie-emulation-modes-warning.js",
                "~/Scripts/modernizer-2.6.2.js",
                "~/Scripts/jquery.eventCalender.js",
                "~/Scripts/Site.js"));
        }
    }
}