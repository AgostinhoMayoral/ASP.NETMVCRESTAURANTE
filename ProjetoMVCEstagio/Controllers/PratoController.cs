using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntidadesDAL;

namespace ProjetoMVCEstagio.Controllers
{
    public class PratoController : Controller
    {
        private CadastroModelo db = new CadastroModelo();

        // GET: Prato
        public async Task<ActionResult> Index()
        {
            var prato = db.Prato.Include(p => p.Restaurante);
            return View(await prato.ToListAsync());
        }

        // GET: Prato/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = await db.Prato.FindAsync(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: Prato/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteId = new SelectList(db.Restaurante, "RestauranteId", "RestauranteNome");
            return View();
        }

        // POST: Prato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PratoId,RestauranteId,PratoNome,PratoPreco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Prato.Add(prato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RestauranteId = new SelectList(db.Restaurante, "RestauranteId", "RestauranteNome", prato.RestauranteId);
            return View(prato);
        }

        // GET: Prato/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = await db.Prato.FindAsync(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestauranteId = new SelectList(db.Restaurante, "RestauranteId", "RestauranteNome", prato.RestauranteId);
            return View(prato);
        }

        // POST: Prato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PratoId,RestauranteId,PratoNome,PratoPreco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RestauranteId = new SelectList(db.Restaurante, "RestauranteId", "RestauranteNome", prato.RestauranteId);
            return View(prato);
        }

        // GET: Prato/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = await db.Prato.FindAsync(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: Prato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prato prato = await db.Prato.FindAsync(id);
            db.Prato.Remove(prato);
            await db.SaveChangesAsync();
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
