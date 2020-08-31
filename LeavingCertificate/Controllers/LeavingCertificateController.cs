using LeavingCertificate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace LeavingCertificate.Controllers
{
    public class LeavingCertificateController : Controller
    {
        LeavingDbContext db = new LeavingDbContext();
        // GET: LeavingCertificate
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.LogStudentDatas.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LogStudentData log)
        {
            db.LogStudentDatas.Add(log);
            db.SaveChanges();
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LogStudentData log = db.LogStudentDatas.Find(id);
            return View(log);
        }

        [HttpPost]
        public ActionResult Edit(LogStudentData logStudentData)
        {
            db.Entry(logStudentData).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            LogStudentData log = db.LogStudentDatas.Find(id);
            return View(log);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LogStudentData log=db.LogStudentDatas.Find(id);
            db.LogStudentDatas.Remove(log);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PrintById(int id)
        {
            var LogStudent=db.LogStudentDatas.Where(e => e.Id == id).FirstOrDefault();
            return View(LogStudent);
        }

        public ActionResult Print(int id)
        {
            var print = new ActionAsPdf("PrintById", new { id = id });
            return print;
        }
    }
}