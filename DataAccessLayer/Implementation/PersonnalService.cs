using DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.ViewModel;

namespace DataAccessLayer.Implementation
{
   public class PersonnalService : IPersonnalService
    {
        public PersonnalViewModel GetDetailById(int id)
        {
           using( var entity = new HimalDbEntities())
            {
                var personnalValue = entity.Personnels.Where(x=>x.ID==id).FirstOrDefault();
                var model = new PersonnalViewModel();
                model.ID=personnalValue.ID;
                model.LASTNAME = personnalValue.LASTNAME;
                model.PLACEOFBIRTH = personnalValue.PLACEOFBIRTH;
                return model;

            }
        }

        public List<PersonnalViewModel> List(string searchText)
        {
            using (var entity = new HimalDbEntities())
            {
                var personnalList = entity.Personnels.Where(x=>x.FIRSTNAME.Contains(searchText)|| x.LASTNAME.Contains(searchText)).ToList();

                var ListModel = new List<PersonnalViewModel>();

                foreach (var item in personnalList)
                {
                    var model = new PersonnalViewModel();
                    model.ID = item.ID;
                    model.FIRSTNAME = item.FIRSTNAME;
                    model.LASTNAME = item.LASTNAME;

                    ListModel.Add(model);
                }
                return ListModel;

            }
        }
    }
}
