using DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.ViewModel;
using System.Data.Entity;

namespace DataAccessLayer.Implementation
{
    public class PersonnalService : IPersonnalService
    {
        public PersonnalService()
        {

        }

        public PersonnalViewModel GetDetailById(int id)
        {
            using (var entity = new HimalDbEntities())
            {
                var personnalValue = entity.Personnels.Where(x => x.ID == id).FirstOrDefault();

                var model = new PersonnalViewModel();
                if (personnalValue != null)
                {
                    model.ID = personnalValue.ID;
                    model.LASTNAME = personnalValue.LASTNAME;
                    model.PLACEOFBIRTH = personnalValue.PLACEOFBIRTH;
                    model.FIRSTNAME = personnalValue.FIRSTNAME;
                    model.GENDER = personnalValue.GENDER;
                    model.DATEOFBIRTH = personnalValue.DATEOFBIRTH;
                    model.DODID = personnalValue.DODID;
                }
                return model;

            }
        }

        public void Insert(PersonnalViewModel model)
        {
            using (var entity = new HimalDbEntities())
            {
                var tableRow = new Personnel();
                tableRow.FIRSTNAME = model.FIRSTNAME;
                tableRow.LASTNAME = model.LASTNAME;
                tableRow.DODID = model.DODID;
                tableRow.GENDER = model.GENDER;
                tableRow.EMAIL = model.EMAIL;
                tableRow.DATEOFBIRTH = model.DATEOFBIRTH;
                tableRow.PLACEOFBIRTH = model.PLACEOFBIRTH;
                entity.Personnels.Add(tableRow);
                entity.SaveChanges();
            }
        }

        public List<PersonnalViewModel> List(string searchText)
        {
            var splitSearch = searchText.Split(' ');
            var searchValue = "";
            if (splitSearch.Count() < 1)
            {
                searchValue = searchText;
            }
            else
            {
                searchValue = String.Join(" ", splitSearch);
            }
            using (var entity = new HimalDbEntities())
            {
                //int dodId = 0;
               // bool checkInt = int.TryParse(searchValue, out var n); // check searchText is integer or not, it returns true or false boolean value.
                var personnalList = entity.Personnels.ToList();
                var ListModel = new List<PersonnalViewModel>();
                //if (checkInt) // check  searchtext is integer 
                //{
                //    dodId = Convert.ToInt32(searchValue); // if searchtext is integer then change searchText to int data type
                //    personnalList = personnalList.Where(x => x.DODID == dodId).ToList();  // filter according to DIDId
                //}
               // else
               // {
                    if (splitSearch.Count() > 1)
                    {
                        personnalList = personnalList.Where(x => x.FIRSTNAME.ToUpper() == splitSearch[0].ToUpper() && x.LASTNAME.ToUpper().Contains(splitSearch[1].ToUpper())).ToList();
                    }
                    else
                    {
                    
                 
                        personnalList = personnalList.Where(x=>x.FIRSTNAME.ToUpper().Contains(searchValue.ToUpper()) || x.LASTNAME.ToUpper().Contains(searchValue.ToUpper())).ToList(); // filter according to firstname or last name
                    }
              //  }
                foreach (var item in personnalList)
                {
                    var model = new PersonnalViewModel();
                    model.ID = item.ID;
                    model.FIRSTNAME = item.FIRSTNAME;
                    model.LASTNAME = item.LASTNAME;
                    model.EMAIL = item.EMAIL;
                    model.DODID = item.DODID;
                    model.DATEOFBIRTH = item.DATEOFBIRTH;
                    model.GENDER = item.GENDER;
                    ListModel.Add(model);
                }
                return ListModel;

            }
        }

        public void Update(PersonnalViewModel model)
        {
            using (var entity = new HimalDbEntities())
            {
                var editData = entity.Personnels.Where(x => x.DODID == model.DODID).FirstOrDefault();
                editData.FIRSTNAME = model.FIRSTNAME;
                editData.LASTNAME = model.LASTNAME;
                editData.DATEOFBIRTH = model.DATEOFBIRTH;
                editData.DODID = model.DODID;
                editData.EMAIL = model.EMAIL;
                editData.GENDER = model.GENDER;
                entity.Entry(editData).State = EntityState.Modified;
                entity.SaveChanges();
            }
        }
    }


    
}
