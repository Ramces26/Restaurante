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
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            ViewBag.prueba = "Exito3";
            ViewBag.opcion = 2;
            return View(new MPersonas().GetPersonas());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return PartialView("~/Views/Personas/Create.cshtml");
        }

        // POST: Personas/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Personas personas)
        {
            string Resultado;
            int opciones = 0;
            bool bandera = false;
            string Renderpagina = string.Empty;
            try
            {
                // TODO: Add insert logic here
                Resultado = new MPersonas().InsertPersonas(personas);
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
                    var data = new MPersonas().GetPersonas();
                    Renderpagina = MConexion.RenderPartialViewToString(this, "Index", data);
                }
                return Json(new { isValid = bandera, data = Renderpagina, opcion = opciones });
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
                opciones = 4;
                return Json(new { isValid = false, data = ex.Message, opcion = 4 });
            }
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
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

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
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