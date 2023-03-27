using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
//using ADOPSE_2023.Models;
using ADOPSE_2023.Repository;

namespace ADOPSE_2023.Repository
{
    public class Event : IEvent
    {
        private readonly EventContext _dbcontext;

        public Event()
        {
            _dbcontext = new EventContext();
        }

        public Event(EventContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void CreateEvent(events e)
        {
            _dbcontext.events.Add(e);
            Save();
        }

        public void DeleteEvent(int id)
        {
            var e = _dbcontext.events.Find(id);
            if (e != null)
            {
                _dbcontext.events.Remove();
            }
        }

        public IEnumerable<events> Get_Event()
        {
            return _dbcontext.events.ToList();
        }

        public events Get_EventById(int id)
        {
            return _dbcontext.events.Find(id);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void UpdateEvent(events e)
        {
            _dbcontext.Entry(e).State = EntityState.Modified;
        }

        private bool _dispose = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._dispose)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            this._dispose = true;
        }

        void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
