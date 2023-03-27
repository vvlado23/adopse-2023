using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ADOPSE_2023.Models;

namespace ADOPSE_2023.Repository
{
    public interface IModules
    {
        IEnumerable<modules> Get_Modules();
        modules Get_ModuleById(int id);
        void CreateModule(modules m);
        void UpdateModule(modules m);
        void DeleteModule(int id);
        void Save();
    }
}
