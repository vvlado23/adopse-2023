using ADOPSE_2023.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOPSE_2023.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ILecturer lct;

        public LecturerController()
        {
            lct = new Lecturer(new LecturerContext());
        }
        public LecturerController(ILecturer lct)
        {
            this.lct = lct;
        }

        public ActionResult Index()
        {
            var l = lct.Get_Lecturer();
            return View(l);
        }

        public ActionResult Details(int id)
        {
            var l = lct.Get_LecturerById(id);
            return View(l);
        }

        public ActionResult Add(int id) 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(lecturer l) 
        {
            if (ModelState.IsValid)
            {
                lct.CreateLecturer(l);
                lct.Save();
                return RedirectToAction("Index");
            }
            return View(l);
        }

        public ActionResult Edit(int id)
        {
            var l = lct.Get_LecturerById(id);
            return View(l);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(lecturer l)
        {
            if (ModelState.IsValid)
            {
                lct.UpdateLecturer(l);
                lct.Save();
                return RedirectToAction("Index");
            }
            return View(l);
        }

        public ActionResult Delete(int id) 
        {
            var l = lct.Get_LecturerById(id);
            return View(l);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lct.DeleteLecturer(id);
            lct.Save();
            return RedirectToAction("Index");
        }
    }
}
