using ADOPSE_2023.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ADOPSE_2023.Controllers
{
    public class EventController : Controller
    {
       private readonly IEvent evt;

        public EventController()
        {
            evt = new Event(new EventContext());
        }
        public EventController(IEvent evt)
        {
            this.evt = evt;
        }

        public ActionResult Index()
        {
            var e = evt.Get_Event();
            return View(e);
        }

        public ActionResult Details(int id)
        {
            var e = evt.Get_EventById(id);
            return View(e);
        }

        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(events e)
        {
            if (ModelState.IsValid)
            {
                evt.CreateEvent(e);
                evt.Save();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            var e = evt.Get_EventById(id);
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(events e)
        {
            if (ModelState.IsValid)
            {
                evt.UpdateEvent(e);
                evt.Save();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        public ActionResult Delete(int id)
        {
            var e = evt.Get_EventById(id);
            return View(e);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evt.DeleteEvent(id);
            evt.Save();
            return RedirectToAction("Index");
        }
    }
}
