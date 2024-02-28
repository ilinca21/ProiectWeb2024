using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace proiect.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/assets/css/style.css",
                "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                "~/assets/vendor/bootstrap-icons/bootstrap-icons.css",
                "~/assets/vendor/boxicons/css/boxicons.min.css",
                "~/assets/vendor/quill/quill.snow.css,",
                "~/assets/vendor/quill/quill.bubble.css",
                "~/assets/vendor/remixicon/remixicon.css",
                "~/assets/vendor/simple-datatables/style.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/navbar/js").Include(
                "~/assets/js/main",
                "~/assets/vendor/apexcharts/apexcharts.min",
                "~/assets/vendor/bootstrap/js/bootstrap.bundle.min",
                "~/assets/vendor/chart.js/chart.umd",
                "~/assets/vendor/echarts/echarts.min",
                "~/assets/vendor/quill/quill.min",
                "~/assets/vendor/simple-datatables/simple-datatables",
                "~/assets/vendor/tinymce/tinymce.min",
                "~/assets/vendor/php-email-form/validate"
                ));

        }
    }
}
