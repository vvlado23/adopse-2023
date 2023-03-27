using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ADOPSE_2023.Models;

namespace ADOPSE_2023.Repository
{
    public interface ILecturer
    {
        IEnumerable<lecturer> Get_Lecturer();
        lecturer Get_LecturerById(int id);
        void CreateLecturer(lecturer l);
        void UpdateLecturer(lecturer l);
        void DeleteLecturer(int id);
        void Save();
    }
}
