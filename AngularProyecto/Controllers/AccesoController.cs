using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularProyecto.Models;
using AngularProyecto.ModelsMetodos;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace AngularProyecto.Controllers
{
    public class AccesoController : Controller
    {
        private IConfiguration configuration;
        public ActionResult Logeo()
        {
            return View();
        }
        // GET: Acceso
        [HttpGet]
        public ActionResult Logeando(string usu, string contra)
        {
            string Resultado;
            int opciones = 0;
            bool bandera = false;
            try
            {
                var data = new MAcceso().GetLogeo(usu, contra);
                if (data.ResultadoFinal == "Encontrado")
                {
                    opciones = 1;
                    bandera = true;
                    MConexion.SetListaLogeo(data);
                    //MenuHeader();
                    //HttpContext.Session.SetString("variable",data.Usuario);
                    //HttpContext.Session =data;
                    //var s =HttpContext.Session.GetString("variable");
                }
                if (data.ResultadoFinal == "Sin Resultado")
                {
                    opciones = 2;
                }
                return Json(new { isValid = bandera,opcion = opciones });
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
                opciones = 3;
                return Json(new { isValid = false, opcion = opciones });
            }
        }
        public AccesoController (IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IActionResult ConfigServidor()
        {
            //Metodo para leer json de configuracion de la base de datos
            string serv = this.configuration.GetConnectionString("Host");
            string catalo = this.configuration.GetConnectionString("Catalogo");
            string Connprueba = @"Data Source=" + serv + ";Initial Catalog=" + catalo + ";Integrated Security=True";
            Console.Write(Connprueba);


            //Metodo para editar json de configuracion de la base de datos
            //var op=new Servidor {Host="..",Catalogo="Restaurante2" };
            //string json = JsonConvert.SerializeObject(op);
            //string json2 = "{'ConnectionStrings':"+json+"}";
            //string filepath = string.Empty;
            //string path = @"../AngularProyecto/appsettings.json";
            //System.IO.File.WriteAllText(path,json2);
            return View("~/Views/Acceso/ConfigServidor.cshtml");
        }



        public ActionResult Index()
        {
            return View();
        }

        // GET: Acceso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Acceso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acceso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Acceso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Acceso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Acceso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acceso/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}