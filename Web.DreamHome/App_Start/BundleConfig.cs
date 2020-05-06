using System.Web;
using System.Web.Optimization;

namespace Web.DreamHome
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //********************** LOGIN PERSONALIZADO **************************
            //Login CSS

            bundles.Add(new StyleBundle("~/bundle/LoginCss").Include(
                     "~/Content/icons/icomoon/styles.css",
                     "~/Content/login/personalizado.css",
                     "~/Content/login/bootstrap.css",
                     "~/Content/login/core.css",
                     "~/Content/login/components.css",
                     "~/Content/login/colors.css", "~/Content/site.css"
                     ));

            //********************** FIN LOGIN PERSONALIZADO **************************

            //****************** SUBIR DOCUMENTOS *************************************

            bundles.Add(new StyleBundle("~/Content/fileinputCss").Include(
                     "~/Content/upload/fileinput.css"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/fileinputJs").Include(
                   "~/Scripts/upload/fileinput.js",
                    "~/Scripts/upload/locales/es.js",
                   "~/Scripts/upload/bootstrapUpload.min.js"
                   ));

            //****************** FIN SUBIR DOCUMENTOS *************************************           

            //****************** INICIO TABLAS CON BOTONES ********************************


            bundles.Add(new ScriptBundle("~/bundles/tablaBotonExportarJs").Include(
                   "~/Scripts/DataTables/jquery.dataTables.min.js",
                   "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                   "~/Scripts/DataTables/dataTables.buttons.min.js",
                   "~/Scripts/DataTables/buttons.bootstrap.min.js",
                   "~/Scripts/DataTables/jszip/3.1.3/jszip.min.js",
                   "~/Scripts/DataTables/pdfmake/0.1.32/pdfmake.min.js",
                   "~/Scripts/DataTables/pdfmake/0.1.32/vfs_fonts.js",
                   "~/Scripts/DataTables/buttons.html5.min.js",
                   "~/Scripts/DataTables/buttons.print.min.js",
                   "~/Scripts/DataTables/buttons.colVis.min.js",
                   "~/Scripts/moment/min/moment.min.js",
                   "~/Scripts/DataTables/dataTables.responsive.min.js",
                   "~/Scripts/DataTables/responsive.bootstrap.min.js",
                   //"~/Scripts/DataTables/buttons.flash.min.js",
                   "~/Scripts/IniciarTabla.js"));

            //Bootstrap 3.3.7
            bundles.Add(new StyleBundle("~/Content/tablaBotonExportarCss").Include(
                "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                "~/Content/DataTables/css/buttons.bootstrap.min.css",
                "~/Content/DataTables/css/responsive.bootstrap.min.css"
                //"~/Content/DataTables/css/jquery.dataTables.min.css",
                //"~/Content/DataTables/css/buttons.dataTables.min.css"
                ));

            //****************** FIN TABLAS CON BOTONES ********************************


            //Bootstrap 3.3.7
            bundles.Add(new StyleBundle("~/Content/bootstrapCSS").Include(
                "~/Content/bootstrap/dist/css/bootstrap.min.css"));

            //Font Awesome
            bundles.Add(new StyleBundle("~/Content/fontawesomeCSS").Include(
                      "~/Content/font-awesome/css/font-awesome.min.css"));

            //Ionicons
            bundles.Add(new StyleBundle("~/Content/ioniconsCSS").Include(
                      "~/Content/Ionicons/css/ionicons.min.css"));

            //Theme style
            bundles.Add(new StyleBundle("~/Content/AdminLTECSS").Include(
                      "~/Content/css/AdminLTE.min.css"));

            //allskinsCSS
            bundles.Add(new StyleBundle("~/Content/allskinsCSS").Include(
                      "~/Content/css/skins/_all-skins.min.css"));

            //morris.css
            bundles.Add(new StyleBundle("~/Content/morrisCSS").Include(
                      "~/Content/morris.js/morris.css"));

            //jquery-jvectormap.css
            bundles.Add(new StyleBundle("~/Content/jqueryjvectormapCSS").Include(
                      "~/Content/jvectormap/jquery-jvectormap.css"));

            //bootstrap-datepicker.css
            bundles.Add(new StyleBundle("~/Content/bootstrapdatepickerCSS").Include(
                      "~/Content/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"));

            //daterangepicker.css
            bundles.Add(new StyleBundle("~/Content/daterangepickerCSS").Include(
                      "~/Content/bootstrap-daterangepicker/daterangepicker.css"));

            //bootstrap3-wysihtml5.css
            bundles.Add(new StyleBundle("~/Content/bootstrap3wysihtml5CSS").Include(
                      "~/Content/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));

            //blue.css
            bundles.Add(new StyleBundle("~/Content/blueCSS").Include(
                      "~/Content/iCheck/square/blue.css"));

            // DataTables-- >
            bundles.Add(new StyleBundle("~/Content/bootstrapdataTablesCSS").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                      "~/Content/DataTables/css/responsive.bootstrap.min.css"));

            // all-- >
            bundles.Add(new StyleBundle("~/Content/allCSS").Include(
                      "~/Content/iCheck/all.css"));

            // colorpicker-- >
            bundles.Add(new StyleBundle("~/Content/colorpickerCSS").Include(
                      "~/Content/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css"));

            // colorpicker-- >
            bundles.Add(new StyleBundle("~/Content/select2CSS").Include(
                      "~/Content/select2/dist/css/select2.min.css"));


            /************** PLANTILLA JS ************/

            //jquery.JS
            bundles.Add(new ScriptBundle("~/bundles/jqueryJS").Include(
                      "~/Scripts/jquery/dist/jquery.min.js"));

            //jquery-ui.JS
            bundles.Add(new ScriptBundle("~/bundles/jqueryuiJS").Include(
                      "~/Scripts/jquery-ui/jquery-ui.min.js"));

            //bootstrap.JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrapJS").Include(
                      "~/Content/bootstrap/dist/js/bootstrap.min.js"));

            //raphael.JS
            bundles.Add(new ScriptBundle("~/bundles/raphaelJS").Include(
                      "~/Scripts/raphael/raphael.min.js"));

            //morris.JS
            bundles.Add(new ScriptBundle("~/bundles/morrisJS").Include(
                      "~/Content/morris.js/morris.min.js"));

            //jquery.sparkline.JS
            bundles.Add(new ScriptBundle("~/bundles/jquerysparklineJS").Include(
                      "~/Scripts/jquery-sparkline/dist/jquery.sparkline.min.js"));

            //jquery.sparkline.JS
            bundles.Add(new ScriptBundle("~/bundles/jquerysparklineJS").Include(
                      "~/Scripts/jvectormap/jquery-jvectormap-1.2.2.min.js"));

            //jqueryjvectormapworldmillen.JS
            bundles.Add(new ScriptBundle("~/bundles/jqueryjvectormapworldmillenJS").Include(
                      "~/Scripts/jvectormap/jquery-jvectormap-world-mill-en.js"));

            //jqueryknob.JS
            bundles.Add(new ScriptBundle("~/bundles/jqueryknobJS").Include(
                      "~/Scripts/jquery-knob/dist/jquery.knob.min.js"));

            //jqueryknob.JS
            bundles.Add(new ScriptBundle("~/bundles/jqueryknobJS").Include(
                      "~/Scripts/jquery-knob/dist/jquery.knob.min.js"));

            //moment.JS
            bundles.Add(new ScriptBundle("~/bundles/momentJS").Include(
                      "~/Scripts/moment/min/moment.min.js"));

            //daterangepicker.JS
            bundles.Add(new ScriptBundle("~/bundles/daterangepickerJS").Include(
                      "~/Content/bootstrap-daterangepicker/daterangepicker.js"));

            //bootstrap-datepicker.JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrapdatepickerJS").Include(
                      "~/Content/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"));

            //bootstrap3-wysihtml5.all.JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrap3wysihtml5allJS").Include(
                      "~/Content/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"));

            //jquery.slimscroll.js
            bundles.Add(new ScriptBundle("~/bundles/jqueryslimscrollJS").Include(
                      "~/Scripts/jquery-slimscroll/jquery.slimscroll.min.js"));

            //fastclick.js
            bundles.Add(new ScriptBundle("~/bundles/fastclickJS").Include(
                      "~/Scripts/fastclick/lib/fastclick.js"));

            //adminlte.js
            bundles.Add(new ScriptBundle("~/bundles/adminlteJS").Include(
                      "~/Scripts/js/adminlte.min.js"));

            //dashboard.js
            bundles.Add(new ScriptBundle("~/bundles/dashboardJS").Include(
                      "~/Scripts/js/pages/dashboard.js"));

            //dashboard.js
            bundles.Add(new ScriptBundle("~/bundles/demoJS").Include(
                      "~/Scripts/js/demo.js"));

            //icheck.js
            bundles.Add(new ScriptBundle("~/bundles/icheckJS").Include(
                      "~/Content/iCheck/icheck.min.js"));

            //datatables.net.js
            bundles.Add(new ScriptBundle("~/bundles/jquerydataTablesJS").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                      "~/Scripts/DataTables/dataTables.responsive.min.js",
                      "~/Scripts/DataTables/responsive.bootstrap.min.js",
                      "~/Scripts/moment/min/moment.min.js",
                      "~/Scripts/ModalMostrarTexto.js",
                      "~/Scripts/IniciarTabla.js"));


            //Para borrar
            //datatables.net.js
            //bundles.Add(new ScriptBundle("~/bundles/jquerydataTablesJS").Include(
            //          "~/Scripts/datatables.net/js/jquery.dataTables.min.js",
            //          "~/Content/datatables.net-bs/js/dataTables.bootstrap.min.js",
            //          "~/Scripts/datatables.net/js/dataTables.responsive.min.js",
            //          "~/Scripts/datatables.net/js/responsive.bootstrap.min.js",
            //          "~/Scripts/IniciarTabla.js"));

            //datatables.net-bs.js
            bundles.Add(new ScriptBundle("~/bundles/dataTablesbootstrapJS").Include(
                      "~/Content/DataTables/dataTables.bootstrap.min.js"));

            //select2FullJS
            bundles.Add(new ScriptBundle("~/bundles/select2FullJS").Include(
                      "~/Content/select2/dist/js/select2.full.min.js"));

            //inputmaskJS
            bundles.Add(new ScriptBundle("~/bundles/inputmaskJS").Include(
                      "~/Scripts/input-mask/jquery.inputmask.js",
                      "~/Scripts/input-mask/jquery.inputmask.date.extensions.js",
                      "~/Scripts/input-mask/jquery.inputmask.extensions.js"));

            //colorpickerJS
            bundles.Add(new ScriptBundle("~/bundles/colorpickerJS").Include(
                      "~/Content/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"));

            //colorpickerJS
            bundles.Add(new ScriptBundle("~/bundles/colorpickerJS").Include(
                      "~/Content/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"));

            //timepickerJS
            bundles.Add(new ScriptBundle("~/bundles/timepickerJS").Include(
                      "~/Scripts/timepicker/bootstrap-timepicker.min.js"));


            //*******************COLECCION PLANTILLA ***************************


            //Plantilla Principal CSS
            bundles.Add(new StyleBundle("~/Content/PlantillaPrincipalCss").Include(
                       "~/Content/bootstrap/dist/css/bootstrap.min.css",
                       "~/Content/font-awesome/css/font-awesome.min.css",
                       "~/Content/Ionicons/css/ionicons.min.css",
                       "~/Content/css/AdminLTE.min.css",
                       "~/Content/css/skins/_all-skins.min.css"));

            //Plantilla Principal Js
            bundles.Add(new ScriptBundle("~/bundles/PlantillaPrincipalJs").Include(
                      "~/Scripts/jquery/dist/jquery.min.js",
                      "~/Content/bootstrap/dist/js/bootstrap.min.js",
                      "~/Scripts/jquery-slimscroll/jquery.slimscroll.min.js",
                       "~/Scripts/fastclick/lib/fastclick.js",
                       "~/Scripts/js/adminlte.min.js",
                       "~/Scripts/js/demo.js"));


            //Plantilla Parte 1 Aisec
            bundles.Add(new StyleBundle("~/Content/PlantillaPrincipalParte1Css").Include(
                       "~/Content/bootstrap/dist/css/bootstrap.min.css",
                       "~/Content/font-awesome/css/font-awesome.min.css",
                       "~/Content/Inicio/css/font-awesome.min.css",
                       "~/Content/Ionicons/css/ionicons.min.css"));


            //Plantilla Parte 1 Aisec
            bundles.Add(new StyleBundle("~/Content/PlantillaPrincipalParte2Css").Include(
                       "~/Content/css/AdminLTE.min.css",
                       "~/Content/css/skins/_all-skins.min.css",
                       "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/PersonalizadoCss").Include(
                      "~/Content/site.css"));

            //********************* LIBRERIA CREACION DE FORMULARIOS ********************************


            bundles.Add(new StyleBundle("~/Content/FormularioCss").Include(
                        "~/Content/bootstrap-daterangepicker/daterangepicker.css",
                        "~/Content/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                        "~/Content/iCheck/all.css",
                        "~/Content/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                        "~/Content/select2/dist/css/select2.min.css",
                        "~/Content/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css",
                        "~/Content/SweerAlert2/dist/sweetalert2.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/FormularioJs").Include(
                        "~/Content/select2/dist/js/select2.full.min.js",
                        "~/Scripts/input-mask/jquery.inputmask.js",
                        "~/Scripts/input-mask/jquery.inputmask.date.extensions.js",
                        "~/Scripts/input-mask/jquery.inputmask.extensions.js",
                        "~/Scripts/moment/min/moment.min.js",
                        "~/Content/bootstrap-daterangepicker/daterangepicker.js",
                        "~/Content/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                        "~/Content/iCheck/icheck.min.js",
                        "~/Content/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/Scripts/timepicker/bootstrap-timepicker.min.js",
                        "~/Scripts/bootstrap-datetimepicker/bootstrap-datetimepicker.js",
                        "~/Scripts/Fecha.js",
                        "~/Scripts/ListaSeleccion.js",
                        "~/Content/SweerAlert2/dist/sweetalert2.min.js"));
        }
    }
}
