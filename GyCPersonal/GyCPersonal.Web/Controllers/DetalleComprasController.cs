using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GyCPersonal.EFContext;
using GyCPersonal.Entidades;

namespace GyCPersonal.Web.Controllers
{
    public class DetalleComprasController : Controller
    {
        private GyCPersonalDbContext db = new GyCPersonalDbContext();

        // GET: DetalleCompras
        public ActionResult Index()
        {
            var detallesCompras = db.DetallesCompras.Include(d => d.compra).Include(d => d.producto);
            return View(detallesCompras.ToList());
        }

        // GET: DetalleCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetallesCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Create
        public ActionResult Create()
        {
            ViewBag.compraId = new SelectList(db.Compras, "id", "observaciones");
            ViewBag.productoId = new SelectList(db.Productos, "id", "descripcion");
            return View();
        }

        // POST: DetalleCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,compraId,productoId,cantidad")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.DetallesCompras.Add(detalleCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.compraId = new SelectList(db.Compras, "id", "observaciones", detalleCompra.compraId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "descripcion", detalleCompra.productoId);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetallesCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.compraId = new SelectList(db.Compras, "id", "observaciones", detalleCompra.compraId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "descripcion", detalleCompra.productoId);
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,compraId,productoId,cantidad")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.compraId = new SelectList(db.Compras, "id", "observaciones", detalleCompra.compraId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "descripcion", detalleCompra.productoId);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetallesCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCompra detalleCompra = db.DetallesCompras.Find(id);
            db.DetallesCompras.Remove(detalleCompra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
