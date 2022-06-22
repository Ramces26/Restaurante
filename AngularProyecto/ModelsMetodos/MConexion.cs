using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngularProyecto.Models;

namespace AngularProyecto.ModelsMetodos
{
    public static class MConexion
    {
        private static string Conn = @"Data Source=.;Initial Catalog=Restaurante;Integrated Security=True";
        private static Acceso.AcceResultado Listalogin= new Acceso.AcceResultado();
        //Metodo para obtener la conexion a la base de datos
        public static string GetCadenaConexion()
        {
            return Conn;
        }
        //metodo para almacenar datos de resultado del logeo
        public static Acceso.AcceResultado SetListaLogeo(Acceso.AcceResultado datos)
        {
            try
            {
                Listalogin = datos;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return Listalogin;
        }
        //metodo para obtener el resultado del logeo
        public static Acceso.AcceResultado GetListaLogeo()
        {
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //}
            return Listalogin;
        }
        //metodo para redibujar la vista
        public static string RenderPartialViewToString(this Controller controller, string viewName, object model)
        {
            string VistaSalida ="";
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                var viewResult = viewEngine.FindView(controller.ControllerContext, viewName, true);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw, new HtmlHelperOptions());
               viewResult.View.RenderAsync(viewContext);
                VistaSalida =sw.GetStringBuilder().ToString();
                return sw.ToString();
            }
        }
    }
}
