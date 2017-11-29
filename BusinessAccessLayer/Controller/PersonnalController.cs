using DataAccessLayer.Implementation;
using DataAccessLayer.Service;
using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Controller
{
   public class PersonnalController
    {
        private IPersonnalService personnalService;

        public PersonnalController()
        {
            personnalService = new PersonnalService();
        }

        public PersonnalViewModel Detail(int id)
        {
            var model = new PersonnalViewModel();
            model = personnalService.GetDetailById(id);
            return model;
        }

        public List<PersonnalViewModel> GetList(string searchText)
        {
            var model = new PersonnalListModel();
            model.PersonnalList = personnalService.List(searchText);
            return model.PersonnalList;
        }
    }
}
