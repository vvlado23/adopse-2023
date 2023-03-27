using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
//using ADOPSE_2023.Models;

namespace ADOPSE_2023.Repository
{
    public class Lecturer : ILecturer
    {
        private readonly LecturerContext _dbcontext;

        public Lecturer()
        {
            _dbcontext = new LecturerContext();
        }

        public Lecturer(LecturerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void CreateLecturer(lecturer l)
        {
            _dbcontext.lecturer.Add(l);
            Save();
        }

        public void DeleteLecturer(int id)
        {
            var l = _dbcontext.lecturer.Find(id);
            if (l != null)
            {
                _dbcontext.lecturer.Remove();
            }

        }

        public IEnumerable<lecturer> Get_Lecturer()
        {
            return _dbcontext.lecturer.ToList();
        }

        public lecturer Get_LecturerById(int id)
        {
            return _dbcontext.lecturer.Find(id);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void UpdateLecturer(lecturer l)
        {
            _dbcontext.Entry(l).State = EntityState.Modified;
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
