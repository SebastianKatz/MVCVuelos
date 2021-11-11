using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVuelos.Data;
using MVCVuelos.Models;
using MVCVuelos.Admin;
//using MVCVuelos.Filtros;

namespace SistemaWebVuelos.Controllers
{
    //[Filtro]
    public class VueloController : Controller
    {
        private VueloDbContext context = new VueloDbContext();
        // GET: Vuelo
        public ActionResult Index()
        {
            return View("Index", AdmVuelo.Listar());
        }
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }
        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdmVuelo.Crear(vuelo);
                return RedirectToAction("Index");
            }
            return View("Create", vuelo);
        }
        public ActionResult Detail(int id)
        {
            Vuelo vuelo = AdmVuelo.BuscarPorId(id);
            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = AdmVuelo.BuscarPorId(id);
            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = AdmVuelo.BuscarPorId(id);
            AdmVuelo.Eliminar(vuelo);
            return RedirectToAction("Index");
        }
        public ActionResult BuscarPorDestino(string destino)
        {
            if (destino == "")
            {
                return RedirectToAction("Index");
            }
            return View("Index", AdmVuelo.ListarPorDestino(destino));
        }
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = AdmVuelo.BuscarPorIdParaDestino(id);
            if (vuelo != null)
            {
                return View("Edit", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdmVuelo.Modificar(vuelo);
                return RedirectToAction("Index");
            }
            return View("Edit", "Vuelo");
        }
    }
}