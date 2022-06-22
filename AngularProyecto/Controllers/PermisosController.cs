using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularProyecto.Models;
using AngularProyecto.ModelsMetodos;
using Newtonsoft.Json;

namespace AngularProyecto.Controllers
{
    public class PermisosController : Controller
    {
        // GET: Permisos
        public ActionResult Index()
        {
            return View(new MPermisos().GetPermisos());
        }

        // GET: Permisos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Permisos/Create
        public ActionResult Create(int opcion)
        {
            //return View();
            return PartialView("~/Views/Permisos/Create.cshtml");
        }

        // POST: Permisos/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(string valor)
        {
            string Resultado;
            int opciones=0;
            bool bandera = false;
            string Renderpagina =string.Empty;
            try
            {
                // TODO: Add insert logic here
                 Resultado = new MPermisos().InsertarPermiso(valor);
                //return  View(Resultado);
                if (Resultado == "Error Insert")
                {
                    opciones = 3;
                }
                if (Resultado == "Repetido")
                {
                    opciones = 2;
                }
                if (Resultado == "Almacenado")
                {
                    opciones = 1;
                    bandera = true;
                    var data = new MPermisos().GetPermisos();
                    Renderpagina = MConexion.RenderPartialViewToString(this, "Index", data);
                }
                return Json(new { isValid = bandera, data = Renderpagina,opcion=opciones });
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
                opciones = 4;
                return Json(new { isValid = false, data = ex.Message,opcion=4 });
            }
        }
        [HttpPost]
        public ActionResult Anular(int id)
        {
            string Resultado;
            int opciones = 0;
            bool bandera = false;
            string Renderpagina = string.Empty;
            try
            {
                // TODO: Add insert logic here
                Resultado = new MPermisos().AnularPermiso(id);
                //return  View(Resultado);
                if (Resultado == "No encontrado")
                {
                    opciones = 2;
                }
                if (Resultado == "Anulado")
                {
                    opciones = 1;
                    bandera = true;
                    var data = new MPermisos().GetPermisos();
                    Renderpagina = MConexion.RenderPartialViewToString(this, "Index", data);
                }
                return Json(new { isValid = bandera, data = Renderpagina, opcion = opciones });
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
                opciones = 3;
                return Json(new { isValid = false, data = ex.Message, opcion = 4 });
            }
        }

        // GET: Permisos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Permisos/Edit/5
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

        // GET: Permisos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Permisos/Delete/5
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