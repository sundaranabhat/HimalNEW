using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public interface IPersonnalService
    {
        List<PersonnalViewModel> List(string searchText);
        PersonnalViewModel GetDetailById(int id);
        void Insert(PersonnalViewModel model);
        void Update(PersonnalViewModel model);
    }
}
