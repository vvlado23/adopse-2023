using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ADOPSE_2023.Models;
//using ADOPSE_2023.Models;

namespace ADOPSE_2023.Repository
{
    public interface IEvent
    {
        IEnumerable<events> Get_Event();
        events Get_EventById(int id);
        void CreateEvent(events e);
        void UpdateEvent(events e);
        void DeleteEvent(int id);
        void Save();
    }
}
