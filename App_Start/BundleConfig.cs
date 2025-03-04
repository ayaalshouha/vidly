﻿using System.Web;
using System.Web.Optimization;

namespace vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;


            //bundles.Add(new ScriptBundle("~/bundles/lib").Include(
            //         "~/Scripts/jquery-{version}.min.js",
            //          "~/Scripts/bootstrap.js",
            //            "~/Scripts/respond.js",
            //            "~/Scripts/bootbox.js",
            //            "~/Scripts/DataTables/jquery.datatables.js", 
            //            "~/Scripts/DataTables/datatables.bootstrap.js"
            //     ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                        ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
