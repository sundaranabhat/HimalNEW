﻿using DataAccessLayer.Service;
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
            using (var entity = new HimalDbEntities())
            {
                var personnalList = entity.Personnels.Where(x => x.FIRSTNAME.Contains(searchText) || x.LASTNAME.Contains(searchText)).ToList();

                var ListModel = new List<PersonnalViewModel>();

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
