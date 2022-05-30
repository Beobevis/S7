using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S7.DataConnect;
using S7.Models;
using PagedList;

namespace S7.Controllers
{
    public class SubjectsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Subjects
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SubjectNameSortParm = String.IsNullOrEmpty(sortOrder) ? "subjectname_desc" : "";
            ViewBag.SubjectCodeSortParm = sortOrder == "SubjectCode" ? "subjectcode_desc" : "SubjectCode";
            ViewBag.StartDateSort = sortOrder == "StartDate" ? "startD_desc" : "StartDate";
            ViewBag.EndDateSort = sortOrder == "EndDate" ? "endD_desc" : "EndDate";
            ViewBag.Description = "Description";
            var students = from s in db.Subjects
                           select s;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.SubjectName.ToLower().Replace(" ", String.Empty).Contains(searchString.ToLower().Replace(" ", String.Empty)) || s.SubjectCode.ToLower().Replace(" ", String.Empty).Contains(searchString.ToLower().Replace(" ",String.Empty))) ;
            }
            switch (sortOrder)
            {
                case "subjectname_desc":
                    students = students.OrderByDescending(s => s.SubjectName);
                    break;
                case "SubjectCode":
                    students = students.OrderBy(s => s.SubjectCode);
                    break;
                case "subjectcode_desc":
                    students = students.OrderByDescending(s => s.SubjectCode);
                    break;
                case "StartDate":
                    students = students.OrderBy(s => s.StartDate);
                    break;
                case "startD_desc":
                    students = students.OrderByDescending(s => s.StartDate);
                    break;
                case "EndDate":
                    students = students.OrderBy(s => s.EndDate);
                    break;
                case "endD_desc":
                    students = students.OrderByDescending(s=>s.EndDate);
                    break;
                default:
                    students = students.OrderBy(s => s.SubjectName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
            
        }

        // GET: Subjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubjectId,SubjectName,SubjectCode,Description,StartDate,EndDate")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubjectId,SubjectName,SubjectCode,Description,StartDate,EndDate")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subject subject = await db.Subjects.FindAsync(id);
            db.Subjects.Remove(subject);
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
