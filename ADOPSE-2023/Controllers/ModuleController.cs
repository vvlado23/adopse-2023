using ADOPSE_2023.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOPSE_2023.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IModules md;

        public ModuleController()
        {
            md = new Lecturer(new ModuleContext());
        }
        public ModuleController(IModules md)
        {
            this.md = md;
        }

        public ActionResult Index()
        {
            var m = md.Get_Modules();
            return View(m);
        }

        public ActionResult Details(int id)
        {
            var m = md.Get_ModuleById(id);
            return View(m);
        }

        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(modules m)
        {
            if (ModelState.IsValid)
            {
                md.CreateModule(m);
                md.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            var m = md.Get_ModuleById(id);
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(modules m)
        {
            if (ModelState.IsValid)
            {
                md.UpdateModule(m);
                md.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Delete(int id)
        {
            var m = md.Get_ModuleById(id);
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            md.DeleteModule(id);
            md.Save();
            return RedirectToAction("Index");
        }
    }
}
