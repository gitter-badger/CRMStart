using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMStart.Core.Domain.KnowledgeBase;
using CRMStart.Data;
using CRMStart.Web.Framework.Controllers;

namespace CRMStart.Web.Areas.Knowledgebase.Controllers
{
    public class SectionsController : BaseController
    {

        // GET: Knowledgebase/Sections
        public async Task<ActionResult> Index()
        {
            return View(await Db.Sections.Include(x => x.Categories).Where(x => x.Archived == false).ToListAsync());
        }

        // GET: Knowledgebase/Sections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await Db.Sections.FindAsync(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Knowledgebase/Sections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knowledgebase/Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Archived")] Section section)
        {
            if (ModelState.IsValid)
            {
                Db.Sections.Add(section);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(section);
        }

        // GET: Knowledgebase/Sections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await Db.Sections.FindAsync(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Knowledgebase/Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Archived")] Section section)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(section).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // GET: Knowledgebase/Sections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = await Db.Sections.FindAsync(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Knowledgebase/Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Section section = await Db.Sections.FindAsync(id);
            Db.Sections.Remove(section);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
