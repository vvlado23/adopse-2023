using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
//using ADOPSE_2023.Models;

namespace ADOPSE_2023.Repository
{
    public class Modules : IModules
    {
        private readonly ModuleContext _dbcontext;

        public Modules()
        {
            _dbcontext = new ModuleContext();
        }

        public Modules (ModulesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void CreateModule(modules m)
        {
            _dbcontext.modules.Add(m);
            Save();
        }

        public void DeleteModule(int id)
        {
            var m = _dbcontext.modules.Find(id);
            if (m != null)
            {
                _dbcontext.modules.Remove();
            }
        }

        public IEnumerable<modules> Get_Modules()
        {
            return _dbcontext.modules.ToList();
        }

        public modules Get_ModuleById(int id)
        {
            return _dbcontext.modules.Find(id);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void UpdateModule(modules m)
        {
            _dbcontext.Entry(m).State = EntityState.Modified;
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
